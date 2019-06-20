using Native.Csharp.App.Business;
using Native.Csharp.App.Model;
using Native.Csharp.Dao;

namespace Native.Csharp.App.Dao
{
    public class GroupMessageInfoDao : IGroupMessageInfoDao
    {
        private IConfig _config;

        public GroupMessageInfoDao(IConfig config)
        {
            _config = config;
        }

        public void Add(GroupMessageInfo groupMessageInfo)
        {
            string sql = @"INSERT INTO GroupMessageInfo
                                (
                                GroupId,
                                FromQQ,
                                ToQQ,
                                Message,
                                ObtainedTime,
MsgId
                                )
                                VALUES
                                (
                                @GroupId,
                                @FromQQ,
                                @ToQQ,
                                @Message,
                                @ObtainedTime,
@MsgId
                                )";
            DapWrapper.InnerExecuteSql(_config.Get().dbConnectionString, sql, groupMessageInfo);
        }
    }
}
