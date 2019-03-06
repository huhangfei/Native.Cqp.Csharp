using Native.Csharp.App;
using Native.Csharp.App.Config;
using Native.Csharp.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Native.Csharp.Business
{
    /// <summary>
    /// 对弈竞猜
    /// </summary>
    public class JingCai : IJingCai
    {
        Thread thread;
        IConfig _configServer;
        IJingCaiChaXun _jingCaiChaXun;

        public JingCai(IConfig configServer, IJingCaiChaXun jingCaiChaXun)
        {
            _configServer = configServer;
            _jingCaiChaXun = jingCaiChaXun;
            
        }

        Dictionary<string, bool> sendLog = new Dictionary<string, bool>();

        /// <summary>
        /// 启动
        /// </summary>
        public void Run()
        {
            thread = new Thread(Job);

            thread.Start();

        }

        public void Stop()
        {
            try
            {
                if (thread != null)
                {
                    thread.Abort();
                    thread = null;
                }
            }
            catch { }
        }

        private void Job()
        {
            var sysConfig = _configServer.Get();
            DateTime current = DateTime.Now;
            if (current >= sysConfig.jingCaiKaiShiShiJian && current <= sysConfig.jingCaiJieShuShiJian)
            {
                try
                {
                    foreach (int lastm in sysConfig.jingCaiLastMinute.OrderByDescending(x=>x))
                    { 
                        DateTime sendDateTime = LastMToNextDateTime(lastm);
                        string key = sendDateTime.ToString("yyyyMMddHHmm");

                        if (key == current.ToString("yyyyMMddHHmm"))
                        {
                            //判断是否发送过
                            if (!sendLog.ContainsKey(key) || !sendLog[key])
                            {
                                //发送提示
                                SendMsg();
                                //发送完写入日志
                                if (sendLog.ContainsKey(key))
                                {
                                    sendLog[key] = true;
                                }
                                else
                                {
                                    sendLog.Add(key, true);
                                }
                            }
                        }
                    }

                }
                catch (Exception ex) {
                }
                Thread.Sleep(2000);
            }
            else {
                 Thread.Sleep(18000);
            }
            Job();
        }
        private int KaiJuZuiHouFenZhong()
        {
            DateTime nextDateTime = XiaCiKaiJuShiJian();
            DateTime current = DateTime.Now;
            return (int)Math.Round((nextDateTime - current).TotalMinutes);
        }
        private DateTime LastMToNextDateTime(int lastMinute)
        {
            DateTime nextDateTime= XiaCiKaiJuShiJian();

            return nextDateTime.AddMinutes(-lastMinute); ;
        }
        /// <summary>
        /// 下次开局时间
        /// </summary>
        /// <returns></returns>
        private DateTime XiaCiKaiJuShiJian()
        {
            DateTime current = DateTime.Now;
            int hour = current.Hour;
            int nextHour = 0;
            //检测是否 整除2
            if (hour % 2 != 0)
            {
                nextHour = hour + 1;
            }
            else
            {
                nextHour = hour + 2;
            }
            //下次开局时间
            DateTime nextDateTime = new DateTime(current.Year, current.Month, current.Day, nextHour, 0, 0);
            return nextDateTime;
        }
        /// <summary>
        /// 
        /// </summary>
        private void SendMsg()
        {
            var sysConfig = _configServer.Get();
            string q = "\r\n";
            StringBuilder msg = new StringBuilder();
            msg.Append("【重要播报，请注意】");
            msg.Append(q);
            msg.AppendFormat("本句对弈竞猜押注时间剩余{0}分钟，大家抓紧下注~", KaiJuZuiHouFenZhong());
            //抓取模拟比率
            string jingCaiYuCe= _jingCaiChaXun.GetMsg();
            msg.Append(q);
            msg.Append(jingCaiYuCe);
            msg.Append(q);
            msg.Append("温馨提示：小赌怡情，大赌伤身。预测仅供参考~");
            foreach (var id in sysConfig.groupIds)
            {
                Common.CqApi.SendGroupMessage(id, msg.ToString());
            }
        }

       
    }
}
