using Native.Csharp.Business.Model;

namespace Native.Csharp.Business
{
    public interface IJingCaiChaXun
    {
        JingCaiInfo Convert(JingCaiWinRateInfo rateInfo);
        JingCaiWinRateInfo GetJingCaiWinRate();
        JingCaiInfo GetJingJingCaiInfo();
        string GetMsg();
    }
}