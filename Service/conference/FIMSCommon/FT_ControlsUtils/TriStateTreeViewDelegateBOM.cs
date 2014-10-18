using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using EnmsMGT_Model;

namespace FT_ControlsUtils
{
    public class TriStateTreeViewDelegateBOM:TriStateTreeViewDelegate
    {
        private bool isTest = true;
        private IList<MaterialInfo> _materials = new List<MaterialInfo>();
        private string _sqlTextBOMGroup = "select * from T_BOMGroup Where BOMGroupName = {0}";
        //private string _sqlTextBOMGroup4IDVer = "select * from T_BOMGroup Where OriginMaterialID = {0} and OriginMaterialVersion = {1}";
        private string _sqlTextMaterial = "select * from T_Material Where MaterialID= {0} and MaterialVersion = {1}";
        private const int StartID = 0;
        private IList<BOMGroupInfo> _bomGroups;
        private IList<BOMInfo> _boms;
        private const int StartTime = 0;

        private DataTable _dt;
        private string _sqlTextBOM = "SELECT * FROM T_BOM where ParentMaterialID={0} AND ParentMaterialVersion={1}";
        private string _sqlText = "";
        private TreeViewExtDataSource<BOMGroupInfo,BOMInfo> _tvDataSource;
        private string auditCodeColumnName;

        public IList<MaterialInfo> Materials 
        { 
            get
            {
                return this._materials;
            }
        }

        public String AuditCodeColumnName 
        {
            get
            {
                if (String.IsNullOrEmpty(auditCodeColumnName))
                {
                    this.auditCodeColumnName = "ApproveStatusCode";
                }
                return this.auditCodeColumnName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    this.auditCodeColumnName = "ApproveStatusCode";
                }
                else
                {
                    this.auditCodeColumnName = value;
                }
            }
        }

        internal override void InitTreeViewDataSource()
        {
            if (isTest)
            {
                this._materials.Clear();
            }
            Tv.TriStateDelegate = this;
            this.Tv.IsCheckBoxReadOnly = true;
            _tvDataSource = new TreeViewExtDataSource<BOMGroupInfo,BOMInfo>();
            AssemblyDataSourceList();
        }

        private void AssemblyDataSourceList()
        {
            if (Tv.RelationOwner != null)
            {
                CreateBOMGroup();
                CreateBOMs();
            }
            
        }

        private void CreateBOMs()
        {
            _sqlText = string.Format(_sqlTextBOM, "'" + (this._tvDataSource.GetEntities())[0].OriginMaterialID + "'", "'" + (this._tvDataSource.GetEntities())[0].OriginMaterialVersion + "'");
            _dt = Builder.GetDbTable(_sqlText);
            _boms = (from DataRow row in _dt.Rows select AssemblyBOMInfo(row)).ToList();

            _tvDataSource.SetOldRelations(_boms);
        }

        private void CreateBOMGroup()
        {
            _sqlText = string.Format(_sqlTextBOMGroup, "'" + Tv.RelationOwner + "'");
            _dt = Builder.GetDbTable(_sqlText);
            this._bomGroups = (from DataRow row in _dt.Rows select AssemblyBOMGroup(row)).ToList();
            _tvDataSource.SetEntities(_bomGroups);
        }

        private IList<BOMInfo> CreateBomsByParentIDandVersion(string orgMaterialID, string orgMaterialVer)
        {
            _sqlText = string.Format(_sqlTextBOM, "'" + orgMaterialID + "'", "'" + orgMaterialVer + "'");
            _dt = Builder.GetDbTable(_sqlText);
            IList<BOMInfo> boms = (from DataRow row in _dt.Rows select AssemblyBOMInfo(row)).ToList();
            return boms;
        }

