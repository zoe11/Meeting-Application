using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FT_ENV;

namespace FTComponentSet
{
    public class DBCreater
    {
        private SqlConnection db_conn;//定义数据库连接对象
        private SqlCommand db_cmd = new SqlCommand();//定义数据库操作命令对象
        private SqlDataAdapter db_adp;//定义数据适配器
        private DataSet db_ds;//定义数据表
        private string _tableName;
        private Dictionary<object, object> _keyValue;
        private Dictionary<object, object> _keyOperator;
        private string _sql4Where;
        private Dictionary<object, object> _orderBy;
        private string _distinctCol;
        private List<string> _distinctCols;

       // private SqlDataReader reader;

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
        /// 
        //AllDatas
        //在增加了DISTINCT列时如果OrderBy列未包含DISTINCT列会异常，故在组装OrderBy时用到了&&String.IsNullOrEmpty(_distinctCol)
        public DataTable GetDbTableByDICName()
        {
            string sqlText = String.Empty;
            if (!String.IsNullOrEmpty(_distinctCol))
            {
                sqlText = "SELECT DISTINCT " + _distinctCol + " FROM " + _tableName;
            }
            else if (String.IsNullOrEmpty(_distinctCol)&&this._distinctCols!=null&&this._distinctCols.Count != 0)
            {
                sqlText = "SELECT DISTINCT ";
                for (int i = 0; i < _distinctCols.Count; i++)
                {
                    sqlText += _distinctCols[i] + ",";
                }
                sqlText = sqlText.Substring(0, sqlText.Length - 1);
                sqlText += " FROM " + _tableName;
            }
            else
            {
                sqlText = "SELECT * FROM " + _tableName;
            }

            if (this._orderBy != null && this._orderBy.Count != 0)
            {
                sqlText += " ORDER BY ";
                foreach (var item in _orderBy)
                {
                    sqlText += item.Key + " " + item.Value + ",";
                }
                sqlText = sqlText.Substring(0, sqlText.Length - 1);
            }
            
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

        public DataTable GetDbTableByKeyValue()
        {
            string sqlText = String.Empty;
            if (!String.IsNullOrEmpty(_distinctCol))
            {
                sqlText = "SELECT DISTINCT " + _distinctCol + " FROM " + _tableName + " WHERE ";
            }
            else if (String.IsNullOrEmpty(_distinctCol) && this._distinctCols != null && this._distinctCols.Count != 0)
            {
                sqlText = "SELECT DISTINCT ";
                for (int i = 0; i < _distinctCols.Count; i++)
                {
                    sqlText += _distinctCols[i] + ",";
                }
                sqlText = sqlText.Substring(0, sqlText.Length - 1);
                sqlText += " FROM " + _tableName + " WHERE ";
            }
            else
            {
                sqlText = "SELECT * FROM " + _tableName + " Where ";
            }
            IList<object> keys = _keyValue.Keys.ToList();
            int count = keys.Count;


            for (int i = 0; i < count; i++)
            {
                sqlText += keys[i] + "=" + "'" + _keyValue[keys[i]] + "'";
                if (i != count - 1)
                {
                    sqlText += "and ";
                }
            }
            if (this._orderBy != null && this._orderBy.Count != 0)
            {
                sqlText += " ORDER BY ";
                foreach (var item in _orderBy)
                {
                    sqlText += item.Key + " " + item.Value + ",";
                }
                sqlText = sqlText.Substring(0, sqlText.Length - 1);
            }
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

        public DataTable GetDbTableByKeyOperatorValue()
        {
            IList<object> keys = _keyValue.Keys.ToList();
            int count = keys.Count;
            string sqlText = String.Empty;
            if (!String.IsNullOrEmpty(_distinctCol))
            {
                sqlText = "SELECT DISTINCT " + _distinctCol + " FROM " + _tableName + " WHERE ";
            }
            else if (String.IsNullOrEmpty(_distinctCol) && this._distinctCols != null && this._distinctCols.Count != 0)
            {
                sqlText = "SELECT DISTINCT ";
                for (int i = 0; i < _distinctCols.Count; i++)
                {
                    sqlText += _distinctCols[i] + ",";
                }
                sqlText = sqlText.Substring(0, sqlText.Length - 1);
                sqlText += " FROM " + _tableName + " WHERE ";
            }
            else
            {
                sqlText = "SELECT * FROM " + _tableName + " Where ";
            }
            

            for (int i = 0; i < count; i++)
            {
                sqlText += keys[i] + " " + _keyOperator[keys[i]].ToString() + " " + "'" + _keyValue[keys[i]] + "'";
                if (i != count - 1)
                {
                    sqlText += "and ";
                }
            }
            if (this._orderBy != null && this._orderBy.Count != 0)
            {
                sqlText += " ORDER BY ";
                foreach (var item in _orderBy)
                {
                    sqlText += item.Key + " " + item.Value + ",";
                }
                sqlText = sqlText.Substring(0, sqlText.Length - 1);
            }
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

        public DataTable GetDbTableBySql4Where()
        {
            string sqlText = String.Empty;
            if (!String.IsNullOrEmpty(_distinctCol))
            {
                sqlText = "SELECT DISTINCT " + _distinctCol + " FROM " + _tableName + " WHERE " + _sql4Where;
            }
            else if (String.IsNullOrEmpty(_distinctCol) && this._distinctCols != null && this._distinctCols.Count != 0)
            {
                sqlText = "SELECT DISTINCT ";
                for (int i = 0; i < _distinctCols.Count; i++)
                {
                    sqlText += _distinctCols[i] + ",";
                }
                sqlText = sqlText.Substring(0, sqlText.Length - 1);
                sqlText += " FROM " + _tableName + " WHERE " + _sql4Where;
            }
            else
            {
                sqlText = "SELECT * FROM " + _tableName + " Where " + _sql4Where;
            }

            if (this._orderBy != null && this._orderBy.Count != 0 )
            {
                sqlText += " ORDER BY ";
                foreach (var item in _orderBy)
                {
                    sqlText += item.Key + " " + item.Value + ",";
                }
                sqlText = sqlText.Substring(0, sqlText.Length - 1);
            }
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

        
        //TopDatas
        public DataTable GetDbTable4TopTenByInput(string input, string viewColumn, int top)
        {
            string sqlText = String.Empty;
            if (!String.IsNullOrEmpty(_distinctCol))
            {
                sqlText = "SELECT DISTINCT TOP " + top + " " + _distinctCol + " FROM " + _tableName + " Where " + viewColumn + " Like" + "'" + input + "%" + "'";
            }
            else if (String.IsNullOrEmpty(_distinctCol) && this._distinctCols != null && this._distinctCols.Count != 0)
            {
                sqlText = "SELECT DISTINCT TOP " + top + " ";
                for (int i = 0; i < _distinctCols.Count; i++)
                {
                    sqlText +=  _distinctCols[i] + ",";
                }
                sqlText = sqlText.Substring(0, sqlText.Length - 1);
                sqlText += " FROM " + _tableName + " Where " + viewColumn + " Like" + "'" + input + "%" + "'";
            }
            else
            {
                sqlText = "SELECT TOP " + top + " * FROM " + _tableName + " Where " + viewColumn + " Like" + "'" + input + "%" + "'";
            }

            if (this._orderBy != null&&this._orderBy.Count !=0)
            {
                sqlText += " ORDER BY ";
                foreach (var item in _orderBy)
                {
                    sqlText += item.Key + " " + item.Value + ",";
                }
                sqlText = sqlText.Substring(0, sqlText.Length - 1);
            }
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

        public DataTable GetDbTable4TopTenByKeyValue(string input, string viewColumn,int top)
        {
            IList<object> keys = _keyValue.Keys.ToList();
            int count = keys.Count;
            string sqlText=String.Empty;
            if (!String.IsNullOrEmpty(_distinctCol))
            {
                sqlText = "SELECT DISTINCT TOP " + top + " " + _distinctCol + " FROM " + _tableName + " Where " + viewColumn + " Like" + "'" + input + "%" + "'" + " and ";
            }
            else if (String.IsNullOrEmpty(_distinctCol) && this._distinctCols != null && this._distinctCols.Count != 0)
            {
                sqlText = "SELECT DISTINCT TOP " + top + " ";
                for (int i = 0; i < _distinctCols.Count; i++)
                {
                    sqlText += _distinctCols[i] + ",";
                }
                sqlText = sqlText.Substring(0, sqlText.Length - 1);
                sqlText += " FROM " + _tableName + " Where " + viewColumn + " Like" + "'" + input + "%" + "'" + " and "; ;
            }
            else
            {
                sqlText = "SELECT TOP " + top + " * FROM " + _tableName + " Where " + viewColumn + " Like" + "'" + input + "%" + "'" + " and ";
            }
            

            for (int i = 0; i < count;i++ )
            {
                sqlText += keys[i] + "=" + "'" + _keyValue[keys[i]] + "'";
                if (i != count - 1)
                {
                    sqlText += "and ";
                }
            }
            if (this._orderBy != null && this._orderBy.Count != 0 )
            {
                sqlText += " ORDER BY ";
                foreach (var item in _orderBy)
                {
                    sqlText += item.Key + " " + item.Value + ",";
                }
                sqlText = sqlText.Substring(0, sqlText.Length - 1);
            }
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

        public DataTable GetDbTable4TopTenByKeyOperatorValue(string input, string viewColumn, int top)
        {
            IList<object> keys = _keyValue.Keys.ToList();
            int count = keys.Count;
            string sqlText=String.Empty;
            if (!String.IsNullOrEmpty(_distinctCol))
            {
                sqlText = "SELECT DISTINCT TOP " + top + " "+_distinctCol +" FROM " + _tableName + " Where " + viewColumn + " Like" + "'" + input + "%" + "'" + " and ";
            }
            else if (String.IsNullOrEmpty(_distinctCol) && this._distinctCols != null && this._distinctCols.Count != 0)
            {
                sqlText = "SELECT DISTINCT TOP " + top + " ";
                for (int i = 0; i < _distinctCols.Count; i++)
                {
                    sqlText += _distinctCols[i] + ",";
                }
                sqlText = sqlText.Substring(0, sqlText.Length - 1);
                sqlText += " FROM " + _tableName + " Where " + viewColumn + " Like" + "'" + input + "%" + "'" + " and "; ;
            }
            else
            {
                sqlText = "SELECT TOP " + top + " * FROM " + _tableName + " Where " + viewColumn + " Like" + "'" + input + "%" + "'" + " and ";
            }
            

            for (int i = 0; i < count; i++)
            {
                sqlText += keys[i] + " " + _keyOperator[keys[i]].ToString() + " " + "'" + _keyValue[keys[i]] + "'";
                if (i != count - 1)
                {
                    sqlText += "and ";
                }
            }
            if (this._orderBy != null && this._orderBy.Count != 0)
            {
                sqlText += " ORDER BY ";
                foreach (var item in _orderBy)
                {
                    sqlText += item.Key + " " + item.Value + ",";
                }
                sqlText = sqlText.Substring(0, sqlText.Length - 1);
            }
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

        public DataTable GetDbTable4TopTenBySql4Where(int top)
        {
            string sqlText = String.Empty;
            if (!String.IsNullOrEmpty(_distinctCol))
            {
                sqlText = "SELECT DISTINCT TOP " + top + " " + _distinctCol+" FROM " + _tableName + " Where " + _sql4Where;
            }
            else if (String.IsNullOrEmpty(_distinctCol) && this._distinctCols != null && this._distinctCols.Count != 0)
            {
                sqlText = "SELECT DISTINCT TOP " + top + " ";
                for (int i = 0; i < _distinctCols.Count; i++)
                {
                    sqlText += _distinctCols[i] + ",";
                }
                sqlText = sqlText.Substring(0, sqlText.Length - 1);
                sqlText += " FROM " + _tableName + " Where " + _sql4Where ;
            }
            else
            {
                sqlText = "SELECT TOP " + top + " * FROM " + _tableName + " Where " + _sql4Where;
            }

            if (this._orderBy != null && this._orderBy.Count != 0)
            {
                sqlText += " ORDER BY ";
                foreach (var item in _orderBy)
                {
                    sqlText += item.Key + " " + item.Value + ",";
                }
                sqlText = sqlText.Substring(0, sqlText.Length - 1);
            }
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
     

        public void SetTableName(string tableName)
        {
            this._tableName = tableName;
        }

        public void SetOrderBy(Dictionary<object,object> orderBy)
        {
            this._orderBy = orderBy;
        }

        public void DisposeOrderBy()
        {
            this._orderBy = null;
        }

        public void SetDistinctCol(string distinctCol)
        {
            this._distinctCol = distinctCol;
        }

        public void SetDistinctCols(List<string> distinctCols)
        {
            this._distinctCols = distinctCols;
        }

        public void DisposeDistinctCols()
        {
            this._distinctCol = String.Empty;
            this._distinctCols = null;
        }

        public void SetTableNameKeyAndValue(string tableName, Dictionary<object, object> keyValue)
        {
            this._tableName = tableName;
            this._keyValue = keyValue;
        }

        public void SetTableNameKeyOperatorValue(string tableName, Dictionary<object, object> keyOperator,Dictionary<object,object> keyValue)
        {
            this._tableName = tableName;
            this._keyValue = keyValue;
            this._keyOperator = keyOperator;
        }

        public void SetTableNameAndSql4Where(string tableName, string sql)
        {
            this._tableName = tableName;
            this._sql4Where = sql;
        }

    }
}
