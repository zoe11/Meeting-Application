namespace WindowsFormsApplication1
{
    partial class ComboBoxTreeForm
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
            this.comboBoxTree1 = new FTComponentSet.ComboBoxTree();
            this.triStateTreeView1 = new FT_ControlsUtils.TriStateTreeView();
            this.SuspendLayout();
            // 
            // comboBoxTree1
            // 
            this.comboBoxTree1.AllowSelectParentNode = false;
            this.comboBoxTree1.Imagelist = null;
            this.comboBoxTree1.Location = new System.Drawing.Point(12, 12);
            this.comboBoxTree1.Name = "comboBoxTree1";
            this.comboBoxTree1.SelectedNode = null;
            this.comboBoxTree1.SelectedObj = null;
            this.comboBoxTree1.Size = new System.Drawing.Size(150, 24);
            this.comboBoxTree1.TabIndex = 0;
            // 
            // triStateTreeView1
            // 
            this.triStateTreeView1.CheckedImageIndex = -1;
            this.triStateTreeView1.IndeterminateImageIndex = -1;
            this.triStateTreeView1.IsCheckBoxReadOnly = false;
            this.triStateTreeView1.Location = new System.Drawing.Point(204, 12);
            this.triStateTreeView1.Name = "triStateTreeView1";
            this.triStateTreeView1.RelationOwner = null;
            this.triStateTreeView1.Size = new System.Drawing.Size(258, 204);
            this.triStateTreeView1.TabIndex = 1;
            this.triStateTreeView1.UncheckedImageIndex = -1;
            this.triStateTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.triStateTreeView1_AfterSelect);
            // 
            // ComboBoxTreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 262);
            this.Controls.Add(this.triStateTreeView1);
            this.Controls.Add(this.comboBoxTree1);
            this.Name = "ComboBoxTreeForm";
            this.Text = "ComboBoxTreeForm";
            this.Load += new System.EventHandler(this.ComboBoxTreeForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FTComponentSet.ComboBoxTree comboBoxTree1;
        private FT_ControlsUtils.TriStateTreeView triStateTreeView1;
    }
}