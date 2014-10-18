using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FTComponentSet
{
    public partial class PictureBoxMenuItem : PictureBox
    {
        private LabelItem _lblText;
        private const int TextHeight = 25;
        public string PicPathEnter { get; set; }
        public string PicPathLeave { get; set; }
        private readonly string _text;

        public bool Switch = true;

        public int ID
        {
            set
            {
                if (this._lblText != null)
                {
                    this._lblText.ID = value;
                }

            }
            get
            {
                return this._lblText.ID;
            }
        }

        public Font TextFont
        {
            set
            {
                if (Switch)
                {
                    _lblText.Font = value;
                }
            }
        }
        public Color TextColor
        {
            set
            {
                if (Switch)
                {
                    _lblText.BackColor = value;
                }
            }
        }

        public PictureBoxMenuItem()
            : base()
        {
        }
        public PictureBoxMenuItem(string name, string text, string picPathEnter, string picPathLeave, int ID)
            : base()
        {
            _lblText = new LabelItem();
            this.Image = Image.FromFile(picPathLeave);
            _lblText.PicPathEnter = picPathEnter;
            _lblText.PicPathLeave = picPathLeave;
            this.PicPathEnter = picPathEnter;
            this.PicPathLeave = picPathLeave;
            //this.BackColor = Color.Transparent;
            this.Name = name;
            this._text = text;
            this.ID = ID;
        }

        public void SetLabelClickFunc(EventHandler click)
        {
            this._lblText.Click += new EventHandler(click);
        }

        public void SetTextBounds(Control container)
        {
            if (Switch)
            {


                _lblText.Text = _text;
                _lblText.TextAlign = ContentAlignment.MiddleCenter;
                _lblText.BackColor = Color.Transparent;
                _lblText.ForeColor = Color.Transparent;

                _lblText.Image = Image.FromFile(this.PicPathLeave);
                //_lblText.SetBounds(this.Left, this.Top + this.Height, this.Width, TextHeight);
                //_lblText.SetBounds(this.Left+15, this.Top+5, this.Width-30, TextHeight);
                _lblText.SetBounds(this.Left, this.Top, this.Width, this.Height);
                container.Controls.Add(_lblText);
                _lblText.BringToFront();
                _lblText.MouseEnter += new EventHandler(_lblText_MouseEnter);
                _lblText.MouseLeave += new EventHandler(_lblText_MouseLeave);
            }
        }

        public void SetLabelSelectImg()
        {
            _lblText.Image = Image.FromFile(this.PicPathEnter);
        }

        void _lblText_MouseLeave(object sender, EventArgs e)
        {
            if (_lblText.IsClicked)
            {
                _lblText.Image = Image.FromFile(this.PicPathEnter);
                _lblText.ForeColor = Color.Black;
                this.Image = Image.FromFile(this.PicPathEnter);
                _lblText.BackColor = Color.Transparent;
            }
            else
            {
                _lblText.Image = Image.FromFile(this.PicPathLeave);
                _lblText.ForeColor = Color.White;
                this.Image = Image.FromFile(this.PicPathLeave);
                _lblText.BackColor = Color.Transparent;
            }

        }

        void _lblText_MouseEnter(object sender, EventArgs e)
        {
            _lblText.Image = Image.FromFile(this.PicPathEnter);
            _lblText.ForeColor = Color.Black;
            this.Image = Image.FromFile(this.PicPathEnter);
            _lblText.BackColor = Color.Transparent;
        }

        public void RefreshLabelBackColor()
        {
            _lblText.ResetBackColor();
            _lblText.BackColor = Color.Transparent;
        }
    }
}
