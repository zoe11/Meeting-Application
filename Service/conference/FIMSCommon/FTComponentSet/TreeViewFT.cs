﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FTComponentSet
{
    public class TreeViewFT :TreeView
    {
        public TreeViewFT()
            : base()
        {
            SkinController.SetFTTreeViewSkin(this);
        }
    }
}
