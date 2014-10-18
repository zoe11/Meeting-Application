using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SysMGT_Model;

namespace FT_ControlsUtils
{
    public class TreeViewExtDelegateRole : TreeViewExtDelegate
    {
        private const string SQL_TEXT_TREE="select * from T_Role";
        private const int      START_ID=0;
        private const string ROLE_ID="RoleID";
        private const string ROLE_PARENT_ID="RoleParentID";
        private const string ROLE_NAME="RoleName";
        private const int      START_TIME=0;

        private  string SQL_TEXT_RELATION="SELECT * FROM T_UserRole where UserID=";
        private const string USER_ID="UserID";

        private TreeViewExtDataSource<RoleInfo,RoleUser> tvDataSource;
        private DataTable dt;
        private IList<RoleUser> newRelationList;

        public override void initTreeViewStatusSet()
        {
            //初始化image文件
            //tv.ImageList.Images.Add
            string path = @"C:\Users\Michel\Desktop\icon\角色\";
            tv.ImageList.Images.Add(Image.FromFile(path + "0_单人无框.jpg"));
            tv.ImageList.Images.Add(Image.FromFile(path + "1_两人没框.jpg"));
            tv.ImageList.Images.Add(Image.FromFile(path + "2_单人空框.jpg"));
            tv.ImageList.Images.Add(Image.FromFile(path + "3_两人空框.jpg"));
            tv.ImageList.Images.Add(Image.FromFile(path + "4_单人多框.jpg"));
            tv.ImageList.Images.Add(Image.FromFile(path + "5_两人多框.jpg"));
            tv.ImageList.Images.Add(Image.FromFile(path + "6_单人勾框.jpg"));
            tv.ImageList.Images.Add(Image.FromFile(path + "7_两人勾框.jpg"));

            TreeViewExtNodeStatusSet nodeStatusSet;
            //初始化LevelOne,此处的编号要和上面ImageList文件对应编号一致；
            nodeStatusSet = new TreeViewExtNodeStatusSet();
            nodeStatusSet.COMMON_GRAPHIC = 1;
            nodeStatusSet.NOT_CHOICE_GRAPHIC = 3;
            nodeStatusSet.HALF_CHOICE_GRAPHIC = 5;
            nodeStatusSet.FULL_CHOICE_GRAPHIC = 7;
            tv.LevelOne = nodeStatusSet;

            //初始化LevelTwo,此处的编号要和上面ImageList文件对应编号一致；
            nodeStatusSet = new TreeViewExtNodeStatusSet();
            nodeStatusSet.COMMON_GRAPHIC = 0;
            nodeStatusSet.NOT_CHOICE_GRAPHIC = 2;
            nodeStatusSet.HALF_CHOICE_GRAPHIC = 4;
            nodeStatusSet.FULL_CHOICE_GRAPHIC = 6;
            tv.LevelTwo = nodeStatusSet;

        }

        public override void initTreeViewDataSource()
        {
            //
            tvDataSource = new TreeViewExtDataSource<RoleInfo, RoleUser>();
            //
            assemblyDataSourceList();
        }

        public override void initTreeView()
        {
            assemblyTreeView();
        }

        public void assemblyTreeView()
        {
            //CreateTreeViewRecursive(tv.Nodes, dt, START_ID, ROLE_PARENT_ID, ROLE_ID, ROLE_NAME, START_TIME);
            CreateTreeViewRecursive(tv.Nodes, tvDataSource.GetEntities(), START_ID, START_TIME);
            refreshTreeViewNodeChoiceStatus(tv.Nodes[0], tvDataSource.GetOldRelations());
        }

