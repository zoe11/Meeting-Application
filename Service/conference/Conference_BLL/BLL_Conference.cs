using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conference_Model;
using Conference_DAL;
using FT_ENV;

namespace Conference_BLL
{
    public class BLL_Conference
    {
        Conference_DAL.DAL_Conference dal = new DAL_Conference();
        private readonly string ObjectName_UserInfo = "用户信息";

        public Result GetUserInfo(User filter)
        {
            Result result = Helper.IsNullObj(filter, ObjectName_UserInfo + "不能为空！");
            if (result.IsCorrect())
            {
                return dal.GetUserInfo(filter);
            }
            return result;
        }
    }
}
