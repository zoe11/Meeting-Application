
using System;

namespace FT_ENV
{
    /// <summary>
    /// 方法扩展类
    /// </summary>
    public static class FunctionExt
    {
        private const string DateFormat = "yyyy" + "-" + "MM" + "-" + "dd" + " " ;
        private const string TimeFormat = DateFormat + "HH" + ":" + "mm" + ":" + "ss" + "";

        public static bool IsCorrect(this Result result)
        {
            bool flag = true;
            if (result == null)
                flag = false;
            else
            {
                if (result.Code != ResCode.Correct)
                    flag = false;
            }
            return flag;
        }

        public static bool IsSpecial(this Result result)
        {
            bool flag = true;
            if (result == null)
                flag = false;
            else
            {
                if (result.Code != ResCode.Special)
                    flag = false;
            }
            return flag;
        }

        public static bool IsExist(this Result result)
        {
            bool flag = true;
            if (result == null)
                flag = false;
            else
            {
                if (result.Code != ResCode.Exist)
                    flag = false;
            }
            return flag;
        }

        public static bool IsNotExist(this Result result)
        {
            bool flag = true;
            if (result == null)
                flag = false;
            else
            {
                if (result.Code != ResCode.NotExist)
                    flag = false;
            }
            return flag;
        }

        public static bool IsNullCode(this Result result)
        {
            bool flag = true;
            if (result == null)
                flag = false;
            else
            {
                if (result.Code != ResCode.Null)
                    flag = false;
            }
            return flag;
        }

        public static bool IsNull(this object obj)
        {
            //var flag = false;
            //if (obj == null)
            //    flag = true;
            return obj == null;
        }

        public static string ToDateString(this DateTime dateTime)
        {
            return String.Format("{0:"+DateFormat+"}", dateTime);
        }

        public static string ToTimeString(this DateTime dateTime)
        {
            return String.Format("{0:" + TimeFormat + "}", dateTime);
        }

        public static string ToDateString(this string dateTime)
        {
            return String.Format("{0:" + DateFormat + "}", dateTime);
        }

        public static string ToTimeString(this string dateTime)
        {
            return String.Format("{0:" + TimeFormat + "}", dateTime);
        }
    }
}
