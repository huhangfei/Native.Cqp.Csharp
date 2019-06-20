using Native.Csharp.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Dao
{
    public interface ICqMessageAndDicRelationDao
    {
        bool Add(CqMessageAndDicRelation cqMessageAndImageRelation);
    }
}
