using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
//using System.Web.Configuration;

namespace FTComponentSet
{
    public class Model4Report
    {
        public string ReportUrl { get; set; }
        public string ReportUser { get; set; }
        public string ReportPassword { get; set; }
        public string ReportPath { get; set; }

        public static Model4Report getInstance()
        {
            return createModel();
        }

        private static Model4Report createModel()
        {
            Model4Report model = new Model4Report();
            if (!bool.Parse(WebConfigurationManager.AppSettings["Release"]))
            {
                model.ReportUrl = WebConfigurationManager.AppSettings["ReportServerUrlDebug"];
                model.ReportUser = WebConfigurationManager.AppSettings["ReportServerUserDebug"];
                model.ReportPassword = WebConfigurationManager.AppSettings["ReportServerPwdDebug"];
            }
            else
            {
                model.ReportUrl = Crypt.Crypt.Decrypt(WebConfigurationManager.AppSettings["ReportServerUrl"]);
                model.ReportUser = Crypt.Crypt.Decrypt(WebConfigurationManager.AppSettings["ReportServerUser"]);
                model.ReportPassword = Crypt.Crypt.Decrypt( WebConfigurationManager.AppSettings["ReportServerPwd"]);
            }
            return model;
        }
    }
}