using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using FT_ControlsUtils;
using System.Windows.Forms;

namespace FTComponentSet
{
    public partial class PdfFormFT : FTForm
    {
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();

        private string _pdfPath;
        //public FormStartPosition StartPosition
        //{
        //    get { return base.StartPosition; }
        //    set { base.StartPosition = value; }
        //}
        //public void Show()
        //{
        //    base.Show();
        //}
        public PdfFormFT(string pdfPath)
        {
            //Form f = new Form();
            this.StartPosition = FormStartPosition.CenterScreen;
            this._pdfPath = pdfPath;
            InitializeComponent();
            loadFile();
        }
        private void loadFile()
        {
            this.axAcroPDF1.LoadFile(_pdfPath);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfFormFT));
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.SuspendLayout();
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(0, 0);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(1008, 722);
            this.axAcroPDF1.TabIndex = 0;
            // 
            // PdfFormFT
            // 
            this.ClientSize = new System.Drawing.Size(1008, 722);
            this.Controls.Add(this.axAcroPDF1);
            this.Name = "PdfFormFT";
            this.IsControlBoxEnable = true;
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.ResumeLayout(false);
            //this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
