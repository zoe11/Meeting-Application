using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FT_ControlsUtils
{
    public partial class RoleTree : UserControl
    {
        public RoleTree()
        {
            InitializeComponent();
        }

        private void RoleTree_Load(object sender, EventArgs e)
        {
            //TreeViewFactory.CreateTreeView("select * from T_Role order by RoleID", this.treeRoleExt.Nodes, "RoleParentID", "RoleID", "RoleName");

            initTreeViewExt();
        }

        public event TreeNodeMouseClickEventHandler AfterSelect;

        [DefaultValue("")]
        public string ZZSqlText { get; set; }
        [DefaultValue("")]
        public string ZZTableName { get; set; }
        [DefaultValue("")]
        public string ZZOrderBy { get; set; }
        [DefaultValue("")]
        public string ZZParentID { get; set; }
        [DefaultValue("")]
        public string ZZChildID { get; set; }
        [DefaultValue("")]
        public string ZZChildName { get; set; }
        [DefaultValue(false)]
        public bool ZZIsCanCheck { get; set; }

        private string setSqlText()
        {
            string sqlText = "";
            if (string.IsNullOrEmpty(ZZSqlText))
            {
                if (!string.IsNullOrEmpty(ZZTableName) && !string.IsNullOrEmpty(ZZOrderBy))
                {
                    sqlText = "select * from " + ZZTableName + " order by " + ZZOrderBy;
                    //MessageBox.Show("");
                }
                else if (!string.IsNullOrEmpty(ZZTableName))
                {
                    sqlText = "select * from " + ZZTableName;
                }
                else
                {
                    MessageBox.Show("TreeViewExt控件属性填写有误");
                }
            }
            return sqlText;
        }

        public void initTreeViewExt()
        {
            if (string.IsNullOrEmpty(ZZSqlText))
            {
                string sqlText = setSqlText();
                if (!"".Equals(sqlText))
                {
                    TreeViewFactory.CreateTreeView(sqlText, this.treeRoleExt.Nodes, ZZParentID, ZZChildID, ZZChildName);
                }
            }
            else
            {
                TreeViewFactory.CreateTreeView(ZZSqlText, this.treeRoleExt.Nodes, ZZParentID, ZZChildID, ZZChildName);
            }
        }
    }
}
