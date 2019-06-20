using Native.Csharp.App.Model;

namespace Native.Csharp.App.Business
{
    public interface IGroupMessageLoger
    {
        void Log(CqGroupMessage msg);
    }
}
