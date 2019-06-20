using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Model
{
    // <summary>
    /// GroupMessageInfo 实体
    /// </summary>
    public class CqGroupMessage
    {

        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CqMsgId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int64 GroupId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int64 FromQQ { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime { get; set; }


    }
}
