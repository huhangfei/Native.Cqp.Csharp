using Newtonsoft.Json;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Security.Cryptography;

namespace Native.Csharp.Business
{
    public class Utils
    {
        public static string MessageParse(string template,object data)
        {
            
            var result =Engine.Razor.RunCompile(template, MD5Encrypt(JsonConvert.SerializeObject(data)), null, data);
            return result;
        }
        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="strText">要加密字符串</param>
        /// <returns></returns>
        public static string MD5Encrypt(string strText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(strText);
            bytes = md5.ComputeHash(bytes);
            md5.Clear();

            string ret = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                ret += Convert.ToString(bytes[i], 16).PadLeft(2, '0');
            }
            return ret.PadLeft(32, '0');
        }
    }
}
