using System.Windows.Forms;
using SysMGT_Model;

namespace FT_ControlsUtils
{
    public partial class RoleDetails : UserControl
    {
        public RoleDetails()
        {
            InitializeComponent();
        }

        public void bindRoleModel(RoleInfo role)
        {
            tb_ParentRoleID.Text = role.RoleParentID.ToString();
            tb_RoleID.Text = role.RoleID.ToString();
            tb_RoleName.Text = role.RoleName;
            tb_RoleDescription.Text = role.RoleDescription;
            cb_IsInnerRole.Checked = role.IsInnerRole;
            cb_IsRoleGroup.Checked = role.IsRoleGroup;
        }
    }
}
