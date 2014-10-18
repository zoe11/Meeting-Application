using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;

namespace Conference_FCL
{
    public class JsonTool
    {
        private static JavaScriptSerializer serializer = new JavaScriptSerializer();

        public static string Serialize(Object model)
        {
            return serializer.Serialize(model);
        }

        public static void DeSerialize<T>(string paramaters, out List<T> project_list)
        {
            Object project = new Object();
            // 使用list<object>作为中间参数传递
            project_list = new List<T>();

            // 反序列化之后参数格式 一个对象中包含多组键值对 的形式
            project = serializer.Deserialize<List<T>>(paramaters);

            // 拆分后放到list<object>，然后向下传递
            IEnumerable<T> P = project as IEnumerable<T>;
            foreach (var item in P)
            {
                project_list.Add(item);
            }
        }

        /// <summary>    
        /// 将Json序列化的时间由/Date(1294499956278+0800)转为字符串    
        /// </summary>    
        public static string ConvertJsonDateToDateString(Match m)
        {
            string result = string.Empty;
            DateTime dt = new DateTime(1970, 1, 1);
            dt = dt.AddMilliseconds(long.Parse(m.Groups[1].Value));
            dt = dt.ToLocalTime();
            result = dt.ToString("yyyy-MM-dd");
            return result;
        }
    }
}
