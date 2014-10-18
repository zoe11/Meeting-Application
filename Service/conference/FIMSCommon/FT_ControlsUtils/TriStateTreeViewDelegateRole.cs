using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SysMGT_Model;

namespace FT_ControlsUtils
{
    public class TriStateTreeViewDelegateRole : TriStateTreeViewDelegate
    {
        private const string SqlTextTree = "select * from T_Role";
        private const int StartID = 0;
        private const string RoleID = "RoleID";
        private const string RoleParentID = "RoleParentID";
        private const string RoleName = "RoleName";
        private const int StartTime = 0;

        private const string UserID = "UserID";

        private DataTable _dt;
        private IList<RoleUser> _newRelationList;
        private string _sqlTextRelation = "SELECT * FROM T_UserRole where UserID={0}";
        private string _sqlText = "";
        private TreeViewExtDataSource<RoleInfo, RoleUser> _tvDataSource;

        internal override void InitTreeViewDataSource()
        {
            Tv.TriStateDelegate = this;
            _tvDataSource = new TreeViewExtDataSource<RoleInfo, RoleUser>();
            AssemblyDataSourceList();
        }

        private void AssemblyDataSourceList()
        {
            AssemblyEntityTree();
            if (!string.IsNullOrEmpty(Tv.RelationOwner))
            {
                AssemblyOldRelation();
            }
        }

        private void AssemblyOldRelation()
        {
            _sqlText = string.Format(_sqlTextRelation, "'" + Tv.RelationOwner + "'");
            _dt = Builder.GetDbTable(_sqlText);
            IList<RoleUser> rus = (from DataRow row in _dt.Rows select AssemblyRoleUser(row)).ToList();
            _tvDataSource.SetOldRelations(rus);
        }

        private void AssemblyEntityTree()
        {
            _dt = Builder.GetDbTable(SqlTextTree);
            IList<RoleInfo> roles = (from DataRow row in _dt.Rows select AssemblyRoleInfo(row)).ToList();
            _tvDataSource.SetEntities(roles);
        }

        private static RoleUser AssemblyRoleUser(DataRow row)
        {
            var ru = new RoleUser {UserID = Convert.ToString(row["UserID"]), RoleID = Convert.ToInt32(row["RoleID"])};
            return ru;
        }

        private static RoleInfo AssemblyRoleInfo(DataRow row)
        {
            var role = new RoleInfo
                {
                    RoleID = Convert.ToInt32(row["RoleID"]),
                    RoleName = Convert.ToString(row["RoleName"]),
                    RoleParentID = Convert.ToInt32(row["RoleParentID"]),
                    IsInnerRole = Convert.ToBoolean(row["IsInnerRole"]),
                    IsRoleGroup = Convert.ToBoolean(row["IsRoleGroup"]),
                    RoleDescription = Convert.ToString(row["RoleDescription"])
                };
            return role;
        }

        internal override void InitTreeView()
        {
            AssemblyTreeView();
        }

        private void AssemblyTreeView()
        {
            CreateTreeViewRecursive(Tv.Nodes, _tvDataSource.GetEntities(), StartID, StartTime);
            RefreshTreeViewNodeChoiceStatus(Tv.Nodes[0], _tvDataSource.GetOldRelations());
        }

        private bool IsNodeInRelation(RoleInfo p)
        {
            var query = _tvDataSource.GetOldRelations().FirstOrDefault(o => o.RoleID == p.RoleID);
            if (query != null)
                return true;
            else
                return false;
        }

        private void RefreshTreeViewNodeChoiceStatus(TreeNode treeNode, IList<RoleUser> iList)
        {
            var node = (TriStateTreeNode) treeNode;
            var role = (RoleInfo) node.Obj;
            if (node.Nodes.Count == 0)
            {
                Tv.SetTreeNodeStatus(node, IsNodeInRelation(role) ? CheckState.Checked : CheckState.Unchecked);
            }
            else
            {
                foreach (TreeNode child in node.Nodes)
                {
                    RefreshTreeViewNodeChoiceStatus(child, iList);
                }

                int halfCount = 0;
                int fullCount = 0;
                int notCount = 0;
                foreach (TreeNode child in node.Nodes)
                {
                    if (Tv.GetTreeNodeStatus((TriStateTreeNode) child) == CheckState.Unchecked)
                    {
                        notCount++;
                    }
                    else if (Tv.GetTreeNodeStatus((TriStateTreeNode) child) == CheckState.Indeterminate)
                    {
                        halfCount++;
                    }
                    else if (Tv.GetTreeNodeStatus((TriStateTreeNode) child) == CheckState.Checked)
                    {
                        fullCount++;
                    }
                }
                if (node.Nodes.Count == notCount)
                {
                    Tv.SetTreeNodeStatus(node, CheckState.Unchecked);
                }
                else if (node.Nodes.Count == fullCount)
                {
                    Tv.SetTreeNodeStatus(node, CheckState.Checked);
                }
                else
                {
                    Tv.SetTreeNodeStatus(node, CheckState.Indeterminate);
                }
            }
        }

