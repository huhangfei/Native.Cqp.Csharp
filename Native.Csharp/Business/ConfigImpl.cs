using System.Collections.Generic;
using System.IO;
using System.Linq;
using Native.Csharp.App;
using Native.Csharp.App.Config;
using Newtonsoft.Json;

namespace Native.Csharp.Business
{
    public class ConfigImpl : IConfig
    {
        private SysConfig sysConfig;


        public SysConfig Get()
        {
            if(sysConfig!=null)
                return sysConfig;
            Refresh();
            return sysConfig;
        }
        public void Refresh()
        {
            sysConfig = GetAllFromFile();
        }

        private SysConfig GetAllFromFile()
        {
            string fileName = "config.json";
            string path = Common.CqApi.GetAppDirectory()+ fileName;

            if (File.Exists(path))
            {
                string json= File.ReadAllText(path);
                SysConfig config = JsonConvert.DeserializeObject<SysConfig>(json);
                return config;
            }
            return null;
        }
    }
}
