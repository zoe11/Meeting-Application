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
    public partial class LabelItem : Label
    {
        private bool isClicked;

        public string ParentIDText { get; set; }

        public string PicPathEnter { get; set; }

        public string PicPathLeave { get; set; }

        public int ID { get; set; }

        public bool IsClicked
        {
            get
            {
                return this.isClicked;
            }
            set
            {
                this.isClicked = value;
                if (this.isClicked)
                {
                    this.Image = Image.FromFile(this.PicPathEnter);
                    this.ForeColor = Color.Black;
                    this.Image = Image.FromFile(this.PicPathEnter);
                    this.BackColor = Color.Transparent;
                }
                else
                {
                    this.Image = Image.FromFile(this.PicPathLeave);
                    this.ForeColor = Color.White;
                    this.Image = Image.FromFile(this.PicPathLeave);
                    this.BackColor = Color.Transparent;
                }
            }
        }

        public LabelItem()
            : base()
        {

        }
    }
}
