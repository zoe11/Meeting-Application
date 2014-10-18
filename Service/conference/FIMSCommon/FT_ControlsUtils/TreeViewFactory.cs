using System;
using System.Data;
using System.Windows.Forms;

namespace FT_ControlsUtils
{
    public class TreeViewFactory
    {
        private static DBBuilder dbbuild = new DBBuilder();
        //WINFORM方法:
        /// <summary>
        /// 动态创建TreeView
        /// </summary>
        /// <param name="sqlText">传入的SQL语句</param>
        /// <param name="nodes">TreeView节点集</param>
        public static void CreateTreeView(string sqlText, TreeNodeCollection nodes, string parentID, string childID, string childName)
        {
            try
            {
                DataTable dbTable = new DataTable();//实例化一个DataTable数据表对象

                dbTable = dbbuild.GetDbTable(sqlText);//返数据表

                //将第一级菜单取出生成TreeView的节点,作为递归运算的入口递归查询出TreeView的所有节点数据
                CreateTreeViewRecursive(nodes, dbTable, 0, parentID, childID, childName, 0);
            }
            catch (Exception tv_ex)
            {
                MessageBox.Show(tv_ex.Message);
            }
        }
        /**/
        /// <summary>
        /// 递归查询
        /// </summary>
        /// <param name="nodes">TreeView节点集合</param>
        /// <param name="dataSource">数据源</param>
        /// <param name="parentid">上一级菜单节点标识码</param>
        private static void CreateTreeViewRecursive(TreeNodeCollection nodes, DataTable dataSource, int parentid, string parent, string child, string childname, int time)
        {
            string filter;//定义一个过滤器
            if (time == 0)
            {
                filter = string.Format(child + "={0}", parentid);
            }
            else
            {
                filter = string.Format(parent + "={0}", parentid);
            }
            DataRow[] drarr = dataSource.Select(filter);//将过滤的ID放入数组中

            TreeNodeExt node;
            foreach (DataRow dr in drarr)//递归循环查询出数据
            {
                node = new TreeNodeExt();
                node.Text = dr[childname].ToString();
                node.Tag = Convert.ToInt32(dr[child]);
                node.ID = dr[child].ToString();

                time++;
                if (Convert.ToInt32(dr[child]) != parentid && time > 0)
                {
                    nodes.Add(node);//加入节点
                    CreateTreeViewRecursive(node.Nodes, dataSource, Convert.ToInt32(node.Tag), parent, child, childname, time);
                }
                if (time == 1)
                {
                    nodes.Add(node);//加入节点
                    CreateTreeViewRecursive(node.Nodes, dataSource, Convert.ToInt32(node.Tag), parent, child, childname, time);
                }
            }
        }
    }
}
