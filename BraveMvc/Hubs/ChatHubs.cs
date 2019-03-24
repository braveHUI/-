using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using ViewModels;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Microsoft.AspNet.SignalR.Hubs;

namespace BraveMvc.Hubs
{
    [HubName("chathsdw")]
    public class ChatHubs : Hub
    {

        public void Hello()
        {
            Clients.All.hello();
        }
        static List<OnlineUserInfo> UserList = new List<OnlineUserInfo>();
        /// <summary>
        /// 注册群组 注册用户信息
        /// </summary>
        /// <param name="groupid">群组ID</param>
        /// <param name="usernickname">用户昵称</param>
        /// <param name="userfaceimg">用户头像</param>
        /// <param name="userid">用户在网站中的唯一标识ID</param>
        public void Group(string groupid, string usernickname, string userfaceimg, string userid)
        {
            //添加用户到群组 Groups.Add（用户连接ID，群组）
            Groups.Add(Context.ConnectionId, groupid);

            //如果说是一个简单的聊天室 下面这段代码是没有什么作用的 因为Context.ConnectionId是唯一的用户于服务器之间的连接
            //这里我传递进来了 用户的昵称和头像 还有网站中用户的ID 所以我要把用户的信息添加到我们上面建立的那个列表类中

            //如果用户不存在在线列表中
            if (UserList.Where(p => p.UserId == userid).FirstOrDefault() == null)
            {
                //我们在列表中 添加这个用户 并且标记用户在线 UserStates = "True"
                UserList.Add(new OnlineUserInfo() { UserId = userid, ConnectionId = Context.ConnectionId, UserNickName = usernickname, UserFaceImg = userfaceimg, UserStates = "True" });
            }
            //如果用户已经存在于在线列表中
            else
            {
                //我们更新用户列表中用户的信息 （这里更新的信息主要是用户的连接ID  ConnectionId = Context.ConnectionId）
                var UserInfo = UserList.Where(p => p.UserId == userid).FirstOrDefault();
                UserList.Remove(UserInfo);
                UserList.Add(new OnlineUserInfo() { UserId = userid, ConnectionId = Context.ConnectionId, UserNickName = usernickname, UserFaceImg = userfaceimg, UserStates = "True" });
            }
            //这个方法是调用客户端LoginUser方法 并且传递当前用户列表 客户端会刷新当前用户列表 调用的是全部的已连接的用户 Clients.All
            Clients.All.LoginUser(JsonConvert.SerializeObject(UserList));
            //这个方法是调用客户端的 addNewMessageToPage方法 目的是实现 当一个用户上线是 提醒所有的用户 某个用户上线了 提醒的是所有的已连接用户 所以也是Clients.All
            Clients.All.addNewMessageToPage("<dl  class=\"messageTip clearfix\"><dt></dt><dd>系统消息：" + DateTime.Now.ToString("HH:mm:ss") + "&nbsp;" + usernickname + "&nbsp;上线了<dd></dl>");
        }


        /// 发送消息 自定义判断是发送给全部用户还是某一个组（类似于群聊啦）
        /// </summary>
        /// <param name="groupid">接收的组</param>
        /// <param name="userfaceimg">发送用户的头像</param>
        /// <param name="usernickname">发送用户的昵称</param>
        /// <param name="message">发送的消息</param>
        public void Send(string groupid, string userfaceimg, string usernickname, string message)
        {
            if (groupid == "All")//全部用户（广播）
            {
                //调用所有客户端的addNewMessageToPage方法 推送一条消息
                Clients.All.addNewMessageToPage("<dl class=\"clearfix\"><dt><img src=\"" + userfaceimg + "\" /></dt><dd><i></i><div class=\"J_Users\">" + usernickname + "</div><div class=\"J_Content\">" + message + "</div></dd></dl>");
            }
            else//指定组(组播)
            {
                //调用指定客户端的addNewMessageToPage方法 推送一条消息（所有属于组groupid的已连接用户）
                Clients.Group(groupid).addNewMessageToPage("<dl class=\"clearfix\"><dt><img src=\"" + userfaceimg + "\" /></dt><dd><i></i><div class=\"J_Users\">" + usernickname + "</div><div class=\"J_Content\">" + message + "</div></dd></dl>");
            }
        }

