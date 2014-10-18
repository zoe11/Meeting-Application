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
    public partial class ReportForm : FTForm
    {
        private WebBrowser webBrowser1;
        private Model4Client modelUrl;
        public ReportForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public new FormStartPosition StartPosition
        {
            get { return base.StartPosition; }
            set { base.StartPosition = value; }
        }

        public void IniteReportModel(Model4Client model4Report)
        {
            this.modelUrl = model4Report;
        }
        public new void Show()
        {
            //if (modelUrl != null)
            //{
            //    this.webBrowser1.Url = new Uri(modelUrl.ReportUrl);
            //}
            base.Show();
        }

        private void InitializeComponent()
        {
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1008, 730);
            this.webBrowser1.TabIndex = 0;
            // 
            // ReportForm
            // 
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.webBrowser1);
            this.Name = "ReportForm";
            this.ResumeLayout(false);

        }
    }
}
