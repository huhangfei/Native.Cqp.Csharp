using Native.Csharp.App;
using Native.Csharp.App.Config;
using Native.Csharp.App.Interface;
using Native.Csharp.App.Model;
using Native.Csharp.Business.Model;
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
            //申请入群的验证配置
            var config= _config.Get(e.FromGroup);
            if (config == null)
                return;
            //自动同意
            if (config.addGroupValidation.type == AddGroupValidationType.autoAgree)
            {
                Common.CqApi.SetGroupAddRequest(e.Tag, Sdk.Cqp.Enum.RequestType.GroupAdd, ResponseType.PASS, e.AppendMsg);
            }
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
            //申请入群的验证配置
            var config = _config.Get(e.FromGroup);
            if (config == null)
                return;
            GroupPlacard groupPlacard = config.groupPlacard;
            if (!string.IsNullOrEmpty(groupPlacard.addGroup))
            {
                CurrentSystemVariable currentSystemVariable = new CurrentSystemVariable();

                currentSystemVariable.BeingOperateQQ = e.BeingOperateQQ;

                currentSystemVariable.AtCodeDic.Add(e.BeingOperateQQ, Common.CqApi.CqCode_At(e.BeingOperateQQ));

                QQ qqInfo = new QQ();
                Common.CqApi.GetQQInfo(e.BeingOperateQQ,out qqInfo);

                currentSystemVariable.BeingOperateQQInfo = qqInfo;


                Common.CqApi.SendGroupMessage(e.FromGroup, Utils.MessageParse(groupPlacard.addGroup, currentSystemVariable));
            }

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
