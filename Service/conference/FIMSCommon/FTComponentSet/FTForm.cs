using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FTComponentSet
{
    public class FTForm : Form
    {
        private bool isControlEnable = false;
        public bool IsControlBoxEnable 
        {
            get
            {
                return this.isControlEnable;
            }
            set
            {
                this.isControlEnable = value;
                if (value)
                {
                    this.ControlBox = true;
                    this.MinimizeBox = true;
                    this.MaximizeBox = true;
                }
            }
        }
        public FTForm()
        {
            InitializeComponent();    
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FTForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FTForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }
    }
}