        private MaterialInfo CreateMaterialByIDandVersion(string orgMaterialID, string orgMaterialVer)
        {
            _sqlText = string.Format(_sqlTextMaterial, "'" + orgMaterialID + "'", "'" + orgMaterialVer + "'");
            _dt = Builder.GetDbTable(_sqlText);
            MaterialInfo material = ((from DataRow row in _dt.Rows select AssemblyMaterialInfo(row)).ToList())[0];
            return material;
        }
        private BOMInfo AssemblyBOMInfo(DataRow row)
        {
            var bom = new BOMInfo { BOMGroupName = Convert.ToString(row["BOMGroupName"]), BOMSID = Convert.ToInt32(row["BOMSID"]), ParentMaterialID = Convert.ToString(row["ParentMaterialID"]), ParentMaterialVersion = Convert.ToString(row["ParentMaterialVersion"]), ChildMaterialID = Convert.ToString(row["ChildMaterialID"]), ChildMaterialVersion = Convert.ToString(row["ChildMaterialVersion"])};
            return bom;
        }
        private MaterialInfo AssemblyMaterialInfo(DataRow row)
        {
            var material = new MaterialInfo { MaterialID = Convert.ToString(row["MaterialID"]), MaterialVersion = Convert.ToString(row["MaterialVersion"]), MaterialChineseName = Convert.ToString(row["MaterialChineseName"]), ApprovedState = Convert.ToString(row["ApprovedState"]), ApprovedOperatorID = Convert.ToString(row["ApprovedOperatorID"]), CreateOperatorID = Convert.ToString(row["CreateOperatorID"]) };
            return material;
        }

        private BOMGroupInfo AssemblyBOMGroup(DataRow row)
        {
            var bomGroup = new BOMGroupInfo
            {
                ApprovedState = Convert.ToString(row["ApprovedState"]),
                ApprovedStateCode = Convert.ToString(row["ApprovedStateCode"]),
                ApprovedOperatorID = Convert.ToString(row["ApprovedOperatorID"]),
                BOMGroupID = Convert.ToString(row["BOMGroupID"]),
                BOMGroupName = Convert.ToString(row["BOMGroupName"]),
                OriginMaterialID = Convert.ToString(row["OriginMaterialID"]),
                OriginMaterialVersion = Convert.ToString(row["OriginMaterialVersion"]),
                AuditStatusCode = Convert.ToString(row["AuditStatusCode"]),
                AuditStatus = Convert.ToString(row["AuditStatus"])
            };
            return bomGroup;
        }


        //private bool IsOriginMaterial(MaterialInfo material,out ApprovedState auditStatus)
        //{
        //    _sqlText = string.Format(_sqlTextBOMGroup4IDVer, "'" + material.MaterialID + "'", "'" + material.MaterialVersion + "'");
        //    _dt = Builder.GetDbTable(_sqlText);
        //    BOMGroupInfo bomGroupInfo;
        //    auditStatus = new ApprovedState();
        //    if ((from DataRow row in _dt.Rows select AssemblyBOMGroup(row)).ToList().Count != 0)
        //    {
        //        bomGroupInfo = ((from DataRow row in _dt.Rows select AssemblyBOMGroup(row)).ToList())[0];

        //        if (bomGroupInfo.ApprovedState == "核准后通过")
        //        {
        //            auditStatus = ApprovedState.Accept;
        //        }
        //        else if (bomGroupInfo.ApprovedState == "修改")
        //        {
        //            auditStatus = ApprovedState.Modify;
        //        }
        //        else if (bomGroupInfo.ApprovedState == "待核准")
        //        {
        //            auditStatus = ApprovedState.Pending;
        //        }
        //        else if (bomGroupInfo.ApprovedState == "废止")
        //        {
        //            auditStatus = ApprovedState.Stop;
        //        }
        //        else
        //        {
        //            auditStatus = ApprovedState.Pending;
        //        }
        //        return true;
        //    }
        //    else
        //    {
        //        auditStatus = ApprovedState.Pending;
        //        return false;
        //    }

        //    //return (bomInfo.ParentMaterialID == bomGroupInfo.OriginMaterialID && bomInfo.ParentMaterialVersion == bomGroupInfo.OriginMaterialVersion);
        //}

        internal override void InitTreeView()
        {
            AssemblyTreeView();
            //if (isTest)
            //{
            //    this._materials.Clear();
            //}
        }

        private void AssemblyTreeView()
        {

            CreateTreeViewRecursive2(Tv.Nodes, this._tvDataSource.GetEntities()[0],null,0);
            //CreateTreeViewRecursive(Tv.Nodes, this._tvDataSource.GetOldRelations(), 0);
            //RefreshTreeViewNodeChoiceStatus(Tv.Nodes[0]);
        }

        //private bool IsNodeInRelation(RoleInfo p)
        //{
        //    var query = _tvDataSource.GetOldRelations().FirstOrDefault(o => o.RoleID == p.RoleID);
        //    if (query != null)
        //        return true;
        //    else
        //        return false;
        //}

