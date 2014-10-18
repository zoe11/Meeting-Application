using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FTComponentSet
{
   public class LabelFT : Label
    {
      // private Label _lblText;
      // public bool Switch = true;

       public LabelFT()
           : base()
       {
           SkinController.SetFTLabelSkin(this);
       }
       /**
       public void SetTextBounds(Control container)
       { 
            if(Switch)
            {
                _lblText = new Label
                    {
                        Text = "*",
                       // BackColor = Color.Transparent,
                        //ForeColor = Color.Transparent,
                 
                    };
                _lblText.SetBounds(this.Left,this.Top,this.Width,this.Height);
                container.Controls.Add(_lblText);
              
            }
       }
       */
    }
}
