using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FTComponentSet
{
    
        public class DateTimePickerFT : DateTimePicker
        {
            public bool ShowLabel { get; set; }

            public Label lb = null;
            private readonly string _lbText = "*";

            private bool isTimeNotDate = true;

            public bool IsTimeNotDate 
            {
                get
                {
                    return this.isTimeNotDate;
                }
                set
                {
                    this.isTimeNotDate = value;
                    if (this.Format == DateTimePickerFormat.Custom&&value)
                    {
                        this.CustomFormat = "yyyy-MM-dd HH:mm:ss";
                    }
                    if (this.Format == DateTimePickerFormat.Custom && !value)
                    {
                        this.CustomFormat = "yyyy-MM-dd";
                    }
                }
            }

            public DateTimePickerFT()
                : base()
            {
                SkinController.SetFTDateTimePickerSkin(this);
                this.SizeChanged += new EventHandler(this.SizeChange);
            }

            void DateTimePickerFT_Resize(object sender, EventArgs e)
            {
                SetPosition();
            }

            //设置"*"Lable 的位置
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

            private void SetPosition()
            {
                if (lb != null)
                {
                    this.lb.Left = this.Left + this.Width + 3;
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

            public new System.Windows.Forms.DateTimePickerFormat Format
            {

                get
                {
                    return base.Format;
                }
                set
                {
                    base.Format = value;
                    if (value == DateTimePickerFormat.Custom&&this.isTimeNotDate)
                    {
                        this.CustomFormat = "yyyy-MM-dd HH:mm:ss";
                    }
                    if (value == DateTimePickerFormat.Custom && !this.isTimeNotDate)
                    {
                        this.CustomFormat = "yyyy-MM-dd";
                    }

                }
            }
        }
    
}