        /// <summary>
        /// 发送给指定用户（单播）
        /// </summary>
        /// <param name="clientId">接收用户的连接ID</param>
        /// <param name="userfaceimg">发送用户的头像</param>
        /// <param name="usernickname">发送用户的昵称</param>
        /// <param name="message">发送的消息</param>
        public void SendSingle(string clientId, string userfaceimg, string usernickname, string message)
        {
            //首先我们获取一下接收用户的信息
            var UserInfo = UserList.Where(p => p.ConnectionId == clientId).FirstOrDefault();
            //如果用户不存在或用户的在线状态为False 那么提醒一下 发送用户 对方不在线
            if (UserInfo == null || UserInfo.UserStates == "False")
            {
                Clients.Client(Context.ConnectionId).addNewMessageToPage("<dl  class=\"messageTip clearfix\"><dt></dt><dd>系统消息：当前用户不在线<dd></dl>");
            }
            else
            {
                //如果用户存在并且在线呢 就把消息推送给接收的用户 并且加上当前用户信息 以及添加一个onclick事件 让接收的用户 可以直接点击消息的用户 回复 私聊信息 （不然还要在用户列表中找到谁给我发的消息 点击回复 这不科学...）
                Clients.Client(clientId).addNewMessageToPage("<dl class=\"clearfix\"><dt onclick=\"javascript:sendPerMessage('" + Context.ConnectionId + "','" + usernickname + "')\"><img src=\"" + userfaceimg + "\" /></dt><dd class=\"per\"><s></s><div onclick=\"javascript:sendPerMessage('" + Context.ConnectionId + "','" + usernickname + "')\" class=\"J_Users\">" + usernickname + "<span>私聊</span></div><div class=\"J_Content\">" + message + "</div></dd></dl>");
                //这句是发送给发送用户的 总不能我发送个私聊 对方收到了信息 我这里什么都不显示是吧 我也显示我发送的私聊信息 因为发送发就是我自己 所以不加onclick事件了 不允许自己跟自己聊天哦
                Clients.Client(Context.ConnectionId).addNewMessageToPage("<dl class=\"clearfix\"><dt><img src=\"" + userfaceimg + "\" /></dt><dd class=\"per\"><s></s><div class=\"J_Users\">" + usernickname + "<span>私聊</span></div><div class=\"J_Content\">" + message + "</div></dd></dl>");
            }
        }
        //使用者离线
        public override Task OnDisconnected(bool stopCalled)
        {
            var UserInfo = UserList.Where(p => p.ConnectionId == Context.ConnectionId).FirstOrDefault();
            var userid = UserInfo.UserId;
            var usernickname = UserInfo.UserNickName;
            var userfaceimg = UserInfo.UserFaceImg;
            UserList.Remove(UserInfo);
            UserList.Add(new OnlineUserInfo() { UserId = userid, ConnectionId = Context.ConnectionId, UserNickName = usernickname, UserFaceImg = userfaceimg, UserStates = "False" });

            Clients.All.LoginUser(JsonConvert.SerializeObject(UserList));
            Clients.All.addNewMessageToPage("<dl  class=\"messageTip clearfix\"><dt></dt><dd>系统消息：" + DateTime.Now.ToString("HH:mm:ss") + "&nbsp;" + usernickname + "&nbsp;离线了<dd></dl>");

            return base.OnDisconnected(true);
        }

        //使用者重新连接
        public override Task OnReconnected()
        {
            var UserInfo = UserList.Where(p => p.ConnectionId == Context.ConnectionId).FirstOrDefault();
            if (UserInfo != null)
            {
                var userid = UserInfo.UserId;
                var usernickname = UserInfo.UserNickName;
                var userfaceimg = UserInfo.UserFaceImg;
                UserList.Remove(UserInfo);
                UserList.Add(new OnlineUserInfo() { UserId = userid, ConnectionId = Context.ConnectionId, UserNickName = usernickname, UserFaceImg = userfaceimg, UserStates = "True" });
                Clients.All.LoginUser(JsonConvert.SerializeObject(UserList));
            }
            return base.OnReconnected();
        }
        //public void Register(string account, string password)
        //{
        //      try
        //    {
        //         //获取用户信息
        //        var User = UserManage.Get(p => p.ACCOUNT == account);
        //         if (User != null && User.PASSWORD == password)
        //         {
        //             //更新在线状态
        //             var UserOnline = UserOnlineManage.LoadListAll(p => p.FK_UserId == User.ID).FirstOrDefault();
        //             UserOnline.ConnectId = Context.ConnectionId;
        //             UserOnline.OnlineDate = DateTime.Now;
        //             UserOnline.IsOnline = true;
        //             UserOnline.UserIP = Utils.GetIP();
        //             UserOnlineManage.Update(UserOnline);
 
