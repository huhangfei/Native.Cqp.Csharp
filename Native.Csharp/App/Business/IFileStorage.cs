using Native.Csharp.App.Enum;

namespace Native.Csharp.App.Business
{
    public interface IFileStorage
    {
        void Save(string fileName,string saveDirectory,string filePath);
    }
}
