using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Native.Csharp.App.Dao;
using Native.Csharp.App.Model;
using Native.Csharp.Sdk.Cqp;
using Native.Csharp.Sdk.Cqp.Enum;
using Newtonsoft.Json;
using Unity;

namespace Native.Csharp.App.Business
{
    public class GroupMessageLogerImpl : IGroupMessageLoger
    {
        private IConfig _config;
        private ICqGroupMessageDao _groupMessageInfoDao;
        private ICqMsgDicDao _cqMsgDicDao;
        ICqMessageAndDicRelationDao _cqMessageAndDicRelationDao;
        IUnityContainer _container;
        private List<long> groupIds;
        public GroupMessageLogerImpl(IConfig config,
            ICqGroupMessageDao groupMessageInfoDao,
            ICqMsgDicDao cqImageInfoDao,
            ICqMessageAndDicRelationDao cqMessageAndImageRelationDao,
            IUnityContainer container
            )
        {
            _config = config;
            _groupMessageInfoDao = groupMessageInfoDao;
            _cqMsgDicDao = cqImageInfoDao;
            _cqMessageAndDicRelationDao = cqMessageAndImageRelationDao;
            _container = container;
        }
        /// <summary>
        /// 获取消息中的图片
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private List<CqMsgDic> GetMsgDic(CqGroupMessage msgInfo)
        {
            string msg = msgInfo.Message;
            List<CqMsgDic> cqMsgDicInfos = new List<CqMsgDic>();
            DateTime currentTime = DateTime.Now;
            CqMsg.Parse(msg).Contents.ForEach(m => {
                if (m.Type == CqCodeType.Image)
                {
                    string saveDirectory = $"/image/{currentTime.ToString("yyyy/MM")}/";
                    m.Dictionary.Add("saveDirectory", saveDirectory);
                }
                else if (m.Type == CqCodeType.Record)
                {
                    string saveDirectory = $"/record/{currentTime.ToString("yyyy/MM")}/";
                    m.Dictionary.Add("saveDirectory", saveDirectory);

                    string fileName = m.Dictionary["file"];

                    m.Dictionary.Add("newFile", fileName.Replace(Path.GetExtension(fileName),".mp3"));


                }
                    cqMsgDicInfos.Add(new CqMsgDic()
                {
                    Id = Guid.NewGuid().ToString().ToUpper(),
                    CqCode = m.OriginalString,
                    CqCodeType=m.Type.ToString(),
                    Contents=JsonConvert.SerializeObject(m.Dictionary),
                    CreateTime= currentTime
                });
            });
            return cqMsgDicInfos;
        }

        private void HandleMsgDic(CqMsgDic msgDic)
        {
            Dictionary<string, string> dic =  JsonConvert.DeserializeObject<Dictionary<string, string>>(msgDic.Contents);

            if (msgDic.CqCodeType == CqCodeType.Image.ToString())
            {
                string fileName = dic["file"];
                string filePath = Common.CqApi.ReceiveImage(fileName);
                string saveDirectory = dic["saveDirectory"];
                IFileStorage fileStorage = _container.Resolve<IFileStorage>(_config.Get().fileStorage.StorageType.ToString());
                fileStorage.Save(fileName, saveDirectory, filePath);
            }
            else if (msgDic.CqCodeType == CqCodeType.Record.ToString())
            {
                string fileName = dic["newFile"];
                string filePath = Common.CqApi.ReceiveRecord(fileName,AudioOutFormat.MPEG_Layer3);
                string saveDirectory = dic["saveDirectory"];
                IFileStorage fileStorage = _container.Resolve<IFileStorage>(_config.Get().fileStorage.StorageType.ToString());
                fileStorage.Save(fileName, saveDirectory, filePath);
            }
        }
        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="msgInfo"></param>
        public void Log(CqGroupMessage msgInfo)
        {
            msgInfo.Id = Guid.NewGuid().ToString().ToUpper();

            if (groupIds == null)
            {
                groupIds = _config.Get().groupIds;
            }

            if (groupIds.Contains(msgInfo.GroupId))
            {
                if (!_groupMessageInfoDao.Add(msgInfo)) {
                    return;
                }
                List<CqMsgDic> cqImageInfos = GetMsgDic(msgInfo);
                if (cqImageInfos.Count() > 0)
                {
                    //根据CqCode去重
                    Dictionary<string, CqMsgDic> keyValues = new Dictionary<string, CqMsgDic>();
                    cqImageInfos.ForEach(n => {
                        //写入字典信息
                        var msgDic = _cqMsgDicDao.AddOrUpdateByCqCode(n);

                        if (msgDic.Id == n.Id)
                        {
                            //新写入去处理
                            HandleMsgDic(msgDic);
                        }
                        //去重
                        if (msgDic != null && !keyValues.ContainsKey(msgDic.CqCode))
                        {
                            keyValues.Add(msgDic.CqCode, msgDic);
                        }
                    });

                    //去重后的内容写入消息与字典的关系
                    keyValues.Values.ToList().ForEach(x =>
                    {
                        _cqMessageAndDicRelationDao.Add(new CqMessageAndDicRelation()
                        {
                            Id = Guid.NewGuid().ToString().ToUpper(),
                            CqGroupMessageId=msgInfo.Id,
                            CqMsgDicId=x.Id
                        });
                    });
                }
            }
        }
    }
}