        //private void RefreshTreeViewNodeChoiceStatus(TreeNode treeNode, IList<RoleUser> iList)
        //{
        //    var node = (TriStateTreeNode)treeNode;
        //    var role = (RoleInfo)node.Obj;
        //    if (node.Nodes.Count == 0)
        //    {
        //        Tv.SetTreeNodeStatus(node, IsNodeInRelation(role) ? CheckState.Checked : CheckState.Unchecked);
        //    }
        //    else
        //    {
        //        foreach (TreeNode child in node.Nodes)
        //        {
        //            RefreshTreeViewNodeChoiceStatus(child, iList);
        //        }

        //        int halfCount = 0;
        //        int fullCount = 0;
        //        int notCount = 0;
        //        foreach (TreeNode child in node.Nodes)
        //        {
        //            if (Tv.GetTreeNodeStatus((TriStateTreeNode)child) == CheckState.Unchecked)
        //            {
        //                notCount++;
        //            }
        //            else if (Tv.GetTreeNodeStatus((TriStateTreeNode)child) == CheckState.Indeterminate)
        //            {
        //                halfCount++;
        //            }
        //            else if (Tv.GetTreeNodeStatus((TriStateTreeNode)child) == CheckState.Checked)
        //            {
        //                fullCount++;
        //            }
        //        }
        //        if (node.Nodes.Count == notCount)
        //        {
        //            Tv.SetTreeNodeStatus(node, CheckState.Unchecked);
        //        }
        //        else if (node.Nodes.Count == fullCount)
        //        {
        //            Tv.SetTreeNodeStatus(node, CheckState.Checked);
        //        }
        //        else
        //        {
        //            Tv.SetTreeNodeStatus(node, CheckState.Indeterminate);
        //        }
        //    }
        //}

        //private void RefreshTreeViewNodeChoiceStatus(TreeNode treeNode)
        //{
        //    var node = (TriStateTreeNode)treeNode;
        //    var material = (MaterialInfo)node.Obj;
        //    ApprovedState auditStatus;
        //    if (IsOriginMaterial(material, out auditStatus))
        //    {               
        //        SetCheckState(node, auditStatus);
        //    }
        //    if (treeNode.Nodes != null&&treeNode.Nodes.Count!=0)
        //    {
        //        foreach (TreeNode child in treeNode.Nodes)
        //        {
        //            RefreshTreeViewNodeChoiceStatus(child);
        //        }
        //    }
        //    #region 已注释
        //    //if (node.Nodes != null)
        //    //{
        //    //    IsOriginMaterial(material, out auditStatus);
        //    //    SetCheckState(node, auditStatus);
        //    //}
        //    //else
        //    //{
        //    //    foreach (TreeNode child in node.Nodes)
        //    //    {
        //    //        RefreshTreeViewNodeChoiceStatus(child);
        //    //    }

        //    //    int halfCount = 0;
        //    //    int fullCount = 0;
        //    //    int notCount = 0;
        //    //    foreach (TreeNode child in node.Nodes)
        //    //    {
        //    //        if (Tv.GetTreeNodeStatus((TriStateTreeNode)child) == CheckState.Unchecked)
        //    //        {
        //    //            notCount++;
        //    //        }
        //    //        else if (Tv.GetTreeNodeStatus((TriStateTreeNode)child) == CheckState.Indeterminate)
        //    //        {
        //    //            halfCount++;
        //    //        }
        //    //        else if (Tv.GetTreeNodeStatus((TriStateTreeNode)child) == CheckState.Checked)
        //    //        {
        //    //            fullCount++;
        //    //        }
        //    //    }
        //    //    if (node.Nodes.Count == notCount)
        //    //    {
        //    //        Tv.SetTreeNodeStatus(node, CheckState.Unchecked);
        //    //    }
        //    //    else if (node.Nodes.Count == fullCount)
        //    //    {
        //    //        Tv.SetTreeNodeStatus(node, CheckState.Checked);
        //    //    }
        //    //    else
        //    //    {
        //    //        Tv.SetTreeNodeStatus(node, CheckState.Indeterminate);
        //    //    }
        //    //}
        //    #endregion
        //}

        //private void CreateTreeViewRecursive(TreeNodeCollection nodes, IList<BOMInfo> bomInfos,int startTime)
        //{
        //    if (startTime == 0)
        //    {
        //        IList<BOMInfo> boms = CreateBomsByParentIDandVersion(this._tvDataSource.GetEntities()[0].OriginMaterialID, this._tvDataSource.GetEntities()[0].OriginMaterialVersion);
        //        MaterialInfo material;
        //        if (boms.Count != 0)
        //        {
        //            BOMInfo bom = boms[0];
        //            material = CreateMaterialByIDandVersion(bom.ParentMaterialID, bom.ParentMaterialVersion);
        //        }
        //        else
        //        {
        //            material = CreateMaterialByIDandVersion(this._tvDataSource.GetEntities()[0].OriginMaterialID, this._tvDataSource.GetEntities()[0].OriginMaterialVersion);
        //        }
                
