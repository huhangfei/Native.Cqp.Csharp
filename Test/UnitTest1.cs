using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Native.Csharp.Business.Model;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CurrentSystemVariable data = new CurrentSystemVariable();
            data.AtCodeDic.Add(1,"aaa");
            data.BeingOperateQQ = 1;
            data.BeingOperateQQInfo = new Native.Csharp.Sdk.Cqp.Model.QQ()
            {
                Id = 1,
                Age = 12,
                Nick = "哈哈",
                Sex = Native.Csharp.Sdk.Cqp.Enum.Sex.Man
            };
            string template = " @Model.AtCodeDic[Model.BeingOperateQQ] 欢迎 @Model.BeingOperateQQInfo.Nick 加入本群~";
           var result= Native.Csharp.Business.Utils.MessageParse(template, data);

            Assert.IsNotNull(result);

        }
    }
}
