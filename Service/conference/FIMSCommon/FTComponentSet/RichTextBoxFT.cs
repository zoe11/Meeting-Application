using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FTComponentSet
{
    public class RichTextBoxFT :RichTextBox
    {
        public RichTextBoxFT()
            : base()
        {
            SkinController.SetFTRichTextBoxSkin(this);
        }
        public new bool ReadOnly
        {
            get { return base.ReadOnly; }
            set
            {
                base.ReadOnly = value;
                if (value)
                {
                    this.BackColor = Color.LightGray;
                }
            }
        }
    }
}