        //        ApprovedState auditStatus;
        //        TriStateTreeNode node = AssmblyNodeByObject(material);
        //        if (Tv.CheckBoxes == true)
        //        {
        //            node.CheckboxVisible = true;
        //        }
        //        _sqlText = String.Format(_sqlTextBOM,"'" + material.MaterialID+"'","'"+material.MaterialVersion+"'");
        //        DataTable children = Builder.GetDbTable(_sqlText);
        //        //判断是否有孩子节点
        //        if (children.Rows.Count != 0)
        //        {
        //            node.IsContainer = true;
        //            //node.SelectedImageIndex = 1;
        //            //node.ImageIndex = 1;
        //        }
        //        if (IsOriginMaterial(material, out auditStatus))
        //        {
        //            node.IsBOMGroup = true;
        //            node.SelectedImageIndex = 1;
        //            node.ImageIndex = 1;
        //            SetCheckState(node, auditStatus);
        //        }

        //        nodes.Add(node);
        //        startTime++;
        //        CreateTreeViewRecursive(node.Nodes, this._tvDataSource.GetOldRelations(), startTime);
        //        startTime++;
        //    }

        //    if (startTime ==1)
        //    {
        //        foreach (BOMInfo obj in bomInfos) //递归循环查询出数据
        //        {
        //            MaterialInfo material = CreateMaterialByIDandVersion(obj.ChildMaterialID, obj.ChildMaterialVersion);
        //            TriStateTreeNode node = AssmblyNodeByObject(material);
        //            ApprovedState auditStatus;
        //            if (Tv.CheckBoxes == true)
        //            {
        //                node.CheckboxVisible = true;
                        
        //            }
        //            _sqlText = String.Format(_sqlTextBOM, "'"+material.MaterialID+"'","'"+ material.MaterialVersion+"'");
        //            DataTable children = Builder.GetDbTable(_sqlText);
        //            //判断是否有孩子节点
        //            if (children.Rows.Count != 0)
        //            {
        //                node.IsContainer = true;
        //                //node.SelectedImageIndex = 1;
        //                //node.ImageIndex = 1;
        //            }
        //            if (IsOriginMaterial(material, out auditStatus))
        //            {
        //                node.IsBOMGroup = true;
        //                node.SelectedImageIndex = 1;
        //                node.ImageIndex = 1;
        //                SetCheckState(node, auditStatus);
        //            }
        //            nodes.Add(node);
        //            IList<BOMInfo> childBoms = CreateBomsByParentIDandVersion(obj.ChildMaterialID, obj.ChildMaterialVersion);
        //            if (childBoms.Count != 0)
        //            {
        //                CreateTreeViewRecursive(node.Nodes, childBoms, startTime);
        //            }
        //            //_sqlTextBOMGroup4IDVer = string.Format(_sqlTextBOMGroup4IDVer, "'" + obj.ChildMaterialID + "'", "'" + obj.ChildMaterialVersion + "'");
        //            //_dt = Builder.GetDbTable(_sqlTextBOMGroup4IDVer);
        //            //BOMGroupInfo bomGroup = ((from DataRow row in _dt.Rows select AssemblyBOMGroup(row)).ToList())[0];
        //            //if (bomGroup != null)
        //            //{
        //            //    CreateTreeViewRecursive(node.Nodes, bomGroup);
        //            //}
        //        }
        //    }

        //}

