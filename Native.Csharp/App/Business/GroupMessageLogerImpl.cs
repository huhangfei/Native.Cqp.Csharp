using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.Dao;
using Native.Csharp.App.Model;
using Native.Csharp.Sdk.Cqp;
using Native.Csharp.Sdk.Cqp.Enum;
using Newtonsoft.Json;

namespace Native.Csharp.App.Business
{
    public class GroupMessageLogerImpl : IGroupMessageLoger
    {
        private IConfig _config;
        private ICqGroupMessageDao _groupMessageInfoDao;
        private ICqMsgDicDao _cqMsgDicDao;
        ICqMessageAndDicRelationDao _cqMessageAndDicRelationDao;
        private List<long> groupIds;
        public GroupMessageLogerImpl(IConfig config,
            ICqGroupMessageDao groupMessageInfoDao,
            ICqMsgDicDao cqImageInfoDao,
            ICqMessageAndDicRelationDao cqMessageAndImageRelationDao
            )
        {
            _config = config;
            _groupMessageInfoDao = groupMessageInfoDao;
            _cqMsgDicDao = cqImageInfoDao;
            _cqMessageAndDicRelationDao = cqMessageAndImageRelationDao;

        }
        /// <summary>
        /// 获取消息中的图片
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private List<CqMsgDic> GetMsgDic(string msg)
        {
            List<CqMsgDic> cqMsgDicInfos = new List<CqMsgDic>();
            CqMsg.Parse(msg).Contents.ForEach(m => {

                if (m.Type == CqCodeType.Image)
                {
                    //string fileName = m.Dictionary["file"];
                    //string filePath = Common.CqApi.ReceiveImage(fileName);
                    
                }
                cqMsgDicInfos.Add(new CqMsgDic()
                {
                    Id = Guid.NewGuid().ToString().ToUpper(),
                    CqCode = m.OriginalString,
                    CqCodeType=m.Type.ToString(),
                    Contents=JsonConvert.SerializeObject(m.Dictionary)
                });
            });
            return cqMsgDicInfos;
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
                List<CqMsgDic> cqImageInfos = GetMsgDic(msgInfo.Message);
                if (cqImageInfos.Count() > 0)
                {
                    Dictionary<string, CqMsgDic> keyValues = new Dictionary<string, CqMsgDic>();
                    cqImageInfos.ForEach(n => {
                        //写入字典信息
                        var msgDic = _cqMsgDicDao.AddOrUpdateByCqCode(n);
                        if (msgDic != null && !keyValues.ContainsKey(msgDic.CqCode))
                        {
                            keyValues.Add(msgDic.CqCode, msgDic);
                        }
                    });
                    //写入消息与字典的关系
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
