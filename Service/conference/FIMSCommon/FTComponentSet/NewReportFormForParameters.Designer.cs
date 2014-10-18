namespace FTComponentSet
{
    partial class NewReportFormForParameters
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxFT2 = new FTComponentSet.GroupBoxFT();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBoxFT1 = new FTComponentSet.GroupBoxFT();
            this.groupBoxFT2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFT2
            // 
            this.groupBoxFT2.Controls.Add(this.reportViewer1);
            this.groupBoxFT2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFT2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.groupBoxFT2.Location = new System.Drawing.Point(0, 104);
            this.groupBoxFT2.Name = "groupBoxFT2";
            this.groupBoxFT2.Size = new System.Drawing.Size(1008, 618);
            this.groupBoxFT2.TabIndex = 2;
            this.groupBoxFT2.TabStop = false;
            this.groupBoxFT2.Text = "报表区";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(3, 19);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1002, 596);
            this.reportViewer1.TabIndex = 0;
            // 
            // groupBoxFT1
            // 
            this.groupBoxFT1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxFT1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.groupBoxFT1.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFT1.Name = "groupBoxFT1";
            this.groupBoxFT1.Size = new System.Drawing.Size(1008, 104);
            this.groupBoxFT1.TabIndex = 1;
            this.groupBoxFT1.TabStop = false;
            this.groupBoxFT1.Text = "筛选区";
            // 
            // NewReportFormForParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1008, 722);
            this.ControlBox = true;
            this.Controls.Add(this.groupBoxFT2);
            this.Controls.Add(this.groupBoxFT1);
            this.IsControlBoxEnable = true;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "NewReportFormForParameters";
            this.Text = "报表调阅";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewReportFormForParameters_FormClosing);
            this.groupBoxFT2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private GroupBoxFT groupBoxFT1;
        private GroupBoxFT groupBoxFT2;
    }
}