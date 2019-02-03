using HtmlAgilityPack;
using Native.Csharp.App.Config;
using Native.Csharp.Tool.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Native.Csharp.Business
{
    public class XuanShangImpl : IXuanShang
    {
        IConfig _configServer;
        public XuanShangImpl(IConfig configServer)
        {
            _configServer = configServer;
        }
        public string Get(string queryText)
        {
            return Get(queryText, _configServer.Get());
        }
        public string Get(string queryText, SysConfig config)
        {
            //get html 
            var web = new HtmlWeb();
            var doc = web.Load(config.xuanShangDiZhi);
            string __VIEWSTATE= doc.DocumentNode.SelectSingleNode("//input[@id='__VIEWSTATE']").Attributes["value"].Value;
            string __EVENTVALIDATION = doc.DocumentNode.SelectSingleNode("//input[@id='__EVENTVALIDATION']").Attributes["value"].Value;
            Dictionary<string, string> pars = new Dictionary<string, string>();
            pars.Add( "txtName", HttpUtility.UrlEncode(queryText));
            pars.Add("__VIEWSTATE", HttpUtility.UrlEncode(__VIEWSTATE));
            pars.Add("__EVENTVALIDATION", HttpUtility.UrlEncode(__EVENTVALIDATION));
            pars.Add("__EVENTTARGET", "lnkSearch");
            string html = HttpHelper.Post(config.xuanShangDiZhi, pars);
            var web2 = new HtmlWeb();
            var doc2=web2.Load(html);
            var dataDiv = doc2.DocumentNode.SelectSingleNode("//div[@id='divData']");
            var tbody=dataDiv.SelectSingleNode("//tbody");
            var trs = tbody.SelectNodes("//tr");



            throw new NotImplementedException();
        }
    }
}