        private void CreateTreeViewRecursive(TreeNodeCollection nodes, IList<RoleInfo> dataSource, int startID,
                                             int startTime)
        {
            IList<RoleInfo> list;
            if (startTime == 0)
            {
                list = dataSource.Where(o => o.RoleID == startID).ToList();
            }
            else
            {
                list = dataSource.Where(o => o.RoleParentID == startID).ToList();
            }

            foreach (RoleInfo obj in list) //递归循环查询出数据
            {
                TriStateTreeNode node = AssmblyNodeByObject(obj);
                if (Tv.CheckBoxes)
                {
                    node.CheckboxVisible = true;
                }
                if (obj.IsRoleGroup)
                {
                    node.IsContainer = true;
                    node.SelectedImageIndex = 1;
                    node.ImageIndex = 1;
                }
                startTime++;
                if (obj.RoleID != startID && startTime > 0)
                {
                    nodes.Add(node); //加入节点
                    CreateTreeViewRecursive(node.Nodes, dataSource, obj.RoleID, startTime);
                }
                if (startTime == 1)
                {
                    nodes.Add(node); //加入节点
                    CreateTreeViewRecursive(node.Nodes, dataSource, obj.RoleID, startTime);
                }
            }
        }

        internal override object AssmblyNewRelationObjectByNode(TriStateTreeNode tNode)
        {
            var ru = new RoleUser {RoleID = ((RoleInfo) tNode.Obj).RoleID, UserID = Tv.RelationOwner};
            return ru;
        }

        internal override TriStateTreeNode AssmblyNodeByObject(object obj)
        {
            var node = new TriStateTreeNode
                {
                    Text = ((RoleInfo) obj).RoleName,
                    ID = Convert.ToString(((RoleInfo) obj).RoleID),
                    Obj = obj,
                    SelectedImageIndex = 0,
                    ImageIndex = 0
                };
            return node;
        }

        public override object GetNewRelations()
        {
            _newRelationList = new List<RoleUser>();
            var node = (TriStateTreeNode) Tv.Nodes[0];
            GetNewRelationsRecursive(node);
            return _newRelationList;
        }

        private void GetNewRelationsRecursive(TriStateTreeNode node)
        {
            if (node.Nodes.Count == 0)
            {
                var role = (RoleInfo) node.Obj;
               // if (!role.IsInnerRole)
              //  {
                    CheckState curNodeSatus = Tv.GetTreeNodeStatus(node);
                    if (curNodeSatus == CheckState.Checked)
                    {
                        var ru = (RoleUser) AssmblyNewRelationObjectByNode(node);
                        _newRelationList.Add(ru);
                    }
              //  }
            }
            else
            {
                foreach (TriStateTreeNode child in node.Nodes)
                {
                    GetNewRelationsRecursive(child);
                }
            }
        }

        public override void AddTriStateNode(TriStateTreeNode parentNode, object currentObj)
        {
            RoleInfo role = currentObj as RoleInfo;
            if (role == null) return;
            var currentNode = new TriStateTreeNode
                {
                    ID = role.RoleID.ToString(),
                    Name = role.RoleName,
                    Text = role.RoleName,
                    Obj = role,
                    IsContainer = role.IsRoleGroup ? true : false,
                    CheckboxVisible = Tv.CheckBoxes ? true : false,
                    ImageIndex = role.IsRoleGroup ? 1 : 0,
                    SelectedImageIndex = role.IsRoleGroup ? 1 : 0,
                };
            parentNode.Nodes.Add(currentNode);
            _tvDataSource.AddEntity(role);
        }

        public override void UpdateTriStateNode(TriStateTreeNode currentNode, object currentObj)
        {
            RoleInfo role = currentObj as RoleInfo;
            if (role == null) return;
            RoleInfo oldRole = currentNode.Obj as RoleInfo;

            var newNode = new TriStateTreeNode
            {
                ID = role.RoleID.ToString(),
                Name = role.RoleName,
                Text = role.RoleName,
                Obj = role,
                IsContainer = role.IsRoleGroup ? true : false,
                CheckboxVisible = Tv.CheckBoxes ? true : false,
                ImageIndex = role.IsRoleGroup ? 1 : 0,
                SelectedImageIndex = role.IsRoleGroup ? 1 : 0,
            };
            var parentNode = currentNode.Parent;
            int index = parentNode.Nodes.IndexOf(currentNode);
            parentNode.Nodes.Remove(currentNode);
            parentNode.Nodes.Insert(index, newNode);

            _tvDataSource.ModifyEntity(oldRole, role);
        }

        public override void DeleteTriStateNode(TriStateTreeNode currentNode)
        {
            //throw new NotImplementedException();

            if (currentNode == null) return;
            var parentNode = currentNode.Parent;
            if (parentNode == null) return;
            parentNode.Nodes.Remove(currentNode);

            _tvDataSource.DeleteEntity(currentNode.Obj as RoleInfo);
        }
    }
}