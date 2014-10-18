using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Conference_FCL;

namespace Conference_IFT
{
    /// <summary>
    /// IFT_Conference 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class IFT_Conference : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetUserInfo(string paramaters)
        {
            paramaters = paramaters.Replace(@"\", @"");

            // 初始化json返回数据
            String JsonReturn = null;

            // 调用FCL（数据转换层）
            FCL_Conference Conference_FCL = new FCL_Conference();
            JsonReturn = Conference_FCL.GetUserInfo(@paramaters);
            return JsonReturn;
        }

        [WebMethod]
        public string GetConferenceInfo()
        {
            return "Hello World";
        }

        [WebMethod]
        public string InsertConferenceInfo()
        {
            return "Hello World";
        }
    }
}
