using System;
using System.Data;
using System.Data.SqlClient;
using FT_ENV;
using System.Collections.Generic;

namespace FT_StoreProcess
{
    internal class DBBuilder
    {
        private SqlConnection db_conn;//定义数据库连接对象
        private SqlCommand db_cmd = new SqlCommand();//定义数据库操作命令对象
        private SqlDataAdapter db_adp;//定义数据适配器
        private DataSet db_ds;//定义数据表
        private SqlDataReader reader;


        public SqlCommand Db_cmd 
        {
            get
            {
                return this.db_cmd;
            }
        }
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
        internal bool CheckDbConn()
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
        internal void CloseDbConn()
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
        internal DataTable GetDbTable(string sqlText)
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
        
        //移到StoreProcessADO
        //internal object ExcuteStoreProcessByProcessName4NoReturn(string processName, IList<Dictionary<object, object>> parameters)
        //{
        //    try
        //    {
        //        OpenDbConn();
        //        db_cmd.CommandText = processName;
        //        db_cmd.CommandType = CommandType.StoredProcedure;

        //        if (parameters == null)
        //        {
        //            return db_cmd.ExecuteNonQuery();
        //        }
        //        else
        //        {
        //            for (int i = 0; i < parameters.Count; i++)
        //            {
        //                Dictionary<object, object> d = parameters[i];
        //                object key = d.Keys;
        //                object value = d.Values;
        //                db_cmd.Parameters.AddWithValue(key.ToString(), value);
        //            }
        //            return db_cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (System.Exception)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        CloseDbConn();
        //    }

        //}

        //internal void Pro_ProductionDemandAnalysisListSerial(string ISOID, string campOnLevelCode, string campOnLevel, string entryClerkID,string entryClerkName, ref string result)
        //{
        //    try
        //    {
        //        OpenDbConn();
        //        db_cmd.CommandText = "Pro_ProductionDemandAnalysisListSerial";
        //        db_cmd.CommandType = CommandType.StoredProcedure;
        //        db_cmd.Parameters.AddWithValue("@ISOID", ISOID);
        //        db_cmd.Parameters.AddWithValue("@CampOnLevelCode", campOnLevelCode);
        //        db_cmd.Parameters.AddWithValue("@CampOnLevel", campOnLevel);
        //        db_cmd.Parameters.AddWithValue("@EntryClerkID", entryClerkID);
        //        db_cmd.Parameters.AddWithValue("@EntryClerkName", entryClerkName);
        //        db_cmd.Parameters.Add(new SqlParameter("@ProductionDemandAnalysisListID", SqlDbType.NVarChar, 30, ParameterDirection.Output, false, 0, 0, "ProductionDemandAnalysisListID",DataRowVersion.Default,null));
        //        db_cmd.ExecuteNonQuery();
        //        result = db_cmd.Parameters["@ProductionDemandAnalysisListID"].Value.ToString();
        //    }
        //    catch (System.Exception)
        //    {
            	
        //    }
        //    finally
        //    {
        //        CloseDbConn();
        //    }

        //}

        //internal int Pro_ProductionDemandAnalysisList_Deliver(string ProductionDemandAnalysisListID, string operatorID,string operatorName)
        //{
        //    try
        //    {
        //        OpenDbConn();
        //        db_cmd.CommandText = "Pro_ProductionDemandAnalysisList_Deliver";
        //        db_cmd.CommandType = CommandType.StoredProcedure;
        //        db_cmd.Parameters.AddWithValue("@ProductionDemandAnalysisListID", ProductionDemandAnalysisListID);
        //        db_cmd.Parameters.AddWithValue("@OperatorID", operatorID);
        //        db_cmd.Parameters.AddWithValue("@OperatorName", operatorName);
        //        db_cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.Int, 32, ParameterDirection.Output, false, 0, 0, "result", DataRowVersion.Default, null));
        //        db_cmd.ExecuteNonQuery();
        //        int result = (int)db_cmd.Parameters["@result"].Value;
        //        return result;
        //    }
        //    catch (System.Exception)
        //    {
        //        return 0;
        //    }
        //    finally
        //    {
        //        CloseDbConn();
        //    }

        //}

