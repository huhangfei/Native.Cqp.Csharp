using Native.Csharp.App.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Business
{
    public interface IConfig
    {
        SysConfig Get();
        void Refresh();
    }
}
