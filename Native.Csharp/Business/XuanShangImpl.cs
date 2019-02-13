using HtmlAgilityPack;
using Native.Csharp.App.Config;
using Native.Csharp.Tool.Http;
using System.Collections.Generic;
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
            HtmlDocument doc2 = new HtmlDocument();
            doc2.LoadHtml(html);
            var dataDiv = doc2.DocumentNode.SelectSingleNode("//div[@id='divData']");
            
            StringBuilder sb = new StringBuilder();
            var thead = dataDiv.SelectSingleNode(".//thead");
            var ths = thead.SelectNodes(".//th");
            foreach (var th in ths)
            {
                string text = th.InnerText.Replace("\r\n", "").Replace(" ", "");
                sb.Append(text);
                if(!string.IsNullOrEmpty(text))
                    sb.Append(" ");
            }
            sb.Append("\r\n");

            var tbody = dataDiv.SelectSingleNode(".//tbody");
            var trs = tbody.SelectNodes(".//tr");
            foreach (var tr in trs)
            {
                var tds = tr.SelectNodes(".//td");
                foreach (var td in tds)
                {
                    sb.Append(td.InnerText.Replace("\r\n", "").Replace(" ", ""));
                    sb.Append(" ");
                }
                sb.Append("\r\n");
            }
            return sb.ToString();
        }
    }
}
