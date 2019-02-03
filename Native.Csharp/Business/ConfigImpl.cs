using System.Collections.Generic;
using System.IO;
using System.Linq;
using Native.Csharp.App;
using Native.Csharp.App.Config;
using Newtonsoft.Json;

namespace Native.Csharp.Business
{
    public class ConfigImpl: IConfig
    {
        private List<GroupManagerConfig> managerConfigs;


        public GroupManagerConfig Get(long groupId)
        {

            List<GroupManagerConfig> managerConfigs = GetAll();
            if (managerConfigs == null)
                return null;

            var sp = managerConfigs.Where(n => n.activate && n.scope == GroupManagerConfigScope.specific && n.groupIds.Count(m => m == groupId) > 0).FirstOrDefault();
            if (sp != null)
                return sp;

            return managerConfigs.Where(n => n.activate && n.scope== GroupManagerConfigScope.all).FirstOrDefault(); ;
        }

        public List<GroupManagerConfig> GetAll()
        {
            if (managerConfigs == null)
            {
                managerConfigs = GetAllFromFile();
            }
            return managerConfigs;
        }

        public void Refresh()
        {
            managerConfigs = GetAllFromFile();
        }

        private List<GroupManagerConfig> GetAllFromFile()
        {
            string fileName = "yingyingyinggroupmanager.json";
            string path = Common.CqApi.GetAppDirectory()+ fileName;

            if (File.Exists(path))
            {
                string json= File.ReadAllText(path);
                List<GroupManagerConfig> managerConfigs = JsonConvert.DeserializeObject<List<GroupManagerConfig>>(json);
                return managerConfigs;
            }
            return null;
        }
    }
}
