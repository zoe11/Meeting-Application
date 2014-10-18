using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FT_ControlsUtils
{
/// <summary>
        /// TreeView控件的工作状态
        /// </summary>
        public enum TreeViewWorkStatus
        {
            //可勾选状态
            ChoiceStatus = 0,
            //普通信息显示编辑状态
            EditStatus = 1
        }
    public class TreeViewExt : TreeView
    {

        //public event  EventHandler   myDoubleClick;
        //private void picMap_DoubleClick(object sender, System.EventArgs e)
        //{
        //    if (myDoubleClick != null)
        //        this.myDoubleClick(sender, e);
        //} 

        

        #region 成员变量
        //工作状态
        private TreeViewWorkStatus _workStatus;
        //一级显示状态集
        private TreeViewExtNodeStatusSet _levelOne;
        //二级显示状态集
        private TreeViewExtNodeStatusSet _levelTwo;

        //委托
        private TreeViewExtDelegate _tvDelegate;
        #endregion

        #region 属性
        public TreeViewWorkStatus WorkStatus
        {
            get { return _workStatus; }
            set { _workStatus = value; }
        }
        public TreeViewExtDelegate TVDelegate
        {
            get { return _tvDelegate; }
            set
            {
                _tvDelegate = value;
            }
        }
        public TreeViewExtNodeStatusSet LevelOne
        {
            get { return _levelOne; }
            set { _levelOne = value; }
        }
        public TreeViewExtNodeStatusSet LevelTwo
        {
            get { return _levelTwo; }
            set { _levelTwo = value; }
        }

        public string RelationOwner { get; set; }
        #endregion

        public TreeViewExt()
            : base()
        {
            this.AfterSelect += new TreeViewEventHandler(TreeViewExt2_AfterSelect);
        }

        void TreeViewExt2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNodeExt node = (TreeNodeExt)this.SelectedNode;
            refreshTreeViewChoiceStatus(node);
        }


        public void bindDelegate(TreeViewExtDelegate tvd)
        {
            _tvDelegate = tvd;
            _tvDelegate.tv = this;
            _tvDelegate.initial();
        }

        /// <summary>
        /// 获得当前节点的显示状态
        /// </summary>
        /// <param name="node">要设置的节点</param>
        /// <returns>显示状态</returns>
        public int getCurNodeStatus(TreeNodeExt node)
        {
            //显示状态对应于ImageList中的图片索引
            return node.ImageIndex;
        }

        /// <summary>
        /// 设置当前节点的显示状态
        /// </summary>
        /// <param name="node">要设置的节点</param>
        /// <param name="status">要设置的显示状态</param>
        public void setTreeNodeStatus(TreeNodeExt node, int status)
        {
            node.ImageIndex = status;
            node.SelectedImageIndex = status;
        }

        /// <summary>
        /// 刷新当前节点
        /// </summary>
        /// <param name="node">需要刷新的节点</param>
        /// <param name="status">要设置的显示状态</param>
        private void refreshCurNodeStatus(TreeNodeExt node, int status)
        {
            setTreeNodeStatus(node, status);
        }

        /// <summary>
        /// 递归刷新当前节点的后代节点
        /// </summary>
        /// <param name="node">当前节点</param>
        /// <param name="status">要设置的显示状态</param>
        private void refreshCurNodeDescendantStatus(TreeNodeExt node)
        {
            refreshCurNodeDescendantStatusRecursive(node);
        }

        private void refreshCurNodeDescendantStatusRecursive(TreeNodeExt node)
        {
            int curNodeStatus = getCurNodeStatus(node);
            int childNodeStatus = 0;
            foreach (TreeNodeExt child in node.Nodes)
            {
                TreeViewExtNodeStatusSet curNodeStatusSet = _tvDelegate.getStatusSet(node);
                TreeViewExtNodeStatusSet curNodeStatusSet2 = _tvDelegate.getStatusSet(child);
                if (curNodeStatus == curNodeStatusSet.FULL_CHOICE_GRAPHIC)
                {
                    childNodeStatus = curNodeStatusSet2.FULL_CHOICE_GRAPHIC;
                }
                else if (curNodeStatus == curNodeStatusSet.HALF_CHOICE_GRAPHIC)
                {
                    childNodeStatus = curNodeStatusSet2.HALF_CHOICE_GRAPHIC;
                }
                else if (curNodeStatus == curNodeStatusSet.NOT_CHOICE_GRAPHIC)
                {
                    childNodeStatus = curNodeStatusSet2.NOT_CHOICE_GRAPHIC;
                }
                refreshCurNodeStatus(child, childNodeStatus);
                refreshCurNodeDescendantStatusRecursive(child);
            }
        }

        /// <summary>
        /// 刷新当前节点的祖先节点
        /// </summary>
        /// <param name="node">当前节点</param>
        private void refreshCurNodeAncestorStatus(TreeNodeExt node)
        {
            TreeNodeExt parent = (TreeNodeExt)node.Parent;
            if (parent != null)
            {
                int notCount=0;
                int halfCount=0;
                int fullCount=0;

                int childCount=parent.Nodes.Count;
                TreeViewExtNodeStatusSet curNodeStatusSet = _tvDelegate.getStatusSet(parent);//LevelOne;
                foreach (TreeNodeExt child in parent.Nodes)
                {
                    TreeViewExtNodeStatusSet curNodeStatusSet2 = _tvDelegate.getStatusSet(child);
                    if (getCurNodeStatus(child) == curNodeStatusSet2.FULL_CHOICE_GRAPHIC)
                    {
                        fullCount++;
                    }
                    else if (getCurNodeStatus(child) == curNodeStatusSet2.HALF_CHOICE_GRAPHIC)
                    {
                        halfCount++;
                    }
                    else if (getCurNodeStatus(child) == curNodeStatusSet2.NOT_CHOICE_GRAPHIC)
                    {
                        notCount++;
                    }
                }
                if (notCount == childCount)
                {
                    refreshCurNodeStatus(parent, curNodeStatusSet.NOT_CHOICE_GRAPHIC);
                }
                else if (fullCount == childCount)
                {
                    refreshCurNodeStatus(parent, curNodeStatusSet.FULL_CHOICE_GRAPHIC);
                }
                else
                {
                    refreshCurNodeStatus(parent, curNodeStatusSet.HALF_CHOICE_GRAPHIC);
                }
                refreshCurNodeAncestorStatus(parent);
            }
        }

        /// <summary>
        /// 根据选中节点的选择状态变化刷新TreeView的选择状态
        /// </summary>
        /// <param name="node">选中的节点</param>
        public void refreshTreeViewChoiceStatus(TreeNodeExt node)
        {

            int treeNodeStatus = getCurNodeStatus(node);
            int nodeStatus=0;
            //通过委托方式判断当前节点状态集
            TreeViewExtNodeStatusSet curNodeStatusSet = _tvDelegate.getStatusSet(node);//LevelOne;
            if(    treeNodeStatus==curNodeStatusSet.NOT_CHOICE_GRAPHIC
                || treeNodeStatus==curNodeStatusSet.HALF_CHOICE_GRAPHIC )
            {
                nodeStatus = curNodeStatusSet.FULL_CHOICE_GRAPHIC;
                    
            }
            else if(treeNodeStatus==curNodeStatusSet.FULL_CHOICE_GRAPHIC)
            {
                nodeStatus = curNodeStatusSet.NOT_CHOICE_GRAPHIC;
            }
            refreshCurNodeStatus(node,nodeStatus);
            refreshCurNodeDescendantStatus(node);
            refreshCurNodeAncestorStatus(node);
        }

       /// <summary>
        /// 获取当前节点对应的对象的值
        /// </summary>
        /// <returns>Object对象，根据需要进行强制类型转换</returns>
        public Object getCurNodeObject()
        {
            return ((TreeNodeExt)this.SelectedNode).Obj;
        }


        private void assmblyNewRelationObjects(TreeNodeCollection nodes, IList<Object> result)
        {
            //此处递归处理
            TreeNodeExt  tNode=null;

            Object obj = _tvDelegate.assmblyNewRelationObjectByNode(tNode);
            result.Add(obj);

        }

        public IList <Object> getNewRelationObjects()
        {
            IList<Object> result = new List<object>();

            assmblyNewRelationObjects(Nodes,result);
            return result ;
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="obj">需添加的对象信息</param>
        public void addTreeNode(Object obj)
        {
            //DataSource.addObj(obj);
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="obj">需删除的对象信息</param>
        public void deleteTreeNode(Object obj)
        {
            //DataSource.deleteObj(obj);
        }

        /// <summary>
        /// 修改节点信息
        /// </summary>
        /// <param name="obj"></param>
        public void modifyTreeNode(Object obj)
        {
            //DataSource.modifyObj(obj);
        }

        public object getNewRelations()
        {
            return _tvDelegate.getNewRelations();  
        }

        public Object getCurNodeObj()
        {
            return getCurNodeObj();
        }
        public void addObj(Object obj)
        {
            addTreeNode(obj);
        }
        public void deleteObj(Object obj)
        {
            deleteTreeNode(obj);
        }
        public void modifyObj(Object obj)
        {
            modifyTreeNode(obj);
        }
    }
}
