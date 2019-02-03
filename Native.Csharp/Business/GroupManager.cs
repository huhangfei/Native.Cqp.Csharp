using Native.Csharp.App;
using Native.Csharp.App.Config;
using Native.Csharp.App.Interface;
using Native.Csharp.App.Model;
using Native.Csharp.Sdk.Cqp.Api;
using Native.Csharp.Sdk.Cqp.Enum;
using Native.Csharp.Sdk.Cqp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Native.Csharp.Business
{
    public class GroupManager : IGroupManager
    {
        IConfig _config;
        public GroupManager(IConfig config)
        {
            _config = config;
        }
        /// <summary>
		/// Type=302 群事件 - 群请求 - 申请入群<para/>
		/// 处理收到的群请求 (申请入群) 事件
		/// </summary>
		/// <param name="sender">事件的触发对象</param>
		/// <param name="e">事件的附加参数</param>
        public void ReceiveGroupAddApply(object sender, GroupAddRequestEventArgs e)
        {
            e.Handled = false;
        }

        public void ReceiveGroupAddInvitee(object sender, GroupAddRequestEventArgs e)
        {
            e.Handled = false;
        }

        public void ReceiveGroupFileUpload(object sender, FileUploadMessageEventArgs e)
        {
            e.Handled = false;
        }

        public void ReceiveGroupManageDecrease(object sender, GroupManageAlterEventArgs e)
        {
            e.Handled = false;
        }

        public void ReceiveGroupManageIncrease(object sender, GroupManageAlterEventArgs e)
        {
            e.Handled = false;
        }

        public void ReceiveGroupMemberInvitee(object sender, GroupMemberAlterEventArgs e)
        {
            e.Handled = false;
        }
        /// <summary>
		/// Type=103 群事件 - 群成员增加 - 主动入群<para/>
		/// 处理收到的群成员增加 (主动入群) 事件
		/// </summary>
		/// <param name="sender">事件的触发对象</param>
		/// <param name="e">事件的附加参数</param>
        public void ReceiveGroupMemberJoin(object sender, GroupMemberAlterEventArgs e)
        {
            e.Handled = false;
        }

        public void ReceiveGroupMemberLeave(object sender, GroupMemberAlterEventArgs e)
        {
            e.Handled = false;
        }

        public void ReceiveGroupMemberRemove(object sender, GroupMemberAlterEventArgs e)
        {
            e.Handled = false;
        }

        public void ReceiveGroupMessage(object sender, GroupMessageEventArgs e)
        {
            e.Handled = false;
        }

        public void ReceiveGroupPrivateMessage(object sender, PrivateMessageEventArgs e)
        {
            e.Handled = false;
        }
    }
}