        private void refreshTreeViewNodeChoiceStatus(TreeNode treeNode, IList<RoleUser> iList)
        {
            TreeNodeExt node = (TreeNodeExt)treeNode;
            RoleInfo role = (RoleInfo)node.Obj;
            TreeViewExtNodeStatusSet curNodeStatusSet = getStatusSet(node);
            if (node.Nodes.Count == 0)
            {
                tv.setTreeNodeStatus(node,
                                     isNodeInRelation(role)
                                         ? curNodeStatusSet.FULL_CHOICE_GRAPHIC
                                         : curNodeStatusSet.NOT_CHOICE_GRAPHIC);
            }
            else
            {
                foreach (TreeNode child in node.Nodes)
                {
                    refreshTreeViewNodeChoiceStatus(child, iList);
                }

                int halfCount=0;
                int fullCount=0;
                int notCount=0;
                foreach (TreeNode child in node.Nodes)
                {
                    if (tv.getCurNodeStatus((TreeNodeExt)child) == curNodeStatusSet.NOT_CHOICE_GRAPHIC)
                    {
                        notCount++;
                    }
                    else if (tv.getCurNodeStatus((TreeNodeExt)child) == curNodeStatusSet.HALF_CHOICE_GRAPHIC)
                    {
                        halfCount++;
                    }
                    else if (tv.getCurNodeStatus((TreeNodeExt)child) == curNodeStatusSet.FULL_CHOICE_GRAPHIC)
                    {
                        fullCount++;
                    }
                }
                if (node.Nodes.Count == notCount)
                {
                    tv.setTreeNodeStatus(node, curNodeStatusSet.NOT_CHOICE_GRAPHIC);
                }
                else if (node.Nodes.Count == fullCount)
                {
                    tv.setTreeNodeStatus(node, curNodeStatusSet.FULL_CHOICE_GRAPHIC);
                }
                else
                {
                    tv.setTreeNodeStatus(node, curNodeStatusSet.HALF_CHOICE_GRAPHIC);
                }
            }
        }

        private bool isNodeInRelation(RoleInfo p)
        {
            var query =tvDataSource.GetOldRelations().FirstOrDefault(o=>o.RoleID==p.RoleID);
            if (query != null)
                return true;
            else
                return false;
        }

        private void CreateTreeViewRecursive(TreeNodeCollection nodes, IList<RoleInfo> dataSource, int START_ID, int START_TIME)
        {
            IList<RoleInfo> list;
            if (START_TIME == 0)
            {
                list = dataSource.Where(o => o.RoleID == START_ID).ToList();
            }
            else
            {
                list = dataSource.Where(o => o.RoleParentID == START_ID).ToList();
            }

            TreeNodeExt node;
            foreach (var obj in list)//递归循环查询出数据
            {
                node = assmblyNodeByObject(obj);

                START_TIME++;
                if (obj.RoleID != START_ID && START_TIME > 0)
                {
                    nodes.Add(node);//加入节点
                    CreateTreeViewRecursive(node.Nodes, dataSource, obj.RoleID, START_TIME);
                }
                if (START_TIME == 1)
                {
                    nodes.Add(node);//加入节点
                    CreateTreeViewRecursive(node.Nodes, dataSource, obj.RoleID, START_TIME);
                }
            }
        }

        private void CreateTreeViewRecursive(TreeNodeCollection nodes, DataTable dataSource, int START_ID, string ROLE_PARENT_ID, string ROLE_ID, string ROLE_NAME, int START_TIME)
        {
            string filter;//定义一个过滤器
            if (START_TIME == 0)
            {
                filter = string.Format(ROLE_ID + "={0}", START_ID);
            }
            else
            {
                filter = string.Format(ROLE_PARENT_ID + "={0}", START_ID);
            }
            var drarr = dataSource.Select(filter);//将过滤的ID放入数组中

            TreeNodeExt node;
            foreach (DataRow dr in drarr)//递归循环查询出数据
            {
                node = new TreeNodeExt();
                node.Text = dr[ROLE_NAME].ToString();
                node.ID = dr[ROLE_ID].ToString();
                node.Obj = assemblyRoleInfo(dr);

                START_TIME++;
                if (Convert.ToInt32(dr[ROLE_ID]) != START_ID && START_TIME > 0)
                {
                    nodes.Add(node);//加入节点
                    CreateTreeViewRecursive(node.Nodes, dataSource, Convert.ToInt32(node.Tag), ROLE_PARENT_ID, ROLE_ID, ROLE_NAME, START_TIME);
                }
                if (START_TIME == 1)
                {
                    nodes.Add(node);//加入节点
                    CreateTreeViewRecursive(node.Nodes, dataSource, Convert.ToInt32(node.Tag), ROLE_PARENT_ID, ROLE_ID, ROLE_NAME, START_TIME);
                }
            }
        }

