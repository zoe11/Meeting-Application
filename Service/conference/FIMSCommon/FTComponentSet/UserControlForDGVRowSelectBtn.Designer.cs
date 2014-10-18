using System.Windows.Forms;
namespace FTComponentSet
{
    partial class UserControlForDGVRowSelectBtn
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
            this.btnReverseSelected = new FTComponentSet.ButtonFT();
            this.btnSelectAll = new FTComponentSet.ButtonFT();
            this.SuspendLayout();
            // 
            // btnReverseSelected
            // 
            this.btnReverseSelected.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReverseSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(159)))), ((int)(((byte)(6)))));
            this.btnReverseSelected.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReverseSelected.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnReverseSelected.ForeColor = System.Drawing.Color.White;
            this.btnReverseSelected.Location = new System.Drawing.Point(82, 2);
            this.btnReverseSelected.MyShowBtnMode = FTComponentSet.ButtonFT.ShowBtnMode.Operate;
            this.btnReverseSelected.Name = "btnReverseSelected";
            this.btnReverseSelected.Size = new System.Drawing.Size(75, 23);
            this.btnReverseSelected.TabIndex = 1;
            this.btnReverseSelected.Text = "反 选";
            this.btnReverseSelected.UseVisualStyleBackColor = false;
            this.btnReverseSelected.Click += new System.EventHandler(this.btnReverseSelected_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(159)))), ((int)(((byte)(6)))));
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectAll.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnSelectAll.ForeColor = System.Drawing.Color.White;
            this.btnSelectAll.Location = new System.Drawing.Point(1, 2);
            this.btnSelectAll.MyShowBtnMode = FTComponentSet.ButtonFT.ShowBtnMode.Operate;
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 0;
            this.btnSelectAll.Text = "全 选";
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // UserControlForDGVRowSelectBtn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReverseSelected);
            this.Controls.Add(this.btnSelectAll);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "UserControlForDGVRowSelectBtn";
            this.Size = new System.Drawing.Size(159, 26);
            this.ResumeLayout(false);

        }

        #endregion

        private ButtonFT btnSelectAll;
        private ButtonFT btnReverseSelected;

    }
}
