using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FTComponentSet
{
    public class RadioButtonFT :RadioButton
    {
        public RadioButtonFT()
            : base()
        {
            SkinController.SetFTRadioButtonSkin(this);
        
        }
    }
}
