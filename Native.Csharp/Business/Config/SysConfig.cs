using System;
using System.Collections.Generic;

namespace Native.Csharp.App.Config
{
    /// <summary>
    /// 群管理配置类
    /// </summary>
    public class SysConfig
    {
        /// <summary>
        /// 如果指定群，输入群id
        /// </summary>
        public List<long> groupIds { get; set; }
        /// <summary>
        /// 命令前缀
        /// </summary>
        public string cmdPrefix { get; set; }
        /// <summary>
        /// 竞猜前缀
        /// </summary>
        public string jingCaiCmdPrefix { get; set; }

        public string xuanShangDiZhi { get; set; }

        /// <summary>
        /// 经常提示开始前最后多少分钟
        /// </summary>
        public int [] jingCaiLastMinute { get; set; }

        public DateTime jingCaiKaiShiShiJian { get; set; } 

        public DateTime jingCaiJieShuShiJian { get; set; }

        public string jingCaiChaXunDiZhi { get; set; }
    }
    
}
