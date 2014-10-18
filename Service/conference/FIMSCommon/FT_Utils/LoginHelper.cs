using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FT_Utils
{
    /// <summary>
    /// 获取当前登录人信息的相关类
    /// </summary>
    public class LoginHelper
    {
        private static string _loginUserID;
        private static string _loginUserName;
        private static string _equipmentAdminID;
        private static string _equipmentAdminName;

        public static void SetLoginUserID(string loginUserID)
        {
            _loginUserID = loginUserID;
        }

        public static void SetLoginUserName(string loginUserName)
        {
            _loginUserName = loginUserName;
        }

        public static string GetLoginUserID()
        {
            if(FT_ENV.FTEnv.IsDebug)
            {
                return "admin";
            }
            return _loginUserID;
        }

        public static string GetLoginUserName()
        {
            if (FT_ENV.FTEnv.IsDebug)
            {
                return "admin";
            }
            return _loginUserName;
        }

        public static void SetAquipmentAdminID(string equipmentAdminID)
        {
            _equipmentAdminID = equipmentAdminID;
        }

        public static void SetAquipmentAdminName(string equipmentAdminName)
        {
            _equipmentAdminName = equipmentAdminName;
        }

        public static string GetAquipmentAdminID()
        {
            if (FT_ENV.FTEnv.IsDebug)
            {
                return "FT_SH";
            }
            return _equipmentAdminID;
        }

        public static string GetAquipmentAdminName()
        {
            if (FT_ENV.FTEnv.IsDebug)
            {
                return "FT_SH";
            }
            return _equipmentAdminName;
        }

        public static string GetSystem()
        {
            return "admin";
        }
        public static string GetSystemName()
        {
            return "admin";
        }
    }
}
