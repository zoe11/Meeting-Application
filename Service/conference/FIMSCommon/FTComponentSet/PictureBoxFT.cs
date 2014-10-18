using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FTComponentSet
{
    public class PictureBoxFT :PictureBox
    {
        public PictureBoxFT()
            : base()
        {
            SkinController.SetFTPictureBoxSkin(this);
        }
    }
}