        //internal bool Pro_CreateT_PurchaseList(string purchasePlanListID, string createOperatorID, string createOperatorName)
        //{
        //    try
        //    {
        //        OpenDbConn();
        //        db_cmd.CommandText = "Pro_CreateT_PurchaseList";
        //        db_cmd.CommandType = CommandType.StoredProcedure;
        //        db_cmd.Parameters.AddWithValue("@PurchasePlanListID", purchasePlanListID);
        //        db_cmd.Parameters.AddWithValue("@CreateOperatorID", createOperatorID);
        //        db_cmd.Parameters.AddWithValue("@CreateOperatorName", createOperatorName);             
        //        db_cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.Bit, 0, ParameterDirection.Output, false, 0, 0, "result", DataRowVersion.Default, null));
        //        db_cmd.ExecuteNonQuery();
        //        bool result = (bool)db_cmd.Parameters["@result"].Value;
        //        return result;
        //    }
        //    catch (System.Exception)
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        CloseDbConn();
        //    }

        //}

        //internal bool Pro_UpdatePurchaseListDemandDeliveryAccomplishStatus(string purchaseListID, string purchaseCarryOutListMaterialDetailsSID, string accomplishStatusModiOperatorID, string accomplishStatusModiOperatorName, DateTime accomplishStatusModiTime)
        //{
        //    try
        //    {
        //        OpenDbConn();
        //        db_cmd.CommandText = "Pro_UpdatePurchaseListDemandDeliveryAccomplishStatus";
        //        db_cmd.CommandType = CommandType.StoredProcedure;
        //        db_cmd.Parameters.AddWithValue("@PurchaseListID", purchaseListID);
        //        db_cmd.Parameters.AddWithValue("@PurchaseCarryOutListMaterialDetailsSID", purchaseCarryOutListMaterialDetailsSID);
        //        db_cmd.Parameters.AddWithValue("@AccomplishStatusModiOperatorID", accomplishStatusModiOperatorID);
        //        db_cmd.Parameters.AddWithValue("@AccomplishStatusModiOperatorName", accomplishStatusModiOperatorName);
        //        db_cmd.Parameters.AddWithValue("@AccomplishStatusModiTime", accomplishStatusModiTime);
        //        db_cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.Bit, 0, ParameterDirection.Output, false, 0, 0, "result", DataRowVersion.Default, null));
        //        db_cmd.ExecuteNonQuery();
        //        bool result = (bool)db_cmd.Parameters["@result"].Value;
        //        return result;
        //    }
        //    catch (System.Exception)
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        CloseDbConn();
        //    }

        //}

        //internal bool Pro_CreateT_ProductionPlanImplementTrackingList(string productionPlanListID, string operatorID, string operatorName)
        //{
        //    try
        //    {
        //        OpenDbConn();
        //        db_cmd.CommandText = "Pro_CreateT_ProductionPlanImplementTrackingList";
        //        db_cmd.CommandType = CommandType.StoredProcedure;
        //        db_cmd.Parameters.AddWithValue("@ProductionPlanListID", productionPlanListID);
        //        db_cmd.Parameters.AddWithValue("@OperatorID", operatorID);
        //        db_cmd.Parameters.AddWithValue("@OperatorName", operatorName);
        //        db_cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.Bit, 0, ParameterDirection.Output, false, 0, 0, "result", DataRowVersion.Default, null));
        //        db_cmd.ExecuteNonQuery();
        //        bool result = (bool)db_cmd.Parameters["@result"].Value;
        //        return result;
        //    }
        //    catch (System.Exception)
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        CloseDbConn();
        //    }

        //}

        //internal bool Pro_CreatePlanGetMaterialList(string ProcessFlowCardID)
        //{
        //    try
        //    {
        //        OpenDbConn();
        //        db_cmd.CommandText = "Pro_CreatePlanGetMaterialList";
        //        db_cmd.CommandType = CommandType.StoredProcedure;
        //        db_cmd.Parameters.AddWithValue("@ProcessFlowCardID", ProcessFlowCardID);
        //        db_cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.Bit, 0, ParameterDirection.Output, false, 0, 0, "result", DataRowVersion.Default, null));
        //        db_cmd.ExecuteNonQuery();
        //        bool result = (bool)db_cmd.Parameters["@result"].Value;
        //        return result;
        //    }
        //    catch (System.Exception)
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        CloseDbConn();
        //    }

        //}
    }


}
