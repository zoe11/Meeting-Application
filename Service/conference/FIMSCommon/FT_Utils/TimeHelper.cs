using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FT_ENV;

namespace FT_Utils
{
    /// <summary>
    /// 获取服务器时间的公共类
    /// </summary>
    public class TimeHelper
    {
        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public static DateTime SetDateTime()
        {
            DateTime time;
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                var temp = dc.Pro_GetSystemDate().First();
                time = temp.time;

            }
            return time;
        }
    }
}
