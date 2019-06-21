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
        private IDapWrapper _dapWrapper;

        public CqMessageAndDicRelationDao(IConfig config, IDapWrapper dapWrapper)
        {
            _config = config;
            _dapWrapper = dapWrapper;
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
            return _dapWrapper.InnerExecuteSql(_config.Get().dbConnectionString, sql, cqMessageAndImageRelation)>0;
        }
    }
}
