using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SysMGT_Model;

namespace FT_ControlsUtils
{
    public class TriStateTreeViewDelegateResource : TriStateTreeViewDelegate
    {
        private const string SqlTextTree = "select * from T_Resource";
        private const int StartID = 0;
        private const string ResourceID = "ResourceID";
        private const string ResParentID = "ResParentID";
        private const string ResourceName = "ResourceName";
        private const int StartTime = 0;

        private const string RoleID = "RoleID";

        private DataTable _dt;
        private IList<RoleResource> _newRelationList;
        private string _sqlTextChildren = "SELECT * FROM T_Resource where ResParentID={0}";
        private string _sqlText = "";
        private string _sqlTextRelation = "SELECT * FROM T_RoleResource where RoleID={0}";
        private TreeViewExtDataSource<ResourceInfo, RoleResource> _tvDataSource;

        internal override void InitTreeViewDataSource()
        {
            Tv.TriStateDelegate = this;
            _tvDataSource = new TreeViewExtDataSource<ResourceInfo, RoleResource>();
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
            //_sqlTextRelation += "'" + Tv.RelationOwner + "'";
            _sqlText = string.Format(_sqlTextRelation, Tv.RelationOwner);
            _dt = Builder.GetDbTable(_sqlText);
            IList<RoleResource> rus = (from DataRow row in _dt.Rows select AssemblyRoleResource(row)).ToList();
            _tvDataSource.SetOldRelations(rus);
        }

        private void AssemblyEntityTree()
        {
            _dt = Builder.GetDbTable(SqlTextTree);
            IList<ResourceInfo> resourceInfos = (from DataRow row in _dt.Rows select AssemblyResourceInfo(row)).ToList();
            _tvDataSource.SetEntities(resourceInfos);
        }

        private static RoleResource AssemblyRoleResource(DataRow row)
        {
            var roleResource = new RoleResource
                {
                    ResourceID = Convert.ToInt32(row["ResourceID"]),
                    RoleID = Convert.ToInt32(row["RoleID"]),
                    ResourceTypeID = Convert.ToChar(row["ResourceTypeID"])
                };
            return roleResource;
        }

