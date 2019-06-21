using Native.Csharp.App.Business;
using Native.Csharp.App.Model;
using Native.Csharp.Dao;

namespace Native.Csharp.App.Dao
{
    public class CqGroupMessageDao : ICqGroupMessageDao
    {
        private IConfig _config;
        private IDapWrapper _dapWrapper;

        public CqGroupMessageDao(IConfig config, IDapWrapper dapWrapper)
        {
            _config = config;
            _dapWrapper = dapWrapper;
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
           return _dapWrapper.InnerExecuteSql(_config.Get().dbConnectionString, sql, groupMessageInfo)>0;
        }
    }
}
