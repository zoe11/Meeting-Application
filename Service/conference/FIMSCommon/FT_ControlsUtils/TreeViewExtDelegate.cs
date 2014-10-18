using System;

namespace FT_ControlsUtils
{
    public abstract class TreeViewExtDelegate
    {
        public TreeViewExt tv;
        protected DBBuilder builder = new DBBuilder();

        public void initial()
        {
            initTreeViewStatusSet();
            initTreeViewDataSource();
            initTreeView();
        }

        public abstract void initTreeViewStatusSet();
        public abstract void initTreeViewDataSource();
        public abstract void initTreeView();

        public abstract Object assmblyNewRelationObjectByNode(TreeNodeExt tNode);
        public abstract TreeNodeExt assmblyNodeByObject(Object obj);

        public abstract TreeViewExtNodeStatusSet getStatusSet(TreeNodeExt node);

        public abstract object getNewRelations();
    }
}
