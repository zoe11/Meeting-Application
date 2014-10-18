namespace FTComponentSet
{
    partial class ReportContainerDGV
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewFT1 = new FTComponentSet.DataGridViewFT();
            this.ReportNoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportModelColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonFT1 = new FTComponentSet.ButtonFT();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFT1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFT1
            // 
            this.dataGridViewFT1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightYellow;
            this.dataGridViewFT1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewFT1.AutoSizeNumber = 5;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(104)))), ((int)(((byte)(112)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFT1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewFT1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFT1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReportNoColumn,
            this.ReportNameColumn,
            this.ReportModelColumn,
            this.ReportDescriptionColumn});
            this.dataGridViewFT1.DateColumnName = null;
            this.dataGridViewFT1.EnableHeadersVisualStyles = false;
            this.dataGridViewFT1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dataGridViewFT1.IsFirstRowDisEnable = true;
            this.dataGridViewFT1.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewFT1.Name = "dataGridViewFT1";
            this.dataGridViewFT1.ReadOnly = true;
            this.dataGridViewFT1.RowHeadersVisible = false;
            this.dataGridViewFT1.RowTemplate.Height = 23;
            this.dataGridViewFT1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFT1.Size = new System.Drawing.Size(882, 417);
            this.dataGridViewFT1.TabIndex = 0;
            this.dataGridViewFT1.TimeColumnName = null;
            this.dataGridViewFT1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewFT1_CellMouseDoubleClick);
            this.dataGridViewFT1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewFT1_DataBindingComplete);
            // 
            // ReportNoColumn
            // 
            this.ReportNoColumn.DataPropertyName = "ReportNo";
            this.ReportNoColumn.HeaderText = "编号";
            this.ReportNoColumn.Name = "ReportNoColumn";
            this.ReportNoColumn.ReadOnly = true;
            this.ReportNoColumn.Width = 40;
            // 
            // ReportNameColumn
            // 
            this.ReportNameColumn.DataPropertyName = "ReportName";
            this.ReportNameColumn.HeaderText = "报表名称";
            this.ReportNameColumn.Name = "ReportNameColumn";
            this.ReportNameColumn.ReadOnly = true;
            // 
            // ReportModelColumn
            // 
            this.ReportModelColumn.DataPropertyName = "ReportModel";
            this.ReportModelColumn.HeaderText = "报表路径";
            this.ReportModelColumn.Name = "ReportModelColumn";
            this.ReportModelColumn.ReadOnly = true;
            this.ReportModelColumn.Visible = false;
            // 
            // ReportDescriptionColumn
            // 
            this.ReportDescriptionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ReportDescriptionColumn.DataPropertyName = "ReportDescription";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.ReportDescriptionColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.ReportDescriptionColumn.HeaderText = "报表描述";
            this.ReportDescriptionColumn.Name = "ReportDescriptionColumn";
            this.ReportDescriptionColumn.ReadOnly = true;
            // 
            // buttonFT1
            // 
            this.buttonFT1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(161)))), ((int)(((byte)(242)))));
            this.buttonFT1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonFT1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.buttonFT1.ForeColor = System.Drawing.Color.White;
            this.buttonFT1.Location = new System.Drawing.Point(400, 448);
            this.buttonFT1.MyShowBtnMode = FTComponentSet.ButtonFT.ShowBtnMode.Cancel;
            this.buttonFT1.Name = "buttonFT1";
            this.buttonFT1.Size = new System.Drawing.Size(75, 23);
            this.buttonFT1.TabIndex = 1;
            this.buttonFT1.Text = "关 闭";
            this.buttonFT1.UseVisualStyleBackColor = false;
            this.buttonFT1.Click += new System.EventHandler(this.buttonFT1_Click);
            // 
            // ReportContainerDGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonFT1);
            this.Controls.Add(this.dataGridViewFT1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ReportContainerDGV";
            this.Size = new System.Drawing.Size(888, 484);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFT1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridViewFT dataGridViewFT1;
        private ButtonFT buttonFT1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportNoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportModelColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportDescriptionColumn;
    }
}
