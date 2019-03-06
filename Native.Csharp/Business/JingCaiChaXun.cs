using Native.Csharp.Business.Model;
using Native.Csharp.Tool.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Native.Csharp.Business
{
    public class JingCaiChaXun : IJingCaiChaXun
    {
        IConfig _configServer;
        public JingCaiChaXun(IConfig configServer)
        {
            _configServer = configServer;
        }

        public  JingCaiWinRateInfo GetJingCaiWinRate()
        {
            var config = _configServer.Get();

            string json= HttpHelper.Get(config.jingCaiChaXunDiZhi);

            JingCaiWinRateInfo info = JsonConvert.DeserializeObject<JingCaiWinRateInfo>(json);
            return info;
        }

        public JingCaiInfo Convert(JingCaiWinRateInfo rateInfo)
        {
            JingCaiInfo info = new JingCaiInfo();

            if (rateInfo.code != 1)
                return null;

            info.HongDeFen = rateInfo.data.chartDataList[0];
            info.LanDeFen = rateInfo.data.chartDataList[1];

            info.HongFang = new List<ShiShenInfo>();
            info.LanFang = new List<ShiShenInfo>();
            for (int i = 0; i < rateInfo.data.idListRed.Length;i++)
            {
                info.HongFang.Add(new ShiShenInfo {
                    Id= rateInfo.data.idListRed[i],
                    Name=rateInfo.data.nameListRed[i],
                    ShengChang = rateInfo.data.winTimesListRed[i],
                    FuChang = rateInfo.data.loseTimesListRed[i],
                    WinRate=rateInfo.data.winRateListRed[i]
                });
            }
            for (int i = 0; i < rateInfo.data.idListBlue.Length; i++)
            {
                info.LanFang.Add(new ShiShenInfo
                {
                    Id = rateInfo.data.idListBlue[i],
                    Name = rateInfo.data.nameListBlue[i],
                    ShengChang = rateInfo.data.winTimesListBlue[i],
                    FuChang = rateInfo.data.loseTimesListBlue[i],
                    WinRate = rateInfo.data.winRateListBlue[i]
                });
            }

            info.LastUpdate = rateInfo.data.lastUpdateTime;
            return info;
        }

        public JingCaiInfo GetJingJingCaiInfo()
        {
            return Convert(GetJingCaiWinRate());
        }

        public string GetMsg()
        {
            StringBuilder msg = new StringBuilder();
            string q = "\r\n";
            JingCaiInfo jingCaiInfo = GetJingJingCaiInfo();
            if (jingCaiInfo != null)
            {
                msg.Append("【本期红方阵容】"); msg.Append(q);
                msg.Append(string.Join(q, jingCaiInfo.HongFang.Select(n => ShiShenMsg(n)).ToArray()));
                msg.Append(q);
                msg.Append("【本期蓝方阵容】"); msg.Append(q);
                msg.Append(string.Join(q, jingCaiInfo.LanFang.Select(n => ShiShenMsg(n)).ToArray()));
                msg.Append(q);
                msg.AppendFormat("本期赢率预测分: 红{0} 蓝{1}", jingCaiInfo.HongDeFen, jingCaiInfo.LanDeFen);
            }
            else {
                msg.Append("本期预测数据暂未生成~");
            }

            return msg.ToString();
        }

        private string ShiShenMsg(ShiShenInfo shiShen)
        {
            return string.Format("{0}({1}/{2}-胜率{3}%)", shiShen.Name, shiShen.ShengChang, shiShen.FuChang,shiShen.WinRate);
        }
    }
}
