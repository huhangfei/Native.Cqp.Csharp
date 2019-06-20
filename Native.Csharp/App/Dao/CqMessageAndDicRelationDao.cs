using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.Business;
using Native.Csharp.App.Model;
using Native.Csharp.Dao;

namespace Native.Csharp.App.Dao
{
    public class CqMessageAndDicRelationDao : ICqMessageAndDicRelationDao
    {
        private IConfig _config;

        public CqMessageAndDicRelationDao(IConfig config)
        {
            _config = config;
        }

        public bool Add(CqMessageAndDicRelation cqMessageAndImageRelation)
        {
            string sql = @"INSERT INTO CqMessageAndDicRelation
(Id,
CqGroupMessageId,
CqMsgDicId,
CreateTime
)
VALUES
(@Id,
@CqGroupMessageId,
@CqMsgDicId,
GETDATE()
)";
            return DapWrapper.InnerExecuteSql(_config.Get().dbConnectionString, sql, cqMessageAndImageRelation)>0;
        }
    }
}