        private static ResourceInfo AssemblyResourceInfo(DataRow row)
        {
            var resource = new ResourceInfo
                {
                    ResourceID = Convert.ToInt32(row["ResourceID"]),
                    ResourceName = Convert.ToString(row["ResourceName"]),
                    ResParentID = Convert.ToInt32(row["ResParentID"]),
                    ResDescription = Convert.ToString(row["ResDescription"]),
                    IsLinkResource = Convert.ToBoolean(row["IsLinkResource"]),
                    LinkResourceID = Convert.ToInt32(row["LinkResourceID"]),
                    RouteName = Convert.ToString(row["RouteName"]),
                    DisplayOrder = Convert.ToInt32(row["DisplayOrder"])
                };
            return resource;
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

        private bool IsNodeInRelation(ResourceInfo p)
        {
            RoleResource query = _tvDataSource.GetOldRelations().FirstOrDefault(o => o.ResourceID == p.ResourceID);
            return query != null;
        }

        private void RefreshTreeViewNodeChoiceStatus(TreeNode treeNode, IList<RoleResource> iList)
        {
            var node = (TriStateTreeNode) treeNode;
            var resourceInfo = (ResourceInfo) node.Obj;
            if (node.Nodes != null && node.Nodes.Count == 0)
            {
                Tv.SetTreeNodeStatus(node, IsNodeInRelation(resourceInfo) ? CheckState.Checked : CheckState.Unchecked);
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

        private void CreateTreeViewRecursive(TreeNodeCollection nodes, IList<ResourceInfo> dataSource, int startID,
                                             int startTime)
        {
            IList<ResourceInfo> list;
            list = startTime == 0 ? dataSource.Where(o => o.ResourceID == startID).ToList() : dataSource.Where(o => o.ResParentID == startID).ToList();

            foreach (ResourceInfo obj in list) //递归循环查询出数据
            {
                TriStateTreeNode node = AssmblyNodeByObject(obj);
                if (Tv.CheckBoxes)
                {
                    node.CheckboxVisible = true;
                }
                //_sqlText = String.Format(_sqlTextChildren, obj.ResParentID);原fzs代码
                _sqlText = String.Format(_sqlTextChildren, obj.ResourceID);
                DataTable children = Builder.GetDbTable(_sqlText);
                //判断是否有孩子节点
                if (children.Rows.Count != 0)
                {
                    node.IsContainer = true;
                    node.SelectedImageIndex = 1;
                    node.ImageIndex = 1;
                }
                startTime++;
                if (obj.ResourceID != startID && startTime > 0)
                {
                    nodes.Add(node); //加入节点
                    CreateTreeViewRecursive(node.Nodes, dataSource, obj.ResourceID, startTime);
                }
                if (startTime == 1)
                {
                    nodes.Add(node); //加入节点
                    CreateTreeViewRecursive(node.Nodes, dataSource, obj.ResourceID, startTime);
                }
            }
        }

        internal override object AssmblyNewRelationObjectByNode(TriStateTreeNode tNode)
        {
            var roleResource = new RoleResource
                {
                    ResourceID = ((ResourceInfo) tNode.Obj).ResourceID,
                    RoleID = Convert.ToInt32(Tv.RelationOwner)
                };
            return roleResource;
        }

        internal override TriStateTreeNode AssmblyNodeByObject(object obj)
        {
            var node = new TriStateTreeNode
                {
                    Text = ((ResourceInfo) obj).ResourceName,
                    ID = ((ResourceInfo) obj).ResourceID.ToString(),
                    Obj = obj,
                    SelectedImageIndex = 0,
                    ImageIndex = 0
                };
            return node;
        }

        public override object GetNewRelations()
        {
            _newRelationList = new List<RoleResource>();
            var node = (TriStateTreeNode) Tv.Nodes[0];
            GetNewRelationsRecursive(node);
            return _newRelationList;
        }

        private void GetNewRelationsRecursive(TriStateTreeNode node)
        {
            //if (node.Nodes.Count == 0)
            //{
            var role = (ResourceInfo) node.Obj;

            CheckState curNodeSatus = Tv.GetTreeNodeStatus(node);
            if (curNodeSatus == CheckState.Checked || curNodeSatus == CheckState.Indeterminate)
            {
                var ru = (RoleResource) AssmblyNewRelationObjectByNode(node);
                _newRelationList.Add(ru);
            }
            // }
            foreach (TriStateTreeNode child in node.Nodes)
            {
                GetNewRelationsRecursive(child);
            }
        }

        public override void AddTriStateNode(TriStateTreeNode parentNode, object currentObj)
        {
            ResourceInfo resource = currentObj as ResourceInfo;
            if (resource == null) return;
            var currentNode = new TriStateTreeNode
                {
                    ID = resource.ResourceID.ToString(),
                    Name = resource.ResourceName,
                    Text = resource.ResourceName,
                    Obj = resource,
                    IsContainer = false,
                    CheckboxVisible = Tv.CheckBoxes ? true : false,
                    ImageIndex = 0,
                    SelectedImageIndex = 0
                };
            parentNode.Nodes.Add(currentNode);
            parentNode.IsContainer = true;
            parentNode.ImageIndex = 1;
            parentNode.SelectedImageIndex = 1;
            _tvDataSource.AddEntity(resource);
        }

        public override void UpdateTriStateNode(TriStateTreeNode currentNode, object currentObj)
        {
            ResourceInfo resource = currentObj as ResourceInfo;
            if (resource == null) return;

            ResourceInfo oldResource = currentNode.Obj as ResourceInfo;

            var newNode = new TriStateTreeNode
            {
                ID = resource.ResourceID.ToString(),
                Name = resource.ResourceName,
                Text = resource.ResourceName,
                Obj = resource,
                IsContainer = false,
                CheckboxVisible = Tv.CheckBoxes ? true : false,
                ImageIndex = 0,
                SelectedImageIndex = 0
            };

            var parentNode = currentNode.Parent;
            if (parentNode == null) return;
            int index = parentNode.Nodes.IndexOf(currentNode);
            parentNode.Nodes.Remove(currentNode);
            parentNode.Nodes.Insert(index, newNode);

            _tvDataSource.ModifyEntity(oldResource, resource);
        }

        public override void DeleteTriStateNode(TriStateTreeNode currentNode)
        {
            //throw new NotImplementedException();
            if (currentNode == null) return;
            var parentNode = currentNode.Parent;
            if (parentNode == null) return;
            parentNode.Nodes.Remove(currentNode);

            _tvDataSource.DeleteEntity(currentNode.Obj as ResourceInfo);
        }
    }
}