using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FT_ControlsUtils;

namespace WindowsFormsApplication1
{
    public partial class ComboBoxTreeForm : Form
    {
        private TriStateTreeViewDelegateDepartment delegateBom = new TriStateTreeViewDelegateDepartment();
        public ComboBoxTreeForm()
        {
            InitializeComponent();
        }

        private void ComboBoxTreeForm_Load(object sender, EventArgs e)
        {
            //delegateBom.Tv = this.comboBoxTree1.TreeView;
            //delegateBom.Initial();
            this.triStateTreeView1.RelationOwner = "001";
            delegateBom.Tv = this.triStateTreeView1;
            delegateBom.Initial();
        }

        private void triStateTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TriStateTreeNode node = (TriStateTreeNode)e.Node;
        }
    }
}