        private void CreateTreeViewRecursive2(TreeNodeCollection nodes, BOMGroupInfo bomGroup, BOMInfo bom, int startTime)
        {
            
            IList<BOMInfo> boms;

            if (startTime == 0)
            {
                boms = CreateBomsByParentIDandVersion(bomGroup.OriginMaterialID, bomGroup.OriginMaterialVersion);
                MaterialInfo material = CreateMaterialByIDandVersion(bomGroup.OriginMaterialID, bomGroup.OriginMaterialVersion);
                if (isTest)
                {
                    this._materials.Add(material);
                }
                TriStateTreeNode node = AssmblyNodeByObject(material);
                if (Tv.CheckBoxes == true)
                {
                    node.CheckboxVisible = true;
                }
                node.IsBOMGroup = true;
                node.SelectedImageIndex = 1;
                node.ImageIndex = 1;
                SetCheckState2(node, bomGroup);
                //判断是否有孩子节点
                if (boms.Count != 0)
                {
                    node.IsContainer = true;
                    nodes.Add(node);
                    startTime++;

                    foreach (BOMInfo bomItem in boms)
                    {
                        CreateTreeViewRecursive2(node.Nodes, bomGroup, bomItem, startTime);
                    }

                    //node.SelectedImageIndex = 1;
                    //node.ImageIndex = 1;
                }
                else
                {
                    node.IsContainer = false;
                    nodes.Add(node);
                }
            }
            else
            {
                BOMGroupInfo newBomGroup;
                boms = CreateBomsByParentIDandVersion(bom.ChildMaterialID, bom.ChildMaterialVersion);
                MaterialInfo material = CreateMaterialByIDandVersion(bom.ChildMaterialID, bom.ChildMaterialVersion);
                if (isTest)
                {
                    this._materials.Add(material);
                }
                TriStateTreeNode node = AssmblyNodeByObject(material);
                if (Tv.CheckBoxes == true)
                {
                    node.CheckboxVisible = true;
                }
                SetCheckState2(node, bomGroup);
                nodes.Add(node);
                if (boms.Count != 0)
                {
                    node.IsContainer = true;
                    foreach (BOMInfo item in boms)
                    {
                        if (IsSameBOMGroup(item, bom, out newBomGroup))
                        {
                            CreateTreeViewRecursive2(node.Nodes, bomGroup, item, startTime);
                        }
                        else
                        {
                            node.IsBOMGroup = true;
                            node.SelectedImageIndex = 1;
                            node.ImageIndex = 1;
                            CreateTreeViewRecursive2(node.Nodes, newBomGroup, item, startTime);
                        }
                    }
                }
            }
        }

        private bool IsSameBOMGroup(BOMInfo newBom,BOMInfo oldBom,out BOMGroupInfo newBOMGroup)
        {
            if (newBom.BOMGroupName == oldBom.BOMGroupName)
            {
                newBOMGroup = null;
                return true;
            }
            else
            {
                _sqlText = string.Format(_sqlTextBOMGroup, "'" + newBom.BOMGroupName + "'");
                _dt = Builder.GetDbTable(_sqlText);
                newBOMGroup = (from DataRow row in _dt.Rows select AssemblyBOMGroup(row)).ToList()[0];
                return false;
            }
        }

        private void SetCheckState2(TriStateTreeNode node,BOMGroupInfo bomGroup)
        {
            if (this.AuditCodeColumnName == "AuditStatusCode")
            {
                if (bomGroup.AuditStatusCode == "ACC")
                {
                    Tv.SetTreeNodeStatus(node, CheckState.Checked);
                }
                else
                {
                    Tv.SetTreeNodeStatus(node, CheckState.Unchecked);
                }
            }
            else if (this.AuditCodeColumnName == "ApproveStatusCode")
            {
                if (bomGroup.ApprovedStateCode == "ACC")
                {
                    Tv.SetTreeNodeStatus(node, CheckState.Checked);
                }
                else
                {
                    Tv.SetTreeNodeStatus(node, CheckState.Unchecked);
                }
            }
            else
            {
                throw new Exception("AuditCodeColumnName列名称设置不合法。");
            }

        }



        //private void SetCheckState(TriStateTreeNode node, ApprovedState auditStatus)
        //{
        //    if (auditStatus == ApprovedState.Pending)
        //    {
        //        Tv.SetTreeNodeStatus(node, CheckState.Unchecked);
        //    }
        //    if (auditStatus == ApprovedState.Stop)
        //    {
        //        Tv.SetTreeNodeStatus(node, CheckState.Unchecked);
        //    }
        //    if (auditStatus == ApprovedState.Modify)
        //    {
        //        Tv.SetTreeNodeStatus(node, CheckState.Unchecked);
        //    }
        //    if (auditStatus == ApprovedState.Accept)
        //    {
        //        Tv.SetTreeNodeStatus(node, CheckState.Checked);
        //    }
        //}


