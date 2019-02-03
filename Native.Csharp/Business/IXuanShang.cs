using Native.Csharp.App.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Native.Csharp.Business
{
    public interface IXuanShang
    {
        string Get(string queryText);
        string Get(string queryText, SysConfig config);
    }
}
