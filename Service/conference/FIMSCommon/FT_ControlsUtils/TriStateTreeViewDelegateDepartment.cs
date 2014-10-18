using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace FT_ControlsUtils
{
    public class TriStateTreeViewDelegateDepartment : TriStateTreeViewDelegate
    {
        private string _sqlTextDepartment = "select * from T_Department Where DepNO = {0} ORDER BY DepPriority";
        private const int StartID = 0;
        private DepartmentInfo _department;
        private const int StartTime = 0;
        private const int codeLengh = 3;
        private DataTable _dt;
        private string _sqlTextDepRelation = "SELECT * FROM T_Department where DepNO like '{0}%' AND len(DepNO) = {1} ORDER BY DepPriority";
        private string _sqlText = "";


        internal override void InitTreeViewDataSource()
        {
            Tv.TriStateDelegate = this;
            this.Tv.IsCheckBoxReadOnly = true;
            AssemblyDataSourceList();
        }

        private void AssemblyDataSourceList()
        {
            CreateDepartments();
        }

        private void CreateDepartments()
        {
            if (Tv.RelationOwner!=null)
            {
                _sqlText = string.Format(_sqlTextDepartment, "'" + Tv.RelationOwner + "'");
                _dt = Builder.GetDbTable(_sqlText);
                IList<DepartmentInfo> deps = (from DataRow row in _dt.Rows select AssemblyDepartment(row)).ToList();
                if (deps.Count ==0)
                {
                    return;
                }
                this._department = deps[0];
            }
            else
            {
                _sqlText = string.Format(_sqlTextDepartment, "'" + "001" + "'");
                _dt = Builder.GetDbTable(_sqlText);
                this._department = (from DataRow row in _dt.Rows select AssemblyDepartment(row)).ToList()[0];
            }
        }

        private IList<DepartmentInfo> CreateDepartmentsByParentNO(string parentNO)
        {
            _sqlText = string.Format(_sqlTextDepRelation, parentNO, parentNO.Length + codeLengh);
            _dt = Builder.GetDbTable(_sqlText);
            IList<DepartmentInfo> boms = (from DataRow row in _dt.Rows select AssemblyDepartment(row)).ToList();
            return boms;
        }

        private IList<DepartmentInfo> CreateEmployeesByDepartmentNO(string departmentNO)
        {
            string sqlTextDepRelation = "";//部门职工关系"SELECT * FROM T_Employee where DepNO like '{0}%' AND len(DepNO) = {1}";
            _dt = Builder.GetDbTable(sqlTextDepRelation);
            IList<DepartmentInfo> boms = (from DataRow row in _dt.Rows select AssemblyDepartment(row)).ToList();
            return boms;
        }


        private DepartmentInfo AssemblyDepartment(DataRow row)
        {
            var department = new DepartmentInfo
            {
                DepID = Convert.ToInt32(row["DepID"]),
                DepNO = Convert.ToString(row["DepNO"]),
                DepName = Convert.ToString(row["DepName"]),
                DepEnName = Convert.ToString(row["DepEnName"]),
                DepPriority = Convert.ToInt32(row["DepPriority"])
            };
            return department;
        }

        internal override void InitTreeView()
        {
            AssemblyTreeView();
        }

        private void AssemblyTreeView()
        {
            if (this._department == null)
            {
                return;
            }
            CreateTreeViewRecursive2(Tv.Nodes, _department, 0);
        }


        private void CreateTreeViewRecursive2(TreeNodeCollection nodes, DepartmentInfo department, int startTime)
        {
            IList<DepartmentInfo> departments;

            if (startTime == 0)
            {
                departments = CreateDepartmentsByParentNO(department.DepNO);
                TriStateTreeNode node = AssmblyNodeByObject(department);
                if (Tv.CheckBoxes == true)
                {
                    node.CheckboxVisible = true;
                }
                node.SelectedImageIndex = 1;
                node.ImageIndex = 1;
                //判断是否有孩子节点
                if (departments.Count != 0)
                {
                    node.IsContainer = true;
                    nodes.Add(node);
                    startTime++;

                    foreach (DepartmentInfo departmentItem in departments)
                    {
                        CreateTreeViewRecursive2(node.Nodes,departmentItem, startTime);
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
                departments = CreateDepartmentsByParentNO(department.DepNO);
                TriStateTreeNode node = AssmblyNodeByObject(department);
                if (Tv.CheckBoxes == true)
                {
                    node.CheckboxVisible = true;
                }
                nodes.Add(node);
                if (departments.Count != 0)
                {
                    node.IsContainer = true;
                    foreach (DepartmentInfo item in departments)
                    {
                        node.SelectedImageIndex = 1;
                        node.ImageIndex = 1;
                        CreateTreeViewRecursive2(node.Nodes, item, startTime);
                    }
                }
                //else
                //{
                //    //....组装员工节点
                //    if (!this.IsEmployeeDisplay)
                //    {
                //        return;
                //    }

                //}
            }
        }


        internal override TriStateTreeNode AssmblyNodeByObject(object obj)
        {
            DepartmentInfo department = obj as DepartmentInfo;
            var node = new TriStateTreeNode
            {
                ToolTipText = department.DepEnName.Trim(),
                Text = department.DepName,
                ID = department.DepID.ToString(),
                Obj = department,
                SelectedImageIndex = 0,
                ImageIndex = 0
            };
            return node;
        }
        internal override Object AssmblyNewRelationObjectByNode(TriStateTreeNode tNode)
        {
            throw new NotImplementedException();
        }

        public override object GetNewRelations()
        {
            throw new NotImplementedException();
        }

        public override void AddTriStateNode(TriStateTreeNode parentNode, object currentObj)
        {
            throw new NotImplementedException();
        }
        public bool CheckAuditStatusRecursive(TriStateTreeNode treeNode)
        {
            return checkAuditStatusRecursive(treeNode.Nodes);
        }
        private bool checkAuditStatusRecursive(TreeNodeCollection nodes)
        {
            bool result = true;
            foreach (TriStateTreeNode child in nodes)
            {
                if (child.IsBOMGroup == true)
                {
                    if (child.Nodes != null && child.Nodes.Count != 0)
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
            throw new NotImplementedException();
        }

        public override void DeleteTriStateNode(TriStateTreeNode currentNode)
        {
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
