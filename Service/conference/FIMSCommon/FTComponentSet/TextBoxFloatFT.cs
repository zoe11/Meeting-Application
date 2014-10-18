using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace FTComponentSet
{
    public class TextBoxFloatFT : TextBox
    {
        private int decimalDigits = 2;
        public int DecimalDigits
        {
            get
            {
                return decimalDigits;
            }
            set
            {
                decimalDigits = value;
            }
        }
        public bool ShowLabel
        {
            get;
            set;
        }
        public Label lb = null;
        private readonly string _lbText = "*";
        public bool HasWrong { get; set; }
        public new bool ReadOnly
        {
            get { return base.ReadOnly; }
            set
            {
                base.ReadOnly = value;
                SetBackColor();
            }
        }
        private int selectPos = 0; 
        public TextBoxFloatFT() 
            : base() 
        {

            SkinController.SetFTTextBoxFloatSkin(this);
            this.TextChanged += new EventHandler(this.TextChage); 
            this.Leave += new EventHandler(this.FocusLeave);
            this.SizeChanged += new EventHandler(this.SizeChange);

            this.Text = "0";
        } 
        //焦点发生改变时 
        public void FocusLeave(object sender, System.EventArgs e) 
        { 
            if (this.Text != "") 
            { 
                this.Text = ToDBC(this.Text);

                if (!(new Regex(@"^(-?\d+)(\.\d+)?$")).IsMatch(this.Text)) 
                {
                    this.HasWrong = true;
                    MessageBox.Show("输入内容不合法！", "输入提示"); 
                    this.Focus();
                    
                }
                else
                {
                    try
                    {
                        if (float.Parse(this.Text) > float.MaxValue)
                        {
                            this.HasWrong = true;
                            MessageBox.Show("输入内容不合法！", "输入提示");
                            this.Focus();
                        }
                        else
                        {
                            this.HasWrong = false;
                        }
                    }
                    catch (Exception)
                    {
                        this.HasWrong = true;
                        MessageBox.Show("输入内容不合法！", "输入提示");
                        this.Focus();

                    }
                }
                
            }
            SetBackColor();
            SetDisplay();
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

        //内容发生改变时 
        public void TextChage(object sender, System.EventArgs e) 
        { 
            selectPos = this.SelectionStart; 
            if (this.Text != "") 
            {
                if (!(new Regex(@"^(-?\d+)(\.\d+)?$")).IsMatch(this.Text)) 
                {
                    this.HasWrong = true;
                    this.SelectionStart = selectPos; 
                } 
                else 
                {
                    this.HasWrong = false;
                    this.SelectionStart = selectPos; 
                }

            } 
            else 
            {
                this.HasWrong = false; 
            }
            SetBackColor();
        } 

        //全角转换成半角 
        public string ToDBC(string input) 
        { 
            char[] c = input.ToCharArray(); 
            for (int i = 0; i < c.Length; i++) 
            { 
                if (c[i] == 12288) 
                { 
                    c[i] = (char)32; 
                    continue; 
                } 
                if (c[i] > 65280 && c[i] < 65375) 
                    c[i] = (char)(c[i] - 65248); 
            } 
            return new string(c); 
        }

        void TextBoxFT_Resize(object sender, EventArgs e)
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

        //设置显示的小数位数
        public void SetDisplay()
        {
            try
            {
                //this.RightToLeft = RightToLeft.Yes;//靠右显示

                //显示的小数位数，默认值为2
                if (this.decimalDigits == 2)
                {
                    if (string.IsNullOrEmpty(this.Text))
                    {
                        this.Text = "0.00";
                    }
                    else
                    {
                        this.Text = string.Format("{0:F2}", double.Parse(this.Text));
                    }
                }
                else if (this.decimalDigits == 3)
                {
                    if (string.IsNullOrEmpty(this.Text))
                    {
                        this.Text = "0.000";
                    }
                    else
                    {
                        this.Text = string.Format("{0:F3}", double.Parse(this.Text));
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(this.Text))
                    {
                        this.Text = "0";
                    }
                }
            }
            catch (Exception)
            {
                this.HasWrong = true;
                //MessageBox.Show("输入有误，请重新输入！", "输入提示");
                //this.Text = "";
                this.Focus();
            }
        }


    }
}
