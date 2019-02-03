using Native.Csharp.Sdk.Cqp.Model;
using System.Collections.Generic;

namespace Native.Csharp.Business.Model
{
    public class CurrentSystemVariable
    {
        public long LoginQQ { get; set; }
        /// <summary>
		/// 被操作QQ
		/// </summary>
		public long BeingOperateQQ { get; set; }
        /// <summary>
        /// 被操作QQ信息
        /// </summary>
        public QQ BeingOperateQQInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<long, string> AtCodeDic = new Dictionary<long, string>();
    }
}
