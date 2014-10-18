namespace WindowsFormsApplication1
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBoxFT1 = new FTComponentSet.ComboBoxFT();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(341, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(29, 56);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(694, 204);
            this.textBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(341, 320);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(204, 370);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(357, 21);
            this.textBox2.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(296, 498);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 54);
            this.button3.TabIndex = 4;
            this.button3.Text = "附件下载";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(296, 585);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 54);
            this.button4.TabIndex = 5;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(416, 498);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(108, 54);
            this.button5.TabIndex = 6;
            this.button5.Text = "附件上传";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBoxFT1
            // 
            this.comboBoxFT1.Code = "";
            this.comboBoxFT1.DataMode = FTComponentSet.ComboBoxFTMode.Null;
            this.comboBoxFT1.DisplayColumn = "";
            this.comboBoxFT1.DistinctCol = null;
            this.comboBoxFT1.DistinctCols = null;
            this.comboBoxFT1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxFT1.DropDownWidth = 17;
            this.comboBoxFT1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.comboBoxFT1.FormattingEnabled = true;
            this.comboBoxFT1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.comboBoxFT1.IsDropDown = false;
            this.comboBoxFT1.IsHaveDataWhenNoData = true;
            this.comboBoxFT1.Location = new System.Drawing.Point(53, 310);
            this.comboBoxFT1.Name = "comboBoxFT1";
            this.comboBoxFT1.OrderBy = ((System.Collections.Generic.Dictionary<object, object>)(resources.GetObject("comboBoxFT1.OrderBy")));
            this.comboBoxFT1.ShowLabel = false;
            this.comboBoxFT1.Size = new System.Drawing.Size(185, 24);
            this.comboBoxFT1.TabIndex = 7;
            this.comboBoxFT1.TopNumber = 10;
            this.comboBoxFT1.ViewColumn = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 734);
            this.Controls.Add(this.comboBoxFT1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private FTComponentSet.ComboBoxFT comboBoxFT1;
    }
}

