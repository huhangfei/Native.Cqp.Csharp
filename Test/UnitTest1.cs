using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Native.Csharp.Business;
using Native.Csharp.Business.Model;
using Native.Csharp.Tool.Http;
using Newtonsoft.Json;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            XuanShangImpl xuanShangImpl = new XuanShangImpl(null);

            string result= xuanShangImpl.Get("跳跳犬", new Native.Csharp.App.Config.SysConfig() {
                xuanShangDiZhi= "http://cc.koncoo.com/yys/default.aspx"
            });

            Console.WriteLine(result);
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void TestMethod2()
        {
            string json = HttpHelper.Get("https://www.lufernew.com/api/guess/checkExistRecord.do");

            JingCaiWinRateInfo info = JsonConvert.DeserializeObject<JingCaiWinRateInfo>(json);

            Assert.IsNotNull(info);
        }
    }
}