        internal override TriStateTreeNode AssmblyNodeByObject(object obj)
        {
            MaterialInfo material = obj as MaterialInfo;
            var node = new TriStateTreeNode
            {
                ToolTipText = material.MaterialChineseName.Trim(),
                Text = material.MaterialID +"."+ material.MaterialVersion,
                ID = material.MaterialID,
                Obj = material,
                SelectedImageIndex = 0,
                ImageIndex = 0
            };
            return node;
        }
        internal override Object AssmblyNewRelationObjectByNode(TriStateTreeNode tNode)
        {
            return null;
        }

        public override object GetNewRelations()
        {
            return null;
        }

        public override void AddTriStateNode(TriStateTreeNode parentNode, object currentObj)
        {
            //RoleInfo role = currentObj as RoleInfo;
            //if (role == null) return;
            //var currentNode = new TriStateTreeNode
            //{
            //    ID = role.RoleID.ToString(),
            //    Name = role.RoleName,
            //    Text = role.RoleName,
            //    Obj = role,
            //    IsContainer = role.IsRoleGroup ? true : false,
            //    CheckboxVisible = Tv.CheckBoxes ? true : false,
            //    ImageIndex = role.IsRoleGroup ? 1 : 0,
            //    SelectedImageIndex = role.IsRoleGroup ? 1 : 0,
            //};
            //parentNode.Nodes.Add(currentNode);
            //_tvDataSource.AddEntity(role);
        }
        public bool CheckAuditStatusRecursive(TriStateTreeNode treeNode)
        {
            return checkAuditStatusRecursive(treeNode.Nodes);
        }
        //BOM检查只做两层。
        private bool checkAuditStatusRecursive(TreeNodeCollection nodes)
        {
            bool result = true;
            foreach (TriStateTreeNode child in nodes)
            {
                if (child.IsBOMGroup == true)
                {
                    if (child.Nodes !=null&&child.Nodes.Count!=0)
                    {
                        result = checkBomChildStatus(child.Nodes);
                    }
                    else
                    {
                        if (child.CheckState != CheckState.Checked)
                        {
                            result = false;
                            return result;
                        }
                    }

                }
                else if (child.Nodes != null && child.Nodes.Count != 0)
                {
                    checkAuditStatusRecursive(child.Nodes);
                }
            }
            return result;
        }

        private bool checkBomChildStatus(TreeNodeCollection nodes)
        {
            bool result = true;
            foreach (TriStateTreeNode child in nodes)
            {
                if (child.CheckState != CheckState.Checked)
                {
                    result = false;
                    return result;
                }
            }
            return result;
        }

        public override void UpdateTriStateNode(TriStateTreeNode currentNode, object currentObj)
        {

            //RoleInfo role = currentObj as RoleInfo;
            //if (role == null) return;
            //RoleInfo oldRole = currentNode.Obj as RoleInfo;

            //var newNode = new TriStateTreeNode
            //{
            //    ID = role.RoleID.ToString(),
            //    Name = role.RoleName,
            //    Text = role.RoleName,
            //    Obj = role,
            //    IsContainer = role.IsRoleGroup ? true : false,
            //    CheckboxVisible = Tv.CheckBoxes ? true : false,
            //    ImageIndex = role.IsRoleGroup ? 1 : 0,
            //    SelectedImageIndex = role.IsRoleGroup ? 1 : 0,
            //};
            //var parentNode = currentNode.Parent;
            //int index = parentNode.Nodes.IndexOf(currentNode);
            //parentNode.Nodes.Remove(currentNode);
            //parentNode.Nodes.Insert(index, newNode);

            //_tvDataSource.ModifyEntity(oldRole, role);
        }

        public override void DeleteTriStateNode(TriStateTreeNode currentNode)
        {
            //throw new NotImplementedException();

            //if (currentNode == null) return;
            //var parentNode = currentNode.Parent;
            //if (parentNode == null) return;
            //parentNode.Nodes.Remove(currentNode);

            //_tvDataSource.DeleteEntity(currentNode.Obj as RoleInfo);
        }
        public void UpdateTriStateNode()
        {
            UpdateTriStateNodeRecursive(this.Tv.Nodes[0]);
        }
        private void UpdateTriStateNodeRecursive(TreeNode treeNode)
        {
            foreach (TriStateTreeNode child in treeNode.Nodes)
            {
                if (child.Nodes != null && child.Nodes.Count == 0)
                {
                    Tv.SetTreeNodeStatus(child, CheckState.Checked);
                }
                else if (child.Nodes != null && child.Nodes.Count > 0)
                {
                    UpdateTriStateNodeRecursive(child);
                }

            }
        }
    }
}