        private void assemblyDataSourceList()
        {
            assemblyEntityTree();
            assemblyOldRelation();
        }

        private void assemblyOldRelation()
        {
            SQL_TEXT_RELATION += "'" + tv.RelationOwner + "'";
            dt = builder.GetDbTable(SQL_TEXT_RELATION);
            IList<RoleUser> rus = new List<RoleUser>();
            foreach (DataRow row in dt.Rows)
            {
                RoleUser ru = assemblyRoleUser(row);
                rus.Add(ru);
            }
            tvDataSource.SetOldRelations(rus);
        }

        private void assemblyEntityTree()
        {
            dt = builder.GetDbTable(SQL_TEXT_TREE);
            IList<RoleInfo> roles = new List<RoleInfo>();
            foreach (DataRow row in dt.Rows)
            {
                RoleInfo role = assemblyRoleInfo(row);
                roles.Add(role);
            }
            tvDataSource.SetEntities(roles);
        }

        private RoleInfo assemblyRoleInfo(DataRow row)
        {
            RoleInfo role  = new RoleInfo();
            role.RoleID = Convert.ToInt32(row["RoleID"]);
            role.RoleName = Convert.ToString(row["RoleName"]);
            role.RoleParentID = Convert.ToInt32(row["RoleParentID"]);
            role.IsInnerRole = Convert.ToBoolean(row["IsInnerRole"]);
            role.IsRoleGroup = Convert.ToBoolean(row["IsRoleGroup"]);
            role.RoleDescription = Convert.ToString(row["RoleDescription"]);
            return role;
        }
        
        private RoleUser assemblyRoleUser(DataRow row)
        {
            RoleUser ru = new RoleUser();
            ru.UserID = Convert.ToString(row["UserID"]);
            ru.RoleID = Convert.ToInt32(row["RoleID"]);
            return ru;
        }

        public override TreeNodeExt assmblyNodeByObject(object obj)
        {
            TreeNodeExt node = new TreeNodeExt();
            node.Text =((RoleInfo)obj).RoleName;
            node.ID = Convert.ToString(((RoleInfo)obj).RoleID);
            node.Obj = obj;
            return node;
        }

        public override TreeViewExtNodeStatusSet getStatusSet(TreeNodeExt node)
        {
            RoleInfo role = (RoleInfo)node.Obj;
            if (role.IsRoleGroup)
            {
                return tv.LevelOne;
            }
            else
            {
                return tv.LevelTwo;
            }
        }

        public override object assmblyNewRelationObjectByNode(TreeNodeExt tNode)
        {
            RoleUser ru = new RoleUser();
            ru.RoleID = ((RoleInfo)tNode.Obj).RoleID;
            ru.UserID = tv.RelationOwner;
            return ru;
        }

        public override object getNewRelations()
        {
            newRelationList = new List<RoleUser>();
            TreeNodeExt node = (TreeNodeExt)tv.Nodes[0];
            getNewRelationsRecursive(node);
            return newRelationList;
        }

        private void getNewRelationsRecursive(TreeNodeExt node)
        {
            if (node.Nodes.Count == 0)
            {
                RoleInfo role = (RoleInfo)node.Obj;
                if (!role.IsInnerRole)
                {
                    TreeViewExtNodeStatusSet curNodeStatusSet =  getStatusSet(node);
                    int curNodeSatus = tv.getCurNodeStatus(node);
                    if (curNodeSatus == curNodeStatusSet.FULL_CHOICE_GRAPHIC)
                    {
                        RoleUser ru = (RoleUser)assmblyNewRelationObjectByNode(node);
                        newRelationList.Add(ru);
                    }
                }
            }
            else
            {
                foreach (TreeNodeExt child in node.Nodes)
                {
                    getNewRelationsRecursive(child);
                }
            }
        }
    }
}
