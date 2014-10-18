using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FTComponentSet
{
    public class ButtonFT :Button
    {
        public enum ShowBtnMode
        { 
            Operate = 0,
            Confirm = 1,
            Cancel = 2

        }
        private ShowBtnMode myShowBtnMode;
        public ShowBtnMode MyShowBtnMode
        {
            get
            {
                return myShowBtnMode;
            }
            set
            {
                myShowBtnMode = value;
                SetColors();
            }
        
        }
        public void SetColors()
        {
            switch (myShowBtnMode)
            { 
                case ShowBtnMode.Operate:
                    this.BackColor = Env_Const.buttonColorGreen;
                    this.ForeColor = Color.White;
                    break;
                case ShowBtnMode.Confirm:
                    this.BackColor = Color.LightSlateGray;
                    this.ForeColor = Color.White;
                    break;
                default:
                    this.BackColor = Env_Const.buttonColorBlue;
                    this.ForeColor = Color.White;
                    break;
               
                
            }
        
        }


        public ButtonFT()
            : base()
        {

            SkinController.SetFTButtonSkin(this);

        }
    }
}
