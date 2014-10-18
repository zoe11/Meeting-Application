using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FT_ENV;

namespace FTComponentSet
{
    /// <summary>
    /// 报表需要的参数
    /// </summary>
    public class Model4Client
    {
        /// <summary>
        /// 报表的相对路径
        /// </summary>
        private string path;

        /// <summary>
        /// 当前登录人的ID
        /// </summary>
        private string userID;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
    }
}
