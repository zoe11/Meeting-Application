namespace FT_ControlsUtils
{
    partial class RoleTree
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
            this.treeRoleExt = new TreeViewExt();
            this.SuspendLayout();
            // 
            // treeRoleExt
            // 
            this.treeRoleExt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeRoleExt.Location = new System.Drawing.Point(0, 0);
            this.treeRoleExt.Name = "treeRoleExt";
            this.treeRoleExt.Size = new System.Drawing.Size(213, 279);
            this.treeRoleExt.TabIndex = 0;
            //this.treeRoleExt.ZZChildID = "RoleID";
            //this.treeRoleExt.ZZChildName = "RoleName";
            //this.treeRoleExt.ZZOrderBy = "RoleID";
            //this.treeRoleExt.ZZParentID = "RoleParentID";
            //this.treeRoleExt.ZZSqlText = null;
            //this.treeRoleExt.ZZTableName = "T_Role";
            // 
            // RoleTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeRoleExt);
            this.Name = "RoleTree";
            this.Size = new System.Drawing.Size(213, 279);
            this.Load += new System.EventHandler(this.RoleTree_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private TreeViewExt treeRoleExt;


    }
}
