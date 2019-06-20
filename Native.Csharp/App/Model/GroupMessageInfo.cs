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
    public class GroupMessageInfo
    {

        /// <summary>
        /// 
        /// </summary>
        public Int64 Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long FromQQ { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long ToQQ { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ObtainedTime { get; set; }

        public int MsgId { get; set; }

    }
}
