using Native.Csharp.App.Config;
using System.Collections.Generic;

namespace Native.Csharp.Business
{
    public interface IConfig
    {
        SysConfig Get();
        void Refresh();
    }
}
