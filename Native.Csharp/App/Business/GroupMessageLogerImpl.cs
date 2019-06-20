using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.Dao;
using Native.Csharp.App.Model;

namespace Native.Csharp.App.Business
{
    public class GroupMessageLogerImpl : IGroupMessageLoger
    {
        private IGroupMessageInfoDao _groupMessageInfoDao;
        private IConfig _config;
        private List<long> groupIds;
        public GroupMessageLogerImpl(IConfig config,IGroupMessageInfoDao groupMessageInfoDao)
        {
            _config = config;
            _groupMessageInfoDao = groupMessageInfoDao;
            
        }

        public void Log(GroupMessageInfo msg)
        {
            if (groupIds == null)
            {
                groupIds = _config.Get().groupIds;
            }

            if (groupIds.Contains(msg.GroupId))
            {
                _groupMessageInfoDao.Add(msg);
            }
        }
    }
}
