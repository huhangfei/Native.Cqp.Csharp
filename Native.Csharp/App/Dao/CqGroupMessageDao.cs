using Native.Csharp.App.Business;
using Native.Csharp.App.Model;
using Native.Csharp.Dao;

namespace Native.Csharp.App.Dao
{
    public class CqGroupMessageDao : ICqGroupMessageDao
    {
        private IConfig _config;

        public CqGroupMessageDao(IConfig config)
        {
            _config = config;
        }

        public bool Add(CqGroupMessage groupMessageInfo)
        {
            string sql = @"INSERT INTO CqGroupMessage
(Id,
CqMsgId,
GroupId,
FromQQ,
Message,
CreateTime
)
VALUES
(@Id,
@CqMsgId,
@GroupId,
@FromQQ,
@Message,
GETDATE()
)";
           return DapWrapper.InnerExecuteSql(_config.Get().dbConnectionString, sql, groupMessageInfo)>0;
        }
    }
}