        //             //获取历史消息
        //             int days = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["HistoryDays"]);
        //            DateTime dtHistory = DateTime.Now.AddDays(-days);
        //             var ChatMessageList = ChatMessageManage.LoadAll(p => p.MessageDate > dtHistory);                    

        //             //超级管理员
        //             if (User.ID == ClsDic.DicRole["超级管理员"])
        //             {
        //                 //通知用户上线
        //                Clients.All.UserLoginNotice("超级管理员：" + User.NAME + " 上线了!");

        //                var HistoryMessage = ChatMessageList.OrderBy(p => p.MessageDate).ToList().Select(p => new
        //                 {
        //                     UserName = UserManage.Get(m => m.ID == p.FromUser).NAME,
        //                     UserFace = string.IsNullOrEmpty(UserManage.Get(m => m.ID == p.FromUser).FACE_IMG) ? "/Pro/Project/User_Default_Avatat?name=" + UserManage.Get(m => m.ID == p.FromUser).NAME.Substring(0, 1) : UserManage.Get(m => m.ID == p.FromUser).FACE_IMG,
        //                     MessageType = GetMessageType(p.MessageType),
        //                     p.FromUser,
        //                     p.MessageContent,
        //                     MessageDate = p.MessageDate.GetDateTimeFormats('D')[1].ToString() + " - " + p.MessageDate.ToString("HH:mm:ss"),
        //                     ConnectId = UserOnlineManage.LoadListAll(m => m.SYS_USER.ID == p.FromUser).FirstOrDefault().ConnectId
        //                 }).ToList();
 
        //                 //推送历史消息
        //                 Clients.Client(Context.ConnectionId).addHistoryMessageToPage(JsonConverter.Serialize(HistoryMessage));
        //             }
        //             else
        //             {
        //                 //获取用户一级部门信息
        //                 var Depart = GetUserDepart(User.DPTID);
        //                 if (Depart != null && !string.IsNullOrEmpty(Depart.ID))
        //                 {
        //                     //添加用户到部门群组 Groups.Add（用户连接ID，群组）
        //                     Groups.Add(Context.ConnectionId, Depart.ID);
        //                     //通知用户上线
        //                     Clients.All.UserLoginNotice(Depart.NAME + " - " + CodeManage.Get(m => m.CODEVALUE == User.LEVELS && m.CODETYPE == "ZW").NAMETEXT + "：" + User.NAME + " 上线了!");
        //                     //用户历史消息
        //                     int typeOfpublic = Common.Enums.ClsDic.DicMessageType["广播"];
        //                     int typeOfgroup = Common.Enums.ClsDic.DicMessageType["群组"];
        //                     int typeOfprivate = Common.Enums.ClsDic.DicMessageType["私聊"];
        //                     var HistoryMessage = ChatMessageList.Where(p => p.MessageType == typeOfpublic || (p.MessageType == typeOfgroup && p.ToGroup == Depart.ID) || (p.MessageType == typeOfprivate && p.ToGroup == User.ID.ToString())).OrderBy(p => p.MessageDate).ToList().Select(p => new
        //                     {
        //                        UserName = UserManage.Get(m => m.ID == p.FromUser).NAME,
        //                         UserFace = string.IsNullOrEmpty(UserManage.Get(m => m.ID == p.FromUser).FACE_IMG) ? "/Pro/Project/User_Default_Avatat?name=" + UserManage.Get(m => m.ID == p.FromUser).NAME.Substring(0, 1) : UserManage.Get(m => m.ID == p.FromUser).FACE_IMG,
        //                         MessageType = GetMessageType(p.MessageType),
        //                         p.FromUser,
        //                         p.MessageContent,
        //                        MessageDate = p.MessageDate.GetDateTimeFormats('D')[1].ToString() + " - " + p.MessageDate.ToString("HH:mm:ss"),
        //                         ConnectId = UserOnlineManage.LoadListAll(m => m.SYS_USER.ID == p.FromUser).FirstOrDefault().ConnectId
        //                     }).ToList();
                            
        //                     //推送历史消息
        //                     Clients.Client(Context.ConnectionId).addHistoryMessageToPage(JsonConverter.Serialize(HistoryMessage));
 
        //                 }
        //             }
        //             //刷新用户通讯录
        //             Clients.All.ContactsNotice(JsonConverter.Serialize(UserOnline));                    
        //         }
        //     }
        //     catch(Exception ex)
        //     {
        //         Clients.Client(Context.ConnectionId).UserLoginNotice("出错了：" + ex.Message);
        //         throw ex.InnerException;
        //    }
             
        // }







    }
}