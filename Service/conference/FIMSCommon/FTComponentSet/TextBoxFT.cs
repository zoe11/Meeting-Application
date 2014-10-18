using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace FTComponentSet
{
    public class TextBoxFT:TextBox
    {
        private bool hasWrong = false;

        public bool ShowLabel { get; set; }
        public bool HasWrong 
        {
            get { return this.hasWrong; }
            set 
            { 
                hasWrong = value;
                SetBackColor();
            } 
        }

        public new bool Multiline
        {
            get
            {
                return base.Multiline;
            }
            set
            {
                base.Multiline = value;
            }
        }

        public new bool ReadOnly
        {
            get { return base.ReadOnly; }
            set
            {
                base.ReadOnly = value;
                SetBackColor();
            }
        }
        

        public  Label lb = null;
        private readonly string _lbText = "*";

        public TextBoxFT() :base()
        {
            SkinController.SetFTTextBoxSkin(this);
            this.SizeChanged += new EventHandler(this.SizeChange);
        }


        internal void SetBackColor()
        {
            this.BackColor = Color.White;
            if (base.ReadOnly)
            {
                this.BackColor = Color.LightGray;
                return;
            }
            if (HasWrong)
            {
                this.BackColor = Color.OrangeRed;
            }
        }

        public void SetLabelPosition(Control parentCtrl)
        {
            if (ShowLabel)
            {
                lb = new Label
                    {
                        Text = this._lbText,
                        TextAlign = ContentAlignment.MiddleCenter,
                        BackColor = Color.Transparent,
                        ForeColor = Color.Red

                    };

                lb.SetBounds(this.Left + this.Width, this.Top + 5, 10, 15);
                parentCtrl.Controls.Add(lb);
            }
            else
            {
                if (parentCtrl.Controls.Contains(lb))
                {
                    parentCtrl.Controls.Remove(lb);
                }
                lb = null;
            }
        }

        public void SizeChange(object sender, System.EventArgs e)
        {
            if (this.Width != Env_Const.tbWidth)
            {
                if (lb != null)
                {
                    this.lb.Left = this.Left + this.Width + 3;
                }

            }
        }
    }
}
