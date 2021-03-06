﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Models;
using IDAL;
using DAL;
using System.Reflection;

namespace DALFactory
{
    public class DataAccess
    {
        private static string AssemblyName = ConfigurationManager.AppSettings["Path"];
        private static string db = ConfigurationManager.AppSettings["DB"];
        public static IUsers Createuse()
        {
            string className = AssemblyName + "." + db + "Users";
            return (IUsers)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IGoods Creategood()
        {
            string className = AssemblyName + "." + db + "Goods";
            return (IGoods)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IClassify Createclassify()
        {
            string className = AssemblyName + "." + db + "Classify";
            return (IClassify)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static ICart CreateCart()
        {
            string className = AssemblyName + "." + db + "Cart";
            return (ICart)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IPersonal CreatePersonal()
        {
            string className = AssemblyName + "." + db + "Personal";
            return (IPersonal)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IBrave Createbrave()
        {
            string className = AssemblyName + "." + db + "Brave";
            return (IBrave)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static ICommentGoods CreateCommgood()
        {
            string className = AssemblyName + "." + db + "CommentGoods";
            return (ICommentGoods)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static ICommentRedSpots CreateCommRedSpots()
        {
            string className = AssemblyName + "." + db + "CommentRedSpots";
            return (ICommentRedSpots)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IArms CreateArms()
        {
            string className = AssemblyName + "." + db + "Arms";
            return (IArms)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static INews CreatNews()
        {
            string className = AssemblyName + "." + db + "News";
            return (INews)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IAddress Createaddre()
        {
            string className = AssemblyName + "." + db + "Address";
            return (IAddress)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IForum Createforum()
        {
            string className = AssemblyName + "." + db + "Forum";
            return (IForum)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IPost Createpost()
        {
            string className = AssemblyName + "." + db + "Post";
            return (IPost)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static ICommentMiliVideo CreateMiliVideo()
        {
            string className = AssemblyName + "." + db + "CommentMiliVideo";
            return (ICommentMiliVideo)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IAttention CreateAttention()
        {
            string className = AssemblyName + "." + db + "Attention";
            return (IAttention)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static ICommunication Createcommution()
        {
            string className = AssemblyName + "." + db + "Communication";
            return (ICommunication)Assembly.Load(AssemblyName).CreateInstance(className);
        }
      
        public static ICommentNews Createcommentnews()
        {
            string className = AssemblyName + "." + db + "CommentNews";
            return (ICommentNews)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IHistory CreateHistory()
        {
            string className = AssemblyName + "." + db + "History";
            return (IHistory)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IHistoryVideo CreateHistoryVideo()
        {
            string className = AssemblyName + "." + db + "HistoryVideo";
            return (IHistoryVideo)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IHistoryBook CreateHistoryBook()
        {
            string className = AssemblyName + "." + db + "HistoryBook";
            return (IHistoryBook)Assembly.Load(AssemblyName).CreateInstance(className);
        }
    }
}
