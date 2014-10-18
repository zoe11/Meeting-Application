namespace FT_ControlsUtils
{
    partial class RoleDetails
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_ParentRoleID = new System.Windows.Forms.Label();
            this.cb_IsRoleGroup = new System.Windows.Forms.CheckBox();
            this.lbl_RoleDescription = new System.Windows.Forms.Label();
            this.lbl_RoleID = new System.Windows.Forms.Label();
            this.lbl_RoleName = new System.Windows.Forms.Label();
            this.lbl_IsInnerRole = new System.Windows.Forms.Label();
            this.cb_IsInnerRole = new System.Windows.Forms.CheckBox();
            this.lbl_IsRoleGroup = new System.Windows.Forms.Label();
            this.tb_RoleDescription = new System.Windows.Forms.TextBox();
            this.tb_ParentRoleID = new System.Windows.Forms.TextBox();
            this.tb_RoleName = new System.Windows.Forms.TextBox();
            this.tb_RoleID = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_ParentRoleID);
            this.groupBox1.Controls.Add(this.cb_IsRoleGroup);
            this.groupBox1.Controls.Add(this.lbl_RoleDescription);
            this.groupBox1.Controls.Add(this.lbl_RoleID);
            this.groupBox1.Controls.Add(this.lbl_RoleName);
            this.groupBox1.Controls.Add(this.lbl_IsInnerRole);
            this.groupBox1.Controls.Add(this.cb_IsInnerRole);
            this.groupBox1.Controls.Add(this.lbl_IsRoleGroup);
            this.groupBox1.Controls.Add(this.tb_RoleDescription);
            this.groupBox1.Controls.Add(this.tb_ParentRoleID);
            this.groupBox1.Controls.Add(this.tb_RoleName);
            this.groupBox1.Controls.Add(this.tb_RoleID);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 320);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "角色详细信息";
            // 
            // lbl_ParentRoleID
            // 
            this.lbl_ParentRoleID.AutoSize = true;
            this.lbl_ParentRoleID.Location = new System.Drawing.Point(32, 238);
            this.lbl_ParentRoleID.Name = "lbl_ParentRoleID";
            this.lbl_ParentRoleID.Size = new System.Drawing.Size(53, 12);
            this.lbl_ParentRoleID.TabIndex = 21;
            this.lbl_ParentRoleID.Text = "父角色ID";
            this.lbl_ParentRoleID.Visible = false;
            // 
            // cb_IsRoleGroup
            // 
            this.cb_IsRoleGroup.AutoSize = true;
            this.cb_IsRoleGroup.Enabled = false;
            this.cb_IsRoleGroup.Location = new System.Drawing.Point(200, 68);
            this.cb_IsRoleGroup.Name = "cb_IsRoleGroup";
            this.cb_IsRoleGroup.Size = new System.Drawing.Size(15, 14);
            this.cb_IsRoleGroup.TabIndex = 32;
            this.cb_IsRoleGroup.UseVisualStyleBackColor = true;
            // 
            // lbl_RoleDescription
            // 
            this.lbl_RoleDescription.AutoSize = true;
            this.lbl_RoleDescription.Location = new System.Drawing.Point(32, 100);
            this.lbl_RoleDescription.Name = "lbl_RoleDescription";
            this.lbl_RoleDescription.Size = new System.Drawing.Size(53, 12);
            this.lbl_RoleDescription.TabIndex = 29;
            this.lbl_RoleDescription.Text = "角色描述";
            // 
            // lbl_RoleID
            // 
            this.lbl_RoleID.AutoSize = true;
            this.lbl_RoleID.Location = new System.Drawing.Point(32, 168);
            this.lbl_RoleID.Name = "lbl_RoleID";
            this.lbl_RoleID.Size = new System.Drawing.Size(41, 12);
            this.lbl_RoleID.TabIndex = 22;
            this.lbl_RoleID.Text = "角色ID";
            this.lbl_RoleID.Visible = false;
            // 
            // lbl_RoleName
            // 
            this.lbl_RoleName.AutoSize = true;
            this.lbl_RoleName.Location = new System.Drawing.Point(30, 32);
            this.lbl_RoleName.Name = "lbl_RoleName";
            this.lbl_RoleName.Size = new System.Drawing.Size(53, 12);
            this.lbl_RoleName.TabIndex = 23;
            this.lbl_RoleName.Text = "角色名称";
            // 
            // lbl_IsInnerRole
            // 
            this.lbl_IsInnerRole.AutoSize = true;
            this.lbl_IsInnerRole.Location = new System.Drawing.Point(32, 68);
            this.lbl_IsInnerRole.Name = "lbl_IsInnerRole";
            this.lbl_IsInnerRole.Size = new System.Drawing.Size(53, 12);
            this.lbl_IsInnerRole.TabIndex = 24;
            this.lbl_IsInnerRole.Text = "内置角色";
            // 
            // cb_IsInnerRole
            // 
            this.cb_IsInnerRole.AutoSize = true;
            this.cb_IsInnerRole.Enabled = false;
            this.cb_IsInnerRole.Location = new System.Drawing.Point(94, 68);
            this.cb_IsInnerRole.Margin = new System.Windows.Forms.Padding(6, 15, 3, 3);
            this.cb_IsInnerRole.Name = "cb_IsInnerRole";
            this.cb_IsInnerRole.Size = new System.Drawing.Size(15, 14);
            this.cb_IsInnerRole.TabIndex = 31;
            this.cb_IsInnerRole.UseVisualStyleBackColor = true;
            // 
            // lbl_IsRoleGroup
            // 
            this.lbl_IsRoleGroup.AutoSize = true;
            this.lbl_IsRoleGroup.Location = new System.Drawing.Point(153, 68);
            this.lbl_IsRoleGroup.Name = "lbl_IsRoleGroup";
            this.lbl_IsRoleGroup.Size = new System.Drawing.Size(41, 12);
            this.lbl_IsRoleGroup.TabIndex = 28;
            this.lbl_IsRoleGroup.Text = "角色组";
            // 
            // tb_RoleDescription
            // 
            this.tb_RoleDescription.Location = new System.Drawing.Point(92, 97);
            this.tb_RoleDescription.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.tb_RoleDescription.Multiline = true;
            this.tb_RoleDescription.Name = "tb_RoleDescription";
            this.tb_RoleDescription.ReadOnly = true;
            this.tb_RoleDescription.Size = new System.Drawing.Size(185, 138);
            this.tb_RoleDescription.TabIndex = 30;
            // 
            // tb_ParentRoleID
            // 
            this.tb_ParentRoleID.Location = new System.Drawing.Point(58, 183);
            this.tb_ParentRoleID.Name = "tb_ParentRoleID";
            this.tb_ParentRoleID.ReadOnly = true;
            this.tb_ParentRoleID.Size = new System.Drawing.Size(15, 21);
            this.tb_ParentRoleID.TabIndex = 25;
            this.tb_ParentRoleID.Visible = false;
            // 
            // tb_RoleName
            // 
            this.tb_RoleName.Location = new System.Drawing.Point(92, 29);
            this.tb_RoleName.Margin = new System.Windows.Forms.Padding(6, 12, 3, 3);
            this.tb_RoleName.Name = "tb_RoleName";
            this.tb_RoleName.ReadOnly = true;
            this.tb_RoleName.Size = new System.Drawing.Size(185, 21);
            this.tb_RoleName.TabIndex = 27;
            // 
            // tb_RoleID
            // 
            this.tb_RoleID.Location = new System.Drawing.Point(34, 183);
            this.tb_RoleID.Name = "tb_RoleID";
            this.tb_RoleID.ReadOnly = true;
            this.tb_RoleID.Size = new System.Drawing.Size(15, 21);
            this.tb_RoleID.TabIndex = 26;
            this.tb_RoleID.Visible = false;
            // 
            // RoleDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "RoleDetails";
            this.Size = new System.Drawing.Size(315, 320);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_ParentRoleID;
        private System.Windows.Forms.CheckBox cb_IsRoleGroup;
        private System.Windows.Forms.Label lbl_RoleDescription;
        private System.Windows.Forms.Label lbl_RoleID;
        private System.Windows.Forms.Label lbl_RoleName;
        private System.Windows.Forms.Label lbl_IsInnerRole;
        private System.Windows.Forms.CheckBox cb_IsInnerRole;
        private System.Windows.Forms.Label lbl_IsRoleGroup;
        private System.Windows.Forms.TextBox tb_RoleDescription;
        private System.Windows.Forms.TextBox tb_ParentRoleID;
        private System.Windows.Forms.TextBox tb_RoleName;
        private System.Windows.Forms.TextBox tb_RoleID;


    }
}
