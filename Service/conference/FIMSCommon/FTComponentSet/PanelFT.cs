using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FTComponentSet
{
    public class PanelFT:Panel
    {
        public PanelFT()
            : base()
        {
            SkinController.SetFTPanelSkin(this);
        }
    }
}
