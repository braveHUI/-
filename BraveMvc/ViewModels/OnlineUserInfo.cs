using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewModels
{
    public class OnlineUserInfo
    {
        public string UserId { get; set; }
        //用户连接ID
        public string ConnectionId { get; set; }
        //用户昵称
        public string UserNickName { get; set; }
        //用户头像
        public string UserFaceImg { get; set; }
        //用户状态
        public string UserStates { get; set; }
    }
}