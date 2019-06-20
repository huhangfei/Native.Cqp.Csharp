using Native.Csharp.App.Business;
using Native.Csharp.App.EventArgs;
using Native.Csharp.App.Interface;
using System;

namespace Native.Csharp.App.Event
{
    public class Event_ReceiveGroupMessage : IReceiveGroupMessage
    {
        IGroupMessageLoger _groupMessageLoger;
        public Event_ReceiveGroupMessage(IGroupMessageLoger groupMessageLoger)
        {
            _groupMessageLoger = groupMessageLoger;
        }

        void IReceiveGroupMessage.ReceiveGroupMessage(object sender, CqGroupMessageEventArgs e)
        {
            try
            {
                _groupMessageLoger.Log(new Model.GroupMessageInfo()
                {
                    FromQQ = e.FromQQ,
                    Message = e.Message,
                    GroupId = e.FromGroup,
                    ObtainedTime = DateTime.Now,
                    MsgId = e.MsgId
                });
            }
            catch (Exception ex)
            {
                Common.CqApi.AddLoger(Sdk.Cqp.Enum.LogerLevel.Error, "群消息记录异常", "群消息写入异常 msg" + ex.Message);
            }
            e.Handler = false;
        }
    }
}
