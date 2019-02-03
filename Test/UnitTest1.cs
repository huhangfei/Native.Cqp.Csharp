using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Native.Csharp.Business;

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


            Assert.IsNotNull(result);

        }
    }
}
