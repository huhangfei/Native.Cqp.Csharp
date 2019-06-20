using Native.Csharp.App.Config;
using Native.Csharp.App.Enum;
using System.Collections.Generic;
using System.IO;

namespace Native.Csharp.App.Business
{
    public class LocalFileStorage : IFileStorage
    {
        private IConfig _config;
        public LocalFileStorage(IConfig config)
        {
            _config = config;

        }

        public void Save(string fileName, string saveDirectory, string filePath)
        {
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(saveDirectory) || string.IsNullOrEmpty(filePath)) {

                Common.CqApi.AddLoger(Sdk.Cqp.Enum.LogerLevel.Debug, "参数无效", $"要存储的数据无效 fileName={fileName},saveDirectory={saveDirectory},filePath={filePath}");

                return;
            }
            FileStorageBaseConfig config = _config.Get().fileStorage;
            saveDirectory = config.StorageConfig["path"]+saveDirectory;

            string saveFilePath = Path.Combine(saveDirectory, fileName);

            //文件已经存在
            if (File.Exists(saveFilePath))
            {
                return;
            }
            if (!Directory.Exists(saveDirectory))
            {
                try
                {
                    Directory.CreateDirectory(saveDirectory);
                }
                catch { }
            }
            File.Copy(filePath, saveFilePath);
        }
    }
}
