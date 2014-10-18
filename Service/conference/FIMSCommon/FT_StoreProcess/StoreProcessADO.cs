using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FT_StoreProcess
{
    class StoreProcessADO
    {
        private DBBuilder db = new DBBuilder();


        #region 公共模块
        internal object ExcuteStoreProcessByProcessName4NoReturn(string processName, IList<Dictionary<object, object>> parameters)
        {
            //return db.ExcuteStoreProcessByProcessName4NoReturn(processName, parameters);
            try
            {
                db.OpenDbConn();
                db.Db_cmd.CommandText = processName;
                db.Db_cmd.CommandType = CommandType.StoredProcedure;

                if (parameters == null)
                {
                    return db.Db_cmd.ExecuteNonQuery();
                }
                else
                {
                    for (int i = 0; i < parameters.Count; i++)
                    {
                        Dictionary<object, object> d = parameters[i];
                        object key = d.Keys;
                        object value = d.Values;
                        db.Db_cmd.Parameters.AddWithValue(key.ToString(), value);
                    }
                    return db.Db_cmd.ExecuteNonQuery();
                }
            }
            catch (System.Exception)
            {
                return null;
            }
            finally
            {
                db.CloseDbConn();
            }
        }
        #endregion

        #region 销售管理
        #endregion

        #region 采购管理
        internal bool Pro_CreateT_PurchaseList(string purchasePlanListID, string createOperatorID, string createOperatorName)
        {
            //return db.Pro_CreateT_PurchaseList(purchasePlanListID, createOperatorID, createOperatorName);
            try
            {
                db.OpenDbConn();
                db.Db_cmd.CommandText = "Pro_CreateT_PurchaseList";
                db.Db_cmd.CommandType = CommandType.StoredProcedure;
                db.Db_cmd.Parameters.AddWithValue("@PurchasePlanListID", purchasePlanListID);
                db.Db_cmd.Parameters.AddWithValue("@CreateOperatorID", createOperatorID);
                db.Db_cmd.Parameters.AddWithValue("@CreateOperatorName", createOperatorName);
                db.Db_cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.Bit, 0, ParameterDirection.Output, false, 0, 0, "result", DataRowVersion.Default, null));
                db.Db_cmd.ExecuteNonQuery();
                bool result = (bool)db.Db_cmd.Parameters["@result"].Value;
                return result;
            }
            catch (System.Exception)
            {
                return false;
            }
            finally
            {
                db.CloseDbConn();
            }
        }

        internal bool Pro_UpdatePurchaseListDemandDeliveryAccomplishStatus(string purchaseListID, string purchaseCarryOutListMaterialDetailsSID, string accomplishStatusModiOperatorID, string accomplishStatusModiOperatorName, DateTime accomplishStatusModiTime)
        {
            //return db.Pro_UpdatePurchaseListDemandDeliveryAccomplishStatus(purchaseListID, purchaseCarryOutListMaterialDetailsSID, accomplishStatusModiOperatorID, accomplishStatusModiOperatorName, accomplishStatusModiTime);
            try
            {
                db.OpenDbConn();
                db.Db_cmd.CommandText = "Pro_UpdatePurchaseListDemandDeliveryAccomplishStatus";
                db.Db_cmd.CommandType = CommandType.StoredProcedure;
                db.Db_cmd.Parameters.AddWithValue("@PurchaseListID", purchaseListID);
                db.Db_cmd.Parameters.AddWithValue("@PurchaseCarryOutListMaterialDetailsSID", purchaseCarryOutListMaterialDetailsSID);
                db.Db_cmd.Parameters.AddWithValue("@AccomplishStatusModiOperatorID", accomplishStatusModiOperatorID);
                db.Db_cmd.Parameters.AddWithValue("@AccomplishStatusModiOperatorName", accomplishStatusModiOperatorName);
                db.Db_cmd.Parameters.AddWithValue("@AccomplishStatusModiTime", accomplishStatusModiTime);
                db.Db_cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.Bit, 0, ParameterDirection.Output, false, 0, 0, "result", DataRowVersion.Default, null));
                db.Db_cmd.ExecuteNonQuery();
                bool result = (bool)db.Db_cmd.Parameters["@result"].Value;
                return result;
            }
            catch (System.Exception)
            {
                return false;
            }
            finally
            {
                db.CloseDbConn();
            }
        }
        #endregion

        #region 运营管理
        internal void Pro_ProductionDemandAnalysisListSerial(string ISOID, string campOnLevelCode, string campOnLevel, string entryClerkID, string entryClerkName, ref string result)
        {
            //db.Pro_ProductionDemandAnalysisListSerial(ISOID, campOnLevelCode, campOnLevel, entryClerkID, entryClerkName, ref result);
            try
            {
                db.OpenDbConn();
                db.Db_cmd.CommandText = "Pro_ProductionDemandAnalysisListSerial";
                db.Db_cmd.CommandType = CommandType.StoredProcedure;
                db.Db_cmd.Parameters.AddWithValue("@ISOID", ISOID);
                db.Db_cmd.Parameters.AddWithValue("@CampOnLevelCode", campOnLevelCode);
                db.Db_cmd.Parameters.AddWithValue("@CampOnLevel", campOnLevel);
                db.Db_cmd.Parameters.AddWithValue("@EntryClerkID", entryClerkID);
                db.Db_cmd.Parameters.AddWithValue("@EntryClerkName", entryClerkName);
                db.Db_cmd.Parameters.Add(new SqlParameter("@ProductionDemandAnalysisListID", SqlDbType.NVarChar, 30, ParameterDirection.Output, false, 0, 0, "ProductionDemandAnalysisListID", DataRowVersion.Default, null));
                db.Db_cmd.ExecuteNonQuery();
                result = db.Db_cmd.Parameters["@ProductionDemandAnalysisListID"].Value.ToString();
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                db.CloseDbConn();
            }
        }

        internal int Pro_ProductionDemandAnalysisList_Deliver(string ProductionDemandAnalysisListID, string operatorID, string operatorName, ref int purresult, ref int proresult)
        {
            //return db.Pro_ProductionDemandAnalysisList_Deliver(ProductionDemandAnalysisListID, operatorID, operatorName);
            try
            {
                db.OpenDbConn();
                db.Db_cmd.CommandText = "Pro_ProductionDemandAnalysisList_Deliver";
                db.Db_cmd.CommandType = CommandType.StoredProcedure;
                db.Db_cmd.Parameters.AddWithValue("@ProductionDemandAnalysisListID", ProductionDemandAnalysisListID);
                db.Db_cmd.Parameters.AddWithValue("@OperatorID", operatorID);
                db.Db_cmd.Parameters.AddWithValue("@OperatorName", operatorName);
                db.Db_cmd.Parameters.Add(new SqlParameter("@Purresult", SqlDbType.Int, 32, ParameterDirection.Output, false, 0, 0, "result", DataRowVersion.Default, null));
                db.Db_cmd.Parameters.Add(new SqlParameter("@Proresult", SqlDbType.Int, 32, ParameterDirection.Output, false, 0, 0, "result", DataRowVersion.Default, null));
                db.Db_cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.Int, 32, ParameterDirection.Output, false, 0, 0, "result", DataRowVersion.Default, null));
                db.Db_cmd.ExecuteNonQuery();
                int result = (int)db.Db_cmd.Parameters["@result"].Value;
                purresult = (int)db.Db_cmd.Parameters["@Purresult"].Value;
                proresult = (int)db.Db_cmd.Parameters["@Proresult"].Value;
                return result;
            }
            catch (System.Exception)
            {
                return 0;
            }
            finally
            {
                db.CloseDbConn();
            }
        }

        /// <summary>
        /// 生成生产计划实施跟踪单
        /// </summary>
        /// <param name="productionPlanListID"></param>
        /// <param name="operatorID"></param>
        /// <param name="operatorName"></param>
        /// <returns></returns>
        internal bool Pro_CreateT_ProductionPlanImplementTrackingList(string productionPlanListID)
        {
            //return db.Pro_CreateT_ProductionPlanImplementTrackingList(productionPlanListID, operatorID, operatorName);
            try
            {
                db.OpenDbConn();
                db.Db_cmd.CommandText = "Pro_CreateT_ProductionPlanImplementTrackingList";
                db.Db_cmd.CommandType = CommandType.StoredProcedure;
                db.Db_cmd.Parameters.AddWithValue("@ProductionPlanListID", productionPlanListID);
                db.Db_cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.Bit, 0, ParameterDirection.Output, false, 0, 0, "result", DataRowVersion.Default, null));
                db.Db_cmd.ExecuteNonQuery();
                bool result = (bool)db.Db_cmd.Parameters["@result"].Value;
                return result;
            }
            catch (System.Exception)
            {
                return false;
            }
            finally
            {
                db.CloseDbConn();
            }
        }

        /// <summary>
        /// 生成计划领料单
        /// </summary>
        /// <param name="processFlowCardID"></param>
        /// <returns></returns>
        internal bool Pro_CreateT_PlanGetMaterialList(string processFlowCardID)
        {
            //return db.Pro_CreatePlanGetMaterialList(processFlowCardID);
            try
            {
                db.OpenDbConn();
                db.Db_cmd.CommandText = "Pro_CreateT_PlanGetMaterialList";
                db.Db_cmd.CommandType = CommandType.StoredProcedure;
                db.Db_cmd.Parameters.AddWithValue("@ProcessFlowCardID", processFlowCardID);
                db.Db_cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.Bit, 0, ParameterDirection.Output, false, 0, 0, "result", DataRowVersion.Default, null));
                db.Db_cmd.ExecuteNonQuery();
                bool result = (bool)db.Db_cmd.Parameters["@result"].Value;
                return result;
            }
            catch (System.Exception)
            {
                return false;
            }
            finally
            {
                db.CloseDbConn();
            }
        }

        internal bool Pro_Get_ExtMaterialInfo(string ISOID, string materialID, string materialVersion, out string extMaterialID, out string extMaterialVersion)
        {
            //return db.Pro_CreatePlanGetMaterialList(processFlowCardID);
            try
            {
                db.OpenDbConn();
                db.Db_cmd.CommandText = "Pro_Get_ExtMaterialInfo";
                db.Db_cmd.CommandType = CommandType.StoredProcedure;
                db.Db_cmd.Parameters.AddWithValue("@ISOID", ISOID);
                db.Db_cmd.Parameters.AddWithValue("@MaterialID", materialID);
                db.Db_cmd.Parameters.AddWithValue("@MaterialVersion", materialVersion);
                db.Db_cmd.Parameters.Add(new SqlParameter("@ExtMaterialID", SqlDbType.NVarChar, 20, ParameterDirection.Output, false, 0, 0, "ExtMaterialID", DataRowVersion.Default, null));
                db.Db_cmd.Parameters.Add(new SqlParameter("@ExtMaterialVersion", SqlDbType.NVarChar, 30, ParameterDirection.Output, false, 0, 0, "ExtMaterialID", DataRowVersion.Default, null));
                db.Db_cmd.ExecuteNonQuery();
                extMaterialID = (string)db.Db_cmd.Parameters["@ExtMaterialID"].Value;
                extMaterialVersion = (string)db.Db_cmd.Parameters["@ExtMaterialVersion"].Value;
                return true;
            }
            catch (System.Exception e)
            {
                extMaterialID = "";
                extMaterialVersion = "";
                return true;
            }
            finally
            {
                db.CloseDbConn();
                db.Db_cmd.Parameters.Clear();
            }
        }

        #endregion

        #region 库存管理
        // 生成盘点明细
        internal bool Pro_createT_StockCountBillDetails(string StockCountBillID, string OperatorID, string OperatorName, string MaterialTypeCode, string MaterialDetailTypeCode, string MaterialResourceCode, string MaterialID, string MaterialVersion, string BatchID, string Bar)
        {
            try
            {
                db.OpenDbConn();
                db.Db_cmd.CommandText = "Pro_createT_StockCountBillDetails";
                db.Db_cmd.CommandType = CommandType.StoredProcedure;
                db.Db_cmd.Parameters.AddWithValue("@StockCountBillID", StockCountBillID);
                db.Db_cmd.Parameters.AddWithValue("@OperatorID", OperatorID);
                db.Db_cmd.Parameters.AddWithValue("@OperatorName", OperatorName);
                db.Db_cmd.Parameters.AddWithValue("@MaterialTypeCode", MaterialTypeCode);
                db.Db_cmd.Parameters.AddWithValue("@MaterialDetailTypeCode", MaterialDetailTypeCode);
                db.Db_cmd.Parameters.AddWithValue("@MaterialResourceCode", MaterialResourceCode);
                db.Db_cmd.Parameters.AddWithValue("@MaterialID", MaterialID);
                db.Db_cmd.Parameters.AddWithValue("@MaterialVersion", MaterialVersion);
                db.Db_cmd.Parameters.AddWithValue("@BatchID", BatchID);
                db.Db_cmd.Parameters.AddWithValue("@Bar", Bar);
                db.Db_cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.Bit, 0, ParameterDirection.Output, false, 0, 0, "result", DataRowVersion.Default, null));
                db.Db_cmd.ExecuteNonQuery();
                bool result = (bool)db.Db_cmd.Parameters["@result"].Value;
                return result;
            }
            catch (System.Exception)
            {
                return false;
            }
            finally
            {
                db.CloseDbConn();
            }
        }
        #endregion

        #region 质量管理
        /// <summary>
        /// 生成定性检验记录和定量检验记录
        /// </summary>
        /// <param name="CheckoutPlanTypeID"></param>
        /// <param name="BatchID"></param>
        /// <param name="MaterialID"></param>
        /// <param name="MaterialVersion"></param>
        /// <param name="result"></param>
        internal int Pro_CreateXQC_DetermineTheXXXCheckoutDetail(string CheckoutPlanTypeID, string BatchID, int SampleAmount, string MaterialID, string MaterialVersion, int WorkStageID)
        {
            try
            {
                db.OpenDbConn();
                db.Db_cmd.CommandText = "Pro_CreateXQC_DetermineTheXXXCheckoutDetail";
                db.Db_cmd.CommandType = CommandType.StoredProcedure;
                db.Db_cmd.Parameters.AddWithValue("@CheckoutPlanTypeID", CheckoutPlanTypeID);
                db.Db_cmd.Parameters.AddWithValue("@BatchID", BatchID);
                db.Db_cmd.Parameters.AddWithValue("@SampleAmount", SampleAmount);
                db.Db_cmd.Parameters.AddWithValue("@MaterialID", MaterialID);
                db.Db_cmd.Parameters.AddWithValue("@MaterialVersion", MaterialVersion);
                db.Db_cmd.Parameters.AddWithValue("@WorkstageID", WorkStageID);
                db.Db_cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.NVarChar, 30, ParameterDirection.Output, false, 0, 0, "result", DataRowVersion.Default, null));
                db.Db_cmd.ExecuteNonQuery();
                int result = Convert.ToInt32(db.Db_cmd.Parameters["@result"].Value);
                return result;
            }
            catch (System.Exception)
            {
                return 0;
            }
            finally
            {
                db.CloseDbConn();
            }
        }

        /// <summary>
        /// 生成定性检验记录和定量检验记录
        /// </summary>
        /// <param name="CheckoutPlanTypeID"></param>
        /// <param name="BatchID"></param>
        /// <param name="MaterialID"></param>
        /// <param name="MaterialVersion"></param>
        /// <param name="result"></param>
        internal int Pro_CreateXQC_DetermineTheXXXCheckoutDetail(string CheckoutPlanTypeID, string BatchID, int SampleAmount, string MaterialID, string MaterialVersion)
        {
            try
            {
                db.OpenDbConn();
                db.Db_cmd.CommandText = "Pro_CreateXQC_DetermineTheXXXCheckoutDetail";
                db.Db_cmd.CommandType = CommandType.StoredProcedure;
                db.Db_cmd.Parameters.AddWithValue("@CheckoutPlanTypeID", CheckoutPlanTypeID);
                db.Db_cmd.Parameters.AddWithValue("@BatchID", BatchID);
                db.Db_cmd.Parameters.AddWithValue("@SampleAmount", SampleAmount);
                db.Db_cmd.Parameters.AddWithValue("@MaterialID", MaterialID);
                db.Db_cmd.Parameters.AddWithValue("@MaterialVersion", MaterialVersion);
                db.Db_cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.NVarChar, 30, ParameterDirection.Output, false, 0, 0, "result", DataRowVersion.Default, null));
                db.Db_cmd.ExecuteNonQuery();
                int result = Convert.ToInt32(db.Db_cmd.Parameters["@result"].Value);
                return result;
            }
            catch (System.Exception)
            {
                return 0;
            }
            finally
            {
                db.CloseDbConn();
            }
        }

        /// <summary>
        /// 检查是否修改FQC对应的内部入库单的系统状态
        /// </summary>
        /// <param name="InternalStorageBillID">内部入库单号</param>
        /// <returns>为1表示已经修改，为0表示不需要修改</returns>
        internal int Pro_FQC_InternalStorageBill_SystemStatus(string InternalStorageBillID)
        {
            try
            {
                db.OpenDbConn();
                db.Db_cmd.CommandText = "Pro_FQC_InternalStorageBill_SystemStatus";
                db.Db_cmd.CommandType = CommandType.StoredProcedure;
                db.Db_cmd.Parameters.AddWithValue("@InternalStorageBillID", InternalStorageBillID);
                db.Db_cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.NVarChar, 30, ParameterDirection.Output, false, 0, 0, "result", DataRowVersion.Default, null));
                db.Db_cmd.ExecuteNonQuery();
                int result = Convert.ToInt32(db.Db_cmd.Parameters["@result"].Value);
                return result;
            }
            catch (System.Exception)
            {
                return 0;
            }
            finally
            {
                db.CloseDbConn();
            }
        }

        /// <summary>
        /// 检查是否修改IQC对应的外部入库单的系统状态
        /// </summary>
        /// <param name="OutStockInListID">外部入库单单号</param>
        /// <returns>为1表示已经修改，为0表示不需要修改</returns>
        internal int Pro_IQC_OutStockInList_SystemStatus(string OutStockInListID)
        {
            try
            {
                db.OpenDbConn();
                db.Db_cmd.CommandText = "Pro_IQC_OutStockInList_SystemStatus";
                db.Db_cmd.CommandType = CommandType.StoredProcedure;
                db.Db_cmd.Parameters.AddWithValue("@OutStockInListID", OutStockInListID);
                db.Db_cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.NVarChar, 30, ParameterDirection.Output, false, 0, 0, "result", DataRowVersion.Default, null));
                db.Db_cmd.ExecuteNonQuery();
                int result = Convert.ToInt32(db.Db_cmd.Parameters["@result"].Value);
                return result;
            }
            catch (System.Exception)
            {
                return 0;
            }
            finally
            {
                db.CloseDbConn();
            }
        }

        /// <summary>
        /// 检查是否修改OQC对应的外部出货单的系统状态
        /// </summary>
        /// <param name="DOBID">检查是否修改OQC对应的外部出货单的系统状态</param>
        /// <returns>为1表示已经修改，为0表示不需要修改</returns>
        internal int Pro_OQC_DeliveryOrderBill_SystemStatus(string DOBID)
        {
            try
            {
                db.OpenDbConn();
                db.Db_cmd.CommandText = "Pro_OQC_DeliveryOrderBill_SystemStatus";
                db.Db_cmd.CommandType = CommandType.StoredProcedure;
                db.Db_cmd.Parameters.AddWithValue("@DOBID", DOBID);
                db.Db_cmd.Parameters.Add(new SqlParameter("@result", SqlDbType.NVarChar, 30, ParameterDirection.Output, false, 0, 0, "result", DataRowVersion.Default, null));
                db.Db_cmd.ExecuteNonQuery();
                int result = Convert.ToInt32(db.Db_cmd.Parameters["@result"].Value);
                return result;
            }
            catch (System.Exception)
            {
                return 0;
            }
            finally
            {
                db.CloseDbConn();
            }
        }
        #endregion
    }
}