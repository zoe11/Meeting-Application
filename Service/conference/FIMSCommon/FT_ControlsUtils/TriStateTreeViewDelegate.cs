using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FT_ControlsUtils
{
    public abstract class TriStateTreeViewDelegate
    {
        public TriStateTreeView Tv;
        protected DBBuilder Builder = new DBBuilder();

        /// <summary>
        /// 对TriStateTreeView初始化，
        /// 初始化包括数据部分，和展示部分
        /// </summary>
        public void Initial()
        {
            this.Tv.Nodes.Clear();
            InitTreeViewDataSource();
            InitTreeView();
        }
        /// <summary>
        /// 初始化数据部分
        /// </summary>
        internal abstract void InitTreeViewDataSource();
        /// <summary>
        /// 初始化展示部分
        /// </summary>
        internal abstract void InitTreeView();

        internal abstract Object AssmblyNewRelationObjectByNode(TriStateTreeNode tNode);
        internal abstract TriStateTreeNode AssmblyNodeByObject(Object obj);

        /// <summary>
        /// 获得新的选中关系
        /// 返回关系表对象的集合
        /// </summary>
        /// <returns></returns>
        public abstract object GetNewRelations();

        /// <summary>
        /// 向TriStateTreeView中添加节点
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="currentObj"></param>
        public abstract void AddTriStateNode(TriStateTreeNode parentNode, object currentObj);


        /// <summary>
        /// 更改TriStateTreeView中选定节点
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="currentObj"></param>
        public abstract void UpdateTriStateNode(TriStateTreeNode currentNode, object currentObj);

        /// <summary>
        /// 删除TriStateTreeView中选中节点
        /// </summary>
        /// <param name="currentNode"></param>
        public abstract void DeleteTriStateNode(TriStateTreeNode currentNode);

    }
}
