using System.Collections.Generic;

namespace Native.Csharp.App.Config
{
    /// <summary>
    /// 群管理配置类
    /// </summary>
    public class GroupManagerConfig
    {
        /// <summary>
        /// 是否激活
        /// </summary>
        public bool activate { get; set; }
        /// <summary>
        /// 配置适用范围
        /// </summary>
        public GroupManagerConfigScope scope { get; set; }
        /// <summary>
        /// 如果指定群，输入群id
        /// </summary>
        public List<long> groupIds { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 入群验证处理
        /// </summary>
        public AddGroupValidation addGroupValidation { get; set; }
        /// <summary>
        /// 群公告
        /// </summary>
        public GroupPlacard groupPlacard { get; set; }
    }
    /// <summary>
    /// 入群验证处理
    /// </summary>
    public class AddGroupValidation
    {
        public AddGroupValidationType type { get; set; }
    }
    /// <summary>
    /// 群公告
    /// </summary>
    public class GroupPlacard
    {
        /// <summary>
        /// 主动加群提示
        /// </summary>
        public string addGroup { get; set; }
    }

    public enum GroupManagerConfigScope
    {
        /// <summary>
        /// 全局适用
        /// </summary>
        all,
        /// <summary>
        /// 特定群
        /// </summary>
        specific
    }

    public enum AddGroupValidationType
    {
        /// <summary>
        /// 自动接收
        /// </summary>
        autoAgree
    }
}
