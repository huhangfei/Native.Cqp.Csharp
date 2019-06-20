using Native.Csharp.App.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Config
{
    public class FileStorageBaseConfig
    {
        [JsonProperty(PropertyName = "storageType")]
        public FileStorageType StorageType { get; set; }

        [JsonProperty(PropertyName = "storageConfig")]
        public Dictionary<String,String> StorageConfig { get; set; }
    }
}
