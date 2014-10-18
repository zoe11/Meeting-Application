using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conference_BLL;
using Conference_Model;
using FT_ENV;

namespace Conference_FCL
{
    public class FCL_Conference
    {
        Conference_BLL.BLL_Conference bll = new Conference_BLL.BLL_Conference();

        String jsonReturn = string.Empty;
        Result Res = new Result();
        List<Object> jsonReturn_list = new List<Object>();

        public string GetUserInfo(string paramaters)
        {
            List<User> project_list;

            JsonTool.DeSerialize<User>(paramaters, out project_list);

            Res = bll.GetUserInfo(project_list.FirstOrDefault());
            jsonReturn = JsonTool.Serialize(Res);

            return jsonReturn;
        }
    }
}
