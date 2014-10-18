using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FTComponentSet
{
    public partial class Env_Const
    {
        //划线的颜色
        public static readonly Color LineShapeColor = Color.FromArgb(157, 157, 157);

        //字体的颜色及大小
        public static readonly string fontStyle = "微软雅黑";
        public static readonly float fontSize = float.Parse("9");

        public static readonly Font textFont = new Font(fontStyle, fontSize);

        //Textbox 的宽 ，高
        public static readonly int tbWidth = 185;
        public static readonly int tbHeight = 21; 

        //Button 的 颜色
        public static readonly Color buttonColorGreen = Color.FromArgb(114, 159, 6);
        public static readonly Color buttonColorBlue = Color.FromArgb(80, 161, 242);



    }
}
