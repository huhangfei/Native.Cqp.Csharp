using Native.Csharp.App.Config;
using System.Collections.Generic;

namespace Native.Csharp.Business
{
    public interface IConfig
    {
        void Refresh();
        List<GroupManagerConfig> GetAll();
        GroupManagerConfig Get(long groupId);
    }
}
