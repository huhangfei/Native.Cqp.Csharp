using Native.Csharp.App.Config;
using Newtonsoft.Json;
using System.IO;

namespace Native.Csharp.App.Business
{
    public class ConfigImpl : IConfig
    {
        private SysConfig sysConfig;


        public SysConfig Get()
        {
            if (sysConfig != null)
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
            string path = Common.CqApi.GetAppDirectory() + fileName;
            Common.CqApi.AddLoger(Sdk.Cqp.Enum.LogerLevel.Debug, "读取配置", path);
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SysConfig config = JsonConvert.DeserializeObject<SysConfig>(json);
                return config;
            }
            else {
                throw new System.Exception("未找到配置文件 path="+path);
            }
            
        }
    }
}
