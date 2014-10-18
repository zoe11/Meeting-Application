using System;
using System.Data;
using System.Data.SqlClient;
using FT_ENV;

namespace FT_ControlsUtils
{
    public class DBBuilder
    {
        private SqlConnection db_conn;//定义数据库连接对象
        private SqlCommand db_cmd = new SqlCommand();//定义数据库操作命令对象
        private SqlDataAdapter db_adp;//定义数据适配器
        private DataSet db_ds;//定义数据表
        private SqlDataReader reader;

        /**/
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void OpenDbConn()
        {
            CheckDbConn();
        }
        /**/
        /// <summary>
        /// 检查数据库连接与否
        /// </summary>
        /// <returns></returns>
        public bool CheckDbConn()
        {
            try
            {
                //实例化连接对象
                db_conn = new SqlConnection(FTEnv.DBADDRESS);
                db_cmd.Connection = db_conn;//初始化操作指令Data Source=localhost;Database=me_wyzx;User Id=medb;Pwd=me2008
                db_conn.Open();//打开连接
            }
            catch (Exception)
            {
                return false;//连接数据库失败
            }

            return true;//连接成功
        }
        /**/
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void CloseDbConn()
        {
            if (db_conn.State == ConnectionState.Open)
            {
                db_conn.Close();//关闭数据库连接
            }
            db_conn.Dispose();//释放连接对象的资源
            db_cmd.Dispose();//释放操作对象的资源
        }
        /**/
        /// <summary>
        /// 返一DATATABLE数据表集
        /// </summary>
        /// <param name="sqlText">传入的SQL语句</param>
        /// <returns></returns>
        public DataTable GetDbTable(string sqlText)
        {
            db_adp = new SqlDataAdapter();//实例化数据适配器与数据表集
            db_ds = new DataSet();
            db_ds.Clear();
            try
            {
                OpenDbConn();//打开连接
                db_cmd.CommandType = CommandType.Text;
                db_cmd.CommandText = sqlText;
                db_adp.SelectCommand = db_cmd;
                db_adp.Fill(db_ds, "db_Table");
            }
            catch (Exception)
            {
            }
            finally
            {
                db_adp.Dispose();//释放数据适配器的资源
                CloseDbConn();//关闭数据库连接
            }
            return db_ds.Tables["db_Table"];//返回数据表集
        }
    }
}
