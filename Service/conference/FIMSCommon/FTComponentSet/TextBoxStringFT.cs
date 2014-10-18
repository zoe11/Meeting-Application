using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace FTComponentSet
{
    //只能输入字符
    public class TextBoxStringFT:TextBox
    {
       private int selectPos = 0;
       public bool HasWrong { get; set; }
       public bool ShowLabel { get; set; }

        public  Label lb = null;
        private readonly string _lbText = "*";
        public new bool ReadOnly
        {
            get { return base.ReadOnly; }
            set
            {
                base.ReadOnly = value;
                SetBackColor();
            }
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
        public TextBoxStringFT() :base()
        {
            SkinController.SetFTTextBoxStringSkin(this);
            this.TextChanged += new EventHandler(this.TextChage);
            this.Leave += new EventHandler(this.FocusLeave);
            this.SizeChanged += new EventHandler(this.SizeChange);
        }
        //验证26个英文字母组成的字符串：^\w+$
        //焦点发生改变时 
        public void FocusLeave(object sender, System.EventArgs e)
        {
            if (this.Text != "")
            {
                this.Text = ToDBC(this.Text);
                if (!(new Regex(@"^[A-Za-z]+$")).IsMatch(this.Text))
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
            SetBackColor(); 
        }

        //内容发生改变时 
        public void TextChage(object sender, System.EventArgs e)
        {
            selectPos = this.SelectionStart;
            if (this.Text != "")
            {
                if (!(new Regex(@"^[A-Za-z]+$")).IsMatch(this.Text))
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
