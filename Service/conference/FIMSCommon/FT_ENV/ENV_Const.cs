using System.Drawing;

namespace FT_ENV
{
    //public enum AuditStatus
    //{
    //    UnDeal=-1,
    //    Pass=0,
    //    Modify=1,
    //    Deny=2
    //}

    public partial class FTEnv
    {
        #region 登录界面
        //登录form宽高
        public static readonly int LOGINFRM_WIDTH = 416;
        public static readonly int LOGINFRM_HEIGHT=269;

        //登录界面Form2
        public static readonly int LOGINFRM_WIDTH2 = 630;
        public static readonly int LOGINFRM_HEIGHT2 = 300;
        //logo宽高
        public static readonly int LOGO_WIDTH = 100;
        public static readonly int LOGO_HEIGHT=29;
        //登录Logo宽高
        public static readonly int LOGO_LOGIN_WIDTH = 83;
        public static readonly int LOGO__LOGIN_HEIGHT = 78;
        #endregion

        #region FTMain相关配置
        public static readonly int PBWIDTH=90;
        public static readonly int PBHEIGHT = 35;

        public static readonly int PBTHIRDWIDTH = 100;
        public static readonly int PBTHIRDHEIGHT = 60;

        public static readonly int PBX = 100;
        public static readonly int PBY = 50;


        public static readonly int PBXTHIRD = 0;
        public static readonly int PBYTHIRD = 10;

        public static readonly int PBLOGOSET_X = 98;
        public static readonly int PBLOGOSET_Y = 29;

        public static readonly int PBOFFSET_X = 92;
        public static readonly int PBOFFSET_Y = 45;
        public static readonly string PBTYPE=".png";

        public static readonly int PBLOGO_OFFSET_X = 92;
        public static readonly int PBLOGO_OFFSET_Y = 30;

        public static readonly int WINSTATECTRL_OFFSET = 20;

        public static readonly int MAINFRM_WIDTH=1024;
        public static readonly int MAINFRM_HEIGHT=768;

        public static readonly int SECONDMENU_HEIGHT = 97;
        public static readonly int STATUSBAR_HEIGHT = 24;
        public static readonly int THIRDMENU_WIDTH = 100;
        public static readonly int CONTENTTOP_HEIGHT = 6;
        public static readonly int CONTENTBOTTOM_HEIGHT = 6;
        public static readonly int CONTENTLEFT_WIDTH = 6;
        public static readonly int CONTENTRIGHT_WIDTH = 6;

        public static readonly int SCROLLBAR_WIDTH=18;

        //1024-92-13-13-1-1-18
        //1024-136--6-6-2-18
        public static readonly int CONTENT_WIDTH=888;

        public static readonly int PICTUREBOXMENUITEM_MAXCOUNT = 10;


        public static readonly Color  BACKGROUNDCOLOR=Color.FromArgb(226, 231, 234);
        //public static readonly Color  STATUSBARCOLOR=Color.FromArgb(162, 180, 192);
        public static readonly Color MAINCONTENTCOLOR = Color.FromArgb(255, 255, 255, 255);
        
        
        //系统中关于小数点后保留几位
        public static readonly int DecimalDigitsAmount = 2;//数量的2位
        public static readonly int DecimalDigitsMoney = 3;//金钱的3位
        public static readonly int DecimalDigitsBom = 4;//BOM用量的4位

        #endregion
    }
}
