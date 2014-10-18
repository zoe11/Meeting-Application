using System.IO;
using System.Configuration;

namespace FT_ENV
{
    public partial class FTEnv
    { //test
        public static readonly string FTPADDRESS = GetDecryptStr("ftpserver");
        public static readonly string FTPUSER = GetDecryptStr("ftpuser");
        public static readonly string FTPPASSWORD = GetDecryptStr("ftppwd");

        //public static readonly string FTPADDRESS = "ftp://210.42.151.22:21/";
        //public static readonly string FTPUSER = "FTAdmin";
        //public static readonly string FTPPASSWORD = "FT@ftp123";

        #region 飞特报表服务器
        //public static readonly string REPORTSERVER_ADDRESS = "http://210.42.151.55/ReportServer";
        //public static readonly string REPORTSERVER_USER = "repftuser";
        //public static readonly string REPORTSERVER_PASSWORD = "FT@user507";
        #endregion
        #region 锦泰报表服务器
        //public static readonly string REPORTSERVER_ADDRESS = "http://192.168.1.239/ReportServer";
        //public static readonly string REPORTSERVER_USER = "ftrepadmin";
        //public static readonly string REPORTSERVER_PASSWORD = "rep@jtadmin888";
        #endregion

        #region 46报表服务器
        //public static readonly string REPORTSERVER_ADDRESS = "http://210.42.151.46/ReportServer";
        //public static readonly string REPORTSERVER_USER = "Administrator";
        //public static readonly string REPORTSERVER_PASSWORD = "zhongnan_rjjc_003";
        #endregion

        #region 天人报表服务器
        //public static readonly string REPORTSERVER_ADDRESS = "http://192.168.1.188/ReportServer";
        //public static readonly string REPORTSERVER_USER = "ftrepadmin";
        //public static readonly string REPORTSERVER_PASSWORD = "rep@admin888";
        #endregion

        public static readonly string REPORTSERVER_ADDRESS = GetDecryptStr("reportserver");
        public static readonly string REPORTSERVER_USER = GetDecryptStr("repuser");
        public static readonly string REPORTSERVER_PASSWORD = GetDecryptStr("reppwd");
        //public static readonly string REPORT_CLIENTURL = "http://192.168.1.188/ftreport/ClientPage.aspx?";
        //public static readonly string REPORT_SERVERURL = "http://192.168.1.188/ftreport/ServerPage.aspx?";

        public static string EXE_PATH = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        public static string EXE_ROOT_PATH = Directory.GetParent(EXE_PATH.Substring(0, EXE_PATH.Length - 1)) + "\\";

        public static string EXE_FILES_PATH = EXE_ROOT_PATH + "Files\\";
        public static string EXE_RES_PATH = EXE_ROOT_PATH + "Res\\";
        public static string EXE_DATA_PATH = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData) + "\\FIMS";
        public static string EXE_LOG_PATH = EXE_DATA_PATH +"\\Log\\";

        public static string EXE_SKIN = "New";
        public static string EXE_SKIN_PATH = EXE_RES_PATH + "Skin" + "\\" + EXE_SKIN + "\\";

        public static string EXE_IMG_PATH = EXE_SKIN_PATH + "Images" + "\\";

        public static string EXE_BACKGROUND = "Backgroud";
        public static string EXE_BACKGROUND_PATH = EXE_IMG_PATH + EXE_BACKGROUND + "\\";

        public static string EXE_ICON = "Icon";
        public static string EXE_ICON_PATH = EXE_IMG_PATH + EXE_ICON + "\\";

        public static string EXE_LOGIN = "Login";
        public static string EXE_LOGIN_PATH = EXE_IMG_PATH + EXE_LOGIN + "\\";

        public static string EXE_LOGIN2 = "Login2";
        public static string EXE_LOGIN_PATH2 = EXE_IMG_PATH + EXE_LOGIN2 + "\\";

        public static string EXE_LOGIN3 = "Login3";
        public static string EXE_LOGIN_PATH3 = EXE_IMG_PATH + EXE_LOGIN3 + "\\";

        public static string TREEICON = "TreeIcon";
        public static string EXE_TREEICON_PATH = EXE_IMG_PATH + TREEICON + "\\";

        public static string DBADDRESS = GetConnection("ftadmin");
        public static string USERCONN = GetConnection("ftuser");

         public static string GetConnection(string key)
         {
             string server = DecryptHelper.Decrypt(ConfigurationManager.AppSettings["server"]);
             string db = DecryptHelper.Decrypt(ConfigurationManager.AppSettings["db"]);
             string user = DecryptHelper.Decrypt(ConfigurationManager.AppSettings[key]);
             string conn = "Data Source=" + server + ";Initial Catalog=" + db + ";Persist Security Info=True;" + user;
             
             //string conn = "Data Source=" + server + "\\FT;Initial Catalog=" + db + ";Persist Security Info=True;" + user;
             //string conn = "Data Source=.;Initial Catalog=FT;Integrated Security=True";
             
             return conn;
         }

         public static string GetDecryptStr(string key)
         {
             return DecryptHelper.Decrypt(ConfigurationManager.AppSettings[key]);
         }
         public static string GetDecryptBoolStr(string key)
         {
             string str = DecryptHelper.Decrypt(ConfigurationManager.AppSettings[key]);
             if (string.IsNullOrEmpty(str))
                 return "true";
             else
                 return DecryptHelper.Decrypt(ConfigurationManager.AppSettings[key]);
         }

    }
}