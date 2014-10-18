
namespace FT_ControlsUtils
{
    public class InitialTree
    {
        public static void initialRoleTree(TreeViewExt treeRole)
        {
            TreeViewFactory.CreateTreeView("select * from T_Role order by RoleID", treeRole.Nodes, "RoleParentID", "RoleID", "RoleName");
        }
        public static void initialResourceTree(TreeViewExt treeResource)
        {
            TreeViewFactory.CreateTreeView("select * from T_Resource order by ResourceID", treeResource.Nodes, "ResParentID", "ResourceID", "ResourceName");
        }
    }
}
