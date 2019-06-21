using Native.Csharp.App.Business;
using Native.Csharp.App.Model;
using Native.Csharp.Dao;
using System.Linq;

namespace Native.Csharp.App.Dao
{
    public class CqMsgDicDao : ICqMsgDicDao
    {
        private IConfig _config;
        private IDapWrapper _dapWrapper;

        public CqMsgDicDao(IConfig config, IDapWrapper dapWrapper)
        {
            _config = config;
            _dapWrapper = dapWrapper;
        }

        public CqMsgDic AddOrUpdateByCqCode(CqMsgDic cqImageInfo)
        {
            string sql = @"
             IF NOT EXISTS (SELECT 1 FROM CqMsgDic WHERE CqCode=@CqCode)
             BEGIN
                INSERT INTO CqMsgDic
                        (Id,
                        CqCode,
                        CqCodeType,
                        Contents,
                        CreateTime,
                        UpdateTime
                        )
                        VALUES
                        (@Id,
                        @CqCode,
                        @CqCodeType,
                        @Contents,
                        GETDATE(),
                        GETDATE()
                        )

            END
            ELSE
            BEGIN
                UPDATE CqMsgDic SET UpdateTime=GETDATE() WHERE CqCode=@CqCode;
            END
            SELECT TOP 1 * FROM CqMsgDic WHERE CqCode=@CqCode ORDER BY UpdateTime DESC;
            ";
            return _dapWrapper.InnerQuerySql<CqMsgDic>(_config.Get().dbConnectionString, sql, cqImageInfo).FirstOrDefault();
        }
       
    }
}
