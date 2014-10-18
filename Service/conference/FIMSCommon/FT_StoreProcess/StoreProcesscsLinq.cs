using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FT_ENV;

namespace FT_StoreProcess
{
    class StoreProcesscsLinq
    {
        #region 系统管理
        #endregion

        #region 工程管理
        internal  string Pro_BOMCircleCheck(string parentMaterialID,string parentMaterialVersion,string childMaterialID,string childMaterialVersion,string upOrDown)
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                string result= String.Empty;
                dc.Pro_BOMCircleCheck(parentMaterialID, parentMaterialVersion, childMaterialID, childMaterialVersion, upOrDown, ref result);
                return result;
            }
        }
        internal int Pro_GetSerialIDIntByProcessFlowCardTemplet()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByProcessFlowCardTemplet(ref serialID);
                return serialID.Value; 
            }
        }
        internal int Pro_GetSerialIDIntByAttachment()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByAttachment(ref result);
                return result.Value;
            }
        }
        internal int Pro_GetSerialIDIntByBOM()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByBOM(ref serialID);
                return serialID.Value;
            }
        }
        internal int Pro_GetSerialIDIntByMaterial()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByMaterial(ref serialID);
                return serialID.Value;
            }
        }
        internal int Pro_GetSerialIDIntByProcessFlowCardTempletDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByProcessFlowCardTempletDetails(ref serialID);
                return serialID.Value;
            }
        }
        internal string Pro_GetSerialIDNvarchar_Material(string MaterialPrefix)
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                string result = String.Empty;
                dc.Pro_GetSerialIDNvarchar_Material(MaterialPrefix, ref result);
                return result;
            }
        }
        internal int Pro_GetSerialIDIntByMaterialUnitRelation()
        {//物料单位换算流水号
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByMaterialUnitRelation(ref serialID);
                return serialID.Value;
            }
        }
        internal int Pro_GetSerialIDIntByMaterialVendorUnitRelation()
        {//供应商物料单位换算流水号
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByMaterialVendorUnitRelation(ref serialID);
                return serialID.Value;
            }
        }
        #endregion

        #region 销售管理
        internal int Pro_GetSerialIDIntByCustomerContacts()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByCustomerContacts(ref serialID);
                return serialID.Value;
            }
        }
        internal int Pro_GetSerialIDIntByInnerSalesOrderDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByInnerSalesOrderDetails(ref serialID);
                return serialID.Value;
            }
        }
        /// <summary>
        /// 客户发货通知单编号
        /// </summary>
        /// <returns></returns>
        internal string Pro_GetSerialIDNvarcharByCustomerDeliveryNotice()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByCustomerDeliveryNotice(ref result);
                return result;
            }
        }
        /// <summary>
        /// 内部销售订单物料明细单位登记流水号
        /// </summary>
        internal string Pro_GetSerialIDNvarcharByInnerSalesOrderDetailsUnits()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByInnerSalesOrderDetailsUnits(ref result);
                return result;
            }
        }
        /// <summary>
        /// 该存储过程产生字符串类型的销售目标设定表流水号
        /// </summary>
        internal string Pro_GetSerialIDNvarcharByPreSaleGoal()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByPreSaleGoal(ref result);
                return result;
            }
        }
        #endregion

        #region 采购管理
        internal string Pro_GetSeriaIDNvarcharByVendorInfo()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                string result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByVendorInfo(ref result);
                return result;
            }
        }
        // 该存储过程产生int类型的采购供应商明细单位登记表流水号
        internal int Pro_GetSerialIDIntByPurchaseListVendorDetailsUnits()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByPurchaseListVendorDetailsUnits(ref serialID);
                return serialID.Value;
            }
        }
        //该存储过程产生int类型的采购实施单物料明细单位登记表流水号
        internal int Pro_GetSerialIDIntByPurchaseCarryOutListMaterialDetailsUnits()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByPurchaseCarryOutListMaterialDetailsUnits(ref serialID);
                return serialID.Value;
            }
        }
        /// <summary>
        /// 该存储过程产生字符串类型的采购目标设定表流水号
        /// </summary>
        internal string Pro_GetSerialIDNvarcharByPrePurchaseGoal()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByPrePurchaseGoal(ref result);
                return result;
            }
        }
        #endregion

        #region 运营管理
        internal int Pro_GetSerialIDIntByProductionDemandAnalysisListConsumptionDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByProductionDemandAnalysisListConsumptionDetails(ref serialID);
                return serialID.Value;
            }
        }

        internal string Pro_GetSerialIDNvarcharByProductionPlanImplementList()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                string serialID = String.Empty;
                dc.Pro_GetSerialIDNvarcharByProductionPlanImplementList(ref serialID);
                return serialID;
            }
        }
        internal int Pro_GetSerialIDIntByProcessFlowDetailSerialList()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByProcessFlowDetailSerialList(ref serialID);
                return serialID.Value;
            }
        }
        internal string Pro_GetSerialIDNvarcharByProcessFlowDetailSerialListUnits()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                string serialID = String.Empty;
                dc.Pro_GetSerialIDNvarcharByProcessFlowDetailSerialListUnits(ref serialID);
                return serialID;
            }
        }
        #endregion

        #region 库存管理
        
        //库存明细单位转换
        internal string Pro_GetSerialIDNvarcharByStockDetailsUnits()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByStockDetailsUnits(ref result);
                return result;
            }
        }

        internal string Pro_GetSerialIDNvarcharByDefectiveGoodsStockDetailsUnits()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByDefectiveGoodsStockDetailsUnits(ref result);
                return result;
            }
        }
        
        //外部出库单号
        internal string Pro_GetSerialIDNvarcharByDeliveryOrderBill()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByDeliveryOrderBill(ref result);
                return result;
            }
        }

        //内部出库单号
        internal string Pro_GetSerialIDNvarcharByOutStockInList()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByOutStockInList(ref result);
                return result;
            }
        }

        //外部出货单明细登记流水号
        internal int Pro_GetSerialIDIntByDeliveryOrderBillDetailsRegister()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByDeliveryOrderBillDetailsRegister(ref result);
                return result.Value;
            }
        }

        //外部出货单明细流水号
        internal int Pro_GetSerialIDIntByDeliveryOrderBillDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByDeliveryOrderBillDetails(ref result);
                return result.Value;
            }
        }

        //外部入库单明细归属流水号
        internal int Pro_GetSerialIDIntByOutStockInListDetailsVesting()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByOutStockInListDetailsVesting(ref result);
                return result.Value;
            }
        }

        //外部入库单明细流水号
        internal int Pro_GetSerialIDIntByOutStockInListDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByOutStockInListDetails(ref result);
                return result.Value;
            }
        }

        ///////////////////////////////////////////////////////////////////////

        //库存入库登记流水号
        internal int Pro_GetSerialIDIntByStockInRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByStockInRecordDetails(ref serialID);
                return serialID.Value;
            }
        }

        //库存出库登记流水号
        internal int Pro_GetSerialIDIntByStockOutRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByStockOutRecordDetails(ref serialID);
                return serialID.Value;
            }
        }

        //实体预占入库登记流水号
        internal int Pro_GetSerialIDIntByEntityCampOnStockInRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByEntityCampOnStockInRecordDetails(ref serialID);
                return serialID.Value;
            }
        }

        //实体预占出库登记流水号
        internal int Pro_GetSerialIDIntByEntityCampOnStockOutRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByEntityCampOnStockOutRecordDetails(ref serialID);
                return serialID.Value;
            }
        }

        //实体自由入库登记流水号
        internal int Pro_GetSerialIDIntByEntityFreeStockInRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByEntityFreeStockInRecordDetails(ref serialID);
                return serialID.Value;
            }
        }

        //实体自由出库登记流水号
        internal int Pro_GetSerialIDIntByEntityFreeStockOutRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByEntityFreeStockOutRecordDetails(ref serialID);
                return serialID.Value;
            }
        }

        ////在制预占入库登记流水号
        internal int Pro_GetSerialIDIntByBeMadeCampOnStockInRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByBeMadeCampOnStockInRecordDetails(ref serialID);
                return serialID.Value;
            }
        }

        //在制预占出库登记流水号
        internal int Pro_GetSerialIDIntByBeMadeCampOnStockOutRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByBeMadeCampOnStockOutRecordDetails(ref serialID);
                return serialID.Value;
            }
        }

        //在制自由入库登记流水号
        internal int Pro_GetSerialIDIntByBeMadeFreeStockInRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByBeMadeFreeStockInRecordDetails(ref serialID);
                return serialID.Value;
            }
        }

        //在制自由出库登记流水号
        internal int Pro_GetSerialIDIntByBeMadeFreeStockOutRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByBeMadeFreeStockOutRecordDetails(ref serialID);
                return serialID.Value;
            }
        }
        //内部入库单号
        internal string Pro_GetSerialIDNvarcharByInternalStorageBill()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByInternalStorageBill(ref result);
                return result;
            }
        }
        //内部入库单明细流水号
        internal int Pro_GetSerialIDIntByInternalStorageBillDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByInternalStorageBillDetails(ref serialID);
                return serialID.Value;
            }
        }
        //内部出库单号
        internal string Pro_GetSerialIDNvarcharByInternalOutboundOrderBill()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByInternalOutboundOrderBill(ref result);
                return result;
            }
        }
        //内部出库单明细流水号
        internal int Pro_GetSerialIDIntByInternalOutboundOrderBillDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByInternalOutboundOrderBillDetails(ref serialID);
                return serialID.Value;
            }
        }
        //登记流水号
        internal int Pro_GetSerialIDIntByInternalOutboundOrderBillDetailsRegister()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByInternalOutboundOrderBillDetailsRegister(ref serialID);
                return serialID.Value;
            }
        }
        //不良品库存明细流水号
        internal int Pro_GetSerialIDIntByDefectiveGoodsStockDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByDefectiveGoodsStockDetails(ref serialID);
                return serialID.Value;
            }
        }
        //不良品库存入库登记明细流水号
        internal int Pro_GetSerialIDIntByDefectiveGoodsStockInRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByDefectiveGoodsStockInRecordDetails(ref serialID);
                return serialID.Value;
            }
        }
        //库存明细流水号
        internal int Pro_GetSerialIDIntByStockDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByStockDetails(ref serialID);
                return serialID.Value;
            }
        }
        //不良品库存出库登记明细流水号
        internal int Pro_GetSerialIDIntByDefectiveGoodsStockOutRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByDefectiveGoodsStockOutRecordDetails(ref serialID);
                return serialID.Value;
            }
        }
        //内部退料单明细流水号
        internal int Pro_GetSerialIDIntByInternalReturnMaterialBillDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByInternalReturnMaterialBillDetails(ref serialID);
                return serialID.Value;
            }
        }
        //内部退料单号
        internal string Pro_GetSerialIDNvarcharByInternalReturnMaterialBill()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByInternalReturnMaterialBill(ref result);
                return result;
            }
        }

        //盘点清单明细流水号
        internal string Pro_GetSerialIDNvarcharByStockCountBillDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByStockCountBillDetails(ref result);
                return result;
            }
        }
        //盘点分析流水号
        internal string Pro_GetSerialIDNvarcharByStockCountAnalysis()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByStockCountAnalysis(ref result);
                return result;
            }
        }
        //盘点清单号
        internal string Pro_GetSerialIDNvarcharByStockCountBill()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByStockCountBill(ref result);
                return result;
            }
        }
        //外部退货明细流水号
        internal int Pro_GetSerialIDIntByExternalReturnBillDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByExternalReturnBillDetails(ref result);
                return result.Value;
            }
        }
        //外部退货单编号
        internal string Pro_GetSerialIDNvarcharByExternalReturnBill()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByExternalReturnBill(ref result);
                return result;
            }
        }
        #endregion

        #region 质量管理

        internal int? Pro_GetSerialIDIntByMaterialDetermineCheckoutDetail()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByMaterialDetermineCheckoutDetail(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByMaterialAmountsCheckoutDetail()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByMaterialAmountsCheckoutDetail(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByIQCMaterialDetermineTheAmontCheckoutDetail()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByIQCMaterialDetermineTheAmontCheckoutDetail(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByIQCDetermineTheNatureDetail()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByIQCDetermineTheNatureDetail(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByIQCDefectiveMaterialClassifyStatistics()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByIQCDefectiveMaterialClassifyStatistics(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByFQCMaterialDetermineTheAmontCheckoutDetail()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByFQCMaterialDetermineTheAmontCheckoutDetail(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByFQCDetermineTheNatureDetail()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByFQCDetermineTheNatureDetail(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByFQCDefectiveMaterialClassifyStatistics()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByFQCDefectiveMaterialClassifyStatistics(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByIPQCMaterialDetermineTheAmontCheckoutDetail()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByIPQCMaterialDetermineTheAmontCheckoutDetail(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByIPQCDetermineTheNatureDetail()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByIPQCDetermineTheNatureDetail(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByIPQCDefectiveMaterialClassifyStatistics()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByIPQCDefectiveMaterialClassifyStatistics(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByStepOneTeamOrg()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByStepOneTeamOrg(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByStepTwoProblemDescription()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByStepTwoProblemDescription(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByStepTwoProblemDescriptionAttachment()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByStepTwoProblemDescriptionAttachment(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByStepThreeContainmentActions()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByStepThreeContainmentActions(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByStepThreeContainmentActionsAttachment()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByStepThreeContainmentActionsAttachment(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByStepFourRootCauses()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByStepFourRootCauses(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByStepFourRootCausesAttachment()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByStepFourRootCausesAttachment(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByStepFiveCorrectiveActions()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByStepFiveCorrectiveActions(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByStepFiveCorrectiveActionsAttachment()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByStepFiveCorrectiveActionsAttachment(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByStepSevenPreventiveActions()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByStepSevenPreventiveActions(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByStepSevenPreventiveActionsAttachment()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByStepSevenPreventiveActionsAttachment(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByStepEightReview()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByStepEightReview(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByStepEightReviewAttachment()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByStepEightReviewAttachment(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByInnerNotify_StepOneProDescription()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByInnerNotify_StepOneProDescription(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByInnerNotify_StepOneProDescriptionAttachment()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByInnerNotify_StepOneProDescriptionAttachment(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByInnerNotify_StepTwoTakeAction()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByInnerNotify_StepTwoTakeAction(ref result);
                return result;
            }
        }
        internal int? Pro_GetSerialIDIntByInnerNotify_StepTwoTakeActionAttachment()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByInnerNotify_StepTwoTakeActionAttachment(ref result);
                return result;
            }
        }
        internal int? Pro_GetSerialIDIntByInnerNotify_StepThreeSuspiciousMaterial()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByInnerNotify_StepThreeSuspiciousMaterial(ref result);
                return result;
            }
        }
        internal int? Pro_GetSerialIDIntByInnerNotify_StepFourRelevantOperatorSignaturecConfirmation()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByInnerNotify_StepFourRelevantOperatorSignaturecConfirmation(ref result);
                return result;
            }
        }

        internal string Pro_GetSerialIDNvarcharByIPQCBatchCheckout()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByIPQCBatchCheckout(ref result);
                return result;
            }
        }
        internal string Pro_GetSerialIDNvarcharByCorrectMeasureReport()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByCorrectMeasureReport(ref result);
                return result;
            }
        }
        internal string Pro_GetSerialIDNvarcharByInnerNotifyAndProcessReceipts()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByInnerNotifyAndProcessReceipts(ref result);
                return result;
            }
        }
        internal string Pro_GetSerialIDNvarcharByFQCBatchCheckout()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByFQCBatchCheckout(ref result);
                return result;
            }
        }
        internal string Pro_GetSerialIDNvarcharByOQCBatchCheckout()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByOQCBatchCheckout(ref result);
                return result;
            }
        }
        internal string Pro_GetSerialIDNvarcharByIQCBatchCheckout()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByIQCBatchCheckout(ref result);
                return result;
            }
        }

        //客户抱怨及问题通知单流水号
        internal string Pro_GetSerialIDNvarcharByCustomerNotifyAndProcessReceipts()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByCustomerNotifyAndProcessReceipts(ref result);
                return result;
            }
        }
        //问题描述流水号
        internal int? Pro_GetSerialIDIntByCustomerNotify_StepOneProDescription()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByCustomerNotify_StepOneProDescription(ref result);
                return result;
            }
        }
        //问题描述附件流水号
        internal int? Pro_GetSerialIDIntByCustomerNotify_StepOneProDescriptionAttachment()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByCustomerNotify_StepOneProDescriptionAttachment(ref result);
                return result;
            }
        }
        //采取行动描述流水号
        internal int? Pro_GetSerialIDIntByCustomerNotify_StepTwoTakeAction()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByCustomerNotify_StepTwoTakeAction(ref result);
                return result;
            }
        }
        //采取行动描述附件流水号
        internal int? Pro_GetSerialIDIntByCustomerNotify_StepTwoTakeActionAttachment()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByCustomerNotify_StepTwoTakeActionAttachment(ref result);
                return result;
            }
        }
        //采取行动描述附件流水号
        internal int? Pro_GetSerialIDIntByCustomerNotify_StepThreeSuspiciousMaterial()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByCustomerNotify_StepThreeSuspiciousMaterial(ref result);
                return result;
            }
        }
        //相关人员签字确认流水号
        internal int? Pro_GetSerialIDIntByCustomerNotify_StepFourSign()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByCustomerNotify_StepFourSign(ref result);
                return result;
            }
        }
        //供应商问题通知及处理单流水号
        internal string Pro_GetSerialIDNvarcharByVendorNotifyAndProcessReceipts()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByVendorNotifyAndProcessReceipts(ref result);
                return result;
            }
        }
        //问题描述流水号
        internal int? Pro_GetSerialIDIntByVendorNotify_StepOneProDescription()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByVendorNotify_StepOneProDescription(ref result);
                return result;
            }
        }
        //问题描述附件流水号
        internal int? Pro_GetSerialIDIntByVendorNotify_StepOneProDescriptionAttachment()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByVendorNotify_StepOneProDescriptionAttachment(ref result);
                return result;
            }
        }
        //采取行动描述流水号
        internal int? Pro_GetSerialIDIntByVendorNotify_StepTwoTakeAction()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByVendorNotify_StepTwoTakeAction(ref result);
                return result;
            }
        }
        //采取行动描述附件流水号
        internal int? Pro_GetSerialIDIntByVendorNotify_StepTwoTakeActionAttachment()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByVendorNotify_StepTwoTakeActionAttachment(ref result);
                return result;
            }
        }
        //可疑物料处理流水号
        internal int? Pro_GetSerialIDIntByVendorNotify_StepThreeSuspiciousMaterial()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByVendorNotify_StepThreeSuspiciousMaterial(ref result);
                return result;
            }
        }
        //相关人员签字确认流水号
        internal int? Pro_GetSerialIDIntByVendorNotify_StepFourSign()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByVendorNotify_StepFourSign(ref result);
                return result;
            }
        }
        //
        internal int? Pro_GetSerialIDIntByOQCDefectiveMaterialClassifyStatistics()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByOQCDefectiveMaterialClassifyStatistics(ref result);
                return result;
            }
        }
        //产生nvarchar类型的检验计划ID
        internal string Pro_GetSerialIDNvarcharByMateriaCheckoutPlan(string materialID, string materialVersion)
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                string serialID = String.Empty;
                dc.Pro_GetSerialIDNvarcharByMateriaCheckoutPlan(materialID,materialVersion,ref serialID);
                return serialID;
            }
        }
        #endregion

        #region 人事管理
        internal int? Pro_GetSerialIDIntByDepartment()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByDepartment(ref result);
                return result;
            }
        }
        internal int? Pro_GetSerialIDIntByDepContact()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByDepContact(ref result);
                return result;
            }
        }
        internal string Pro_GetSerialIDNvarcharByPost(int DepID, string JobCode)
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByPost(DepID,JobCode,ref result);
                return result;
            }
        }
        #endregion

        #region 消息
        internal string Pro_GetSerialIDNvarcharByMsgBox()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByMsgBox(ref result);
                return result;
            }
        }
        #endregion

        #region 资产管理
        /// <summary>
        /// 资产编号
        /// </summary>
        internal string Pro_GetSerialIDNvarcharByAssetsInfo(string assetTypeCode)
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByAssetsInfo(assetTypeCode, ref result);
                return result;
            }
        }

        /// <summary>
        /// 资产变动编号
        /// </summary>
        internal string Pro_GetSerialIDNvarcharByAssetsChangeDetail()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByAssetsChangeDetail(ref result);
                return result;
            }
        }

        #endregion

        #region 成本管理
        /// <summary>
        /// 包装成本流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByPackingCost()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByPackingCost(ref result);
                return result;
            }
        }
        /// <summary>
        /// 包装成本明细流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByPackingCostDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByPackingCostDetails(ref result);
                return result;
            }
        }
        /// <summary>
        /// 标准成本表流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByStandardCosts()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByStandardCosts(ref result);
                return result;
            }
        }
        /// <summary>
        /// 材料回收成本流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByRecycledMaterialCost()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByRecycledMaterialCost(ref result);
                return result;
            }
        }
        /// <summary>
        /// 材料回收成本明细流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByRecycledMaterialCostDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByRecycledMaterialCostDetails(ref result);
                return result;
            }
        }
        /// <summary>
        /// 辅助材料成本流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntBySubsidiaryMaterialCost()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntBySubsidiaryMaterialCost(ref result);
                return result;
            }
        }
        /// <summary>
        /// 辅助材料成本明细流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntBySubsidiaryMaterialCostDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntBySubsidiaryMaterialCostDetails(ref result);
                return result;
            }
        }
        /// <summary>
        /// 工具分摊成本流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByToolSharingCost()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByToolSharingCost(ref result);
                return result;
            }
        }
        /// <summary>
        /// 工具分摊成本明细流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByToolSharingCostDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByToolSharingCostDetails(ref result);
                return result;
            }
        }
        /// <summary>
        /// 工艺工序流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByProductionProcesses()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByProductionProcesses(ref result);
                return result;
            }
        }
        /// <summary>
        /// 管理成本流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByManagementCost()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByManagementCost(ref result);
                return result;
            }
        }
        /// <summary>
        /// 管理成本基数设置表流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByManagementCostCardinalateSet()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByManagementCostCardinalateSet(ref result);
                return result;
            }
        }
        /// <summary>
        /// 后处理成本流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByReprocessingCost()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByReprocessingCost(ref result);
                return result;
            }
        }
        /// <summary>
        /// 后处理成本明细流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByReprocessingCostDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByReprocessingCostDetails(ref result);
                return result;
            }
        }
        /// <summary>
        /// 汇率设置表流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByExchangeRateSet()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByExchangeRateSet(ref result);
                return result;
            }
        }
        /// <summary>
        /// 利润基数设置表流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByProfitBaseSet()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByProfitBaseSet(ref result);
                return result;
            }
        }
        /// <summary>
        /// 利润流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByProfit()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByProfit(ref result);
                return result;
            }
        }
        /// <summary>
        /// 设备加工成本流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByEquipmentManufacturingCost()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByEquipmentManufacturingCost(ref result);
                return result;
            }
        }
        /// <summary>
        /// 设备加工成本明细流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByEquipmentManufacturingCostDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByEquipmentManufacturingCostDetails(ref result);
                return result;
            }
        }
        /// <summary>
        /// 实际成本流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByActualCosts()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByActualCosts(ref result);
                return result;
            }
        }
        /// <summary>
        /// 原材料成本流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByRawMaterialCost()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByRawMaterialCost(ref result);
                return result;
            }
        }
        /// <summary>
        /// 原材料成本明细流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByRawMaterialCostDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByRawMaterialCostDetails(ref result);
                return result;
            }
        }
        /// <summary>
        /// 运输成本流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByTransportationCost()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByTransportationCost(ref result);
                return result;
            }
        }
        /// <summary>
        /// 运输成本明细流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByTransportationCostDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByTransportationCostDetails(ref result);
                return result;
            }
        }
        /// <summary>
        /// 直接人工成本流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByDirectLaborCost()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByDirectLaborCost(ref result);
                return result;
            }
        }
        /// <summary>
        /// 直接人工成本明细流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByDirectLaborCostDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByDirectLaborCostDetails(ref result);
                return result;
            }
        }
        /// <summary>
        /// 直接人工和设备加工设置表流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByDirectToolingAndEquipmentManufacturingSet()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByDirectToolingAndEquipmentManufacturingSet(ref result);
                return result;
            }
        }
        #endregion

        #region 工程变更
        /// <summary>
        /// 资产编号
        /// </summary>
        internal string Pro_GetSerialIDNvarcharByEngineerChangeApplyTable()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByEngineerChangeApplyTable(ref result);
                return result;
            }
        }

        /// <summary>
        /// 包装成本流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByEngineerChangeApplyTableDtails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByEngineerChangeApplyTableDtails(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByDocumentProvide()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByDocumentProvide(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByChangeBeforeAttachment()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByChangeBeforeAttachment(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByChangeAfterAttachment()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByChangeAfterAttachment(ref result);
                return result;
            }
        }

        #endregion 工程变更

        #region 公共管理-报废单
        /// <summary>
        /// 报废单编号
        /// </summary>
        internal string Pro_GetSerialIDNvarcharByAbateList()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByAbateList(ref result);
                return result;
            }
        }
        /// <summary>
        /// 报废单明细流水号
        /// </summary>
        internal int? Pro_GetSerialIDIntByAbateListMaterialDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByAbateListMaterialDetails(ref result);
                return result;
            }
        }
        #endregion

        #region 项目管理
        internal string Pro_GetSerialIDNvarcharByRFQProjectInfo()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByRFQProjectInfo(ref result);
                return result;
            }
        }
        internal int? Pro_GetSerialIDIntByRFQProjectTeamInfo()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByRFQProjectTeamInfo(ref result);
                return result;
            }
        }
        internal string Pro_GetSerialIDNvarcharByProcessQuoteParametersTable()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByProcessQuoteParametersTable(ref result);
                return result;
            }
        }
        internal int? Pro_GetSerialIDIntByProcessQuoteParametersDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByProcessQuoteParametersDetails(ref result);
                return result;
            }
        }
        internal string Pro_GetSerialIDNvarcharByPurchaseMaterialQuoteParametersTable()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByPurchaseMaterialQuoteParametersTable(ref result);
                return result;
            }
        }
        internal string Pro_GetSerialIDNvarcharByPurchaseMaterialQuoteParametersDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByPurchaseMaterialQuoteParametersDetails(ref result);
                return result;
            }
        }
        internal int? Pro_GetSerialIDIntByPurchaseQuoteParametersVendorDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByPurchaseQuoteParametersVendorDetails(ref result);
                return result;
            }
        }

        internal string Pro_GetSerialIDNvarcharByPurchaseQuoteDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByPurchaseQuoteDetails(ref result);
                return result;
            }
        }
        internal string Pro_GetSerialIDNvarcharByRawMaterialslQuoteDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByRawMaterialslQuoteDetails(ref result);
                return result;
            }
        }
        internal string Pro_GetSerialIDNvarcharByCustomerQuoteList()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByCustomerQuoteList(ref result);
                return result;
            }
        }
        internal int? Pro_GetSerialIDIntByCustomerQuoteListDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByCustomerQuoteListDetails(ref result);
                return result;
            }
        }
        internal string Pro_GetSerialIDNvarcharByToolProcessingQuote()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByToolProcessingQuote(ref result);
                return result;
            }
        }
        internal string Pro_GetSerialIDNvarcharByOtherQuote()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByOtherQuote(ref result);
                return result;
            }
        }
        internal string Pro_GetSerialIDNvarcharByUnitPriceQuote()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByUnitPriceQuote(ref result);
                return result;
            }
        }
        internal string Pro_GetSerialIDNvarcharByProcessingQuote()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByProcessingQuote(ref result);
                return result;
            }
        }

        internal int? Pro_GetSerialIDIntByRDProjectTeamInfo()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByRDProjectTeamInfo(ref result);
                return result;
            }
        }
        internal int? Pro_GetSerialIDIntByRDProjectProgressControlTable()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByRDProjectProgressControlTable(ref result);
                return result;
            }
        }
        #endregion

        #region 未归类

        internal  int Pro_GetSerialIDIntByEquipmentCheckList()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByEquipmentCheckList(ref serialID);
                return serialID.Value;
            }
        }
        
        //ERROR
        internal  int Pro_GetSerialIDIntByProductionDemandAnalysisListContributeAmountDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByProductionDemandAnalysisListContributeAmountDetails(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByProductionDemandAnalysisListDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByProductionDemandAnalysisListDetails(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByPurchaseCarryOutListMaterialDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByPurchaseCarryOutListMaterialDetails(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByPurchaseCarryOutListVendorDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByPurchaseCarryOutListVendorDetails(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByPurchasePlanListMaterialDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByPurchasePlanListMaterialDetails(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByPurchasePlanListVendorDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByPurchasePlanListVendorDetails(ref serialID);
                return serialID.Value;
            }
        }
        
        //....
        internal  int Pro_GetSerialIDIntByVendorContacts()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByVendorContacts(ref serialID);
                return serialID.Value;
            }
        }
        
        internal  string Pro_GetSerialIDNvarcharByCustomerInfo()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByCustomerInfo(ref result);
                return result;
            }
        }
        
        internal  string Pro_GetSerialIDNvarcharByInnerSalesOrder()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByInnerSalesOrder(ref result);
                return result;
            }
        }
        internal  string Pro_GetSerialIDNvarcharByMaterialCustomerPriceScheme(string materialID, string materialVersion)
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByMaterialCustomerPriceScheme(materialID,materialVersion,ref result);
                return result;
            }
        }
        internal string Pro_GetSerialIDNvarcharByMaterialPubPriceScheme(string materialID, string materialVersion)
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByMaterialPubPriceScheme(materialID, materialVersion, ref result);
                return result;
            }
        }
        internal  string Pro_GetSerialIDNvarcharByMaterialVendorPriceScheme(string materialID, string materialVersion)
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByMaterialVendorPriceScheme(materialID, materialVersion, ref result);
                return result;
            }
        }

        internal  string Pro_GetSerialIDNvarcharByProductionDemandAnalysisList()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                string result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByProductionDemandAnalysisList(ref result);
                return result;
            }
        }
        internal  string Pro_GetSerialIDNvarcharByPurchaseList()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                string result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByPurchaseList(ref result);
                return result;
            }
        }
        internal  string Pro_GetSerialIDNvarcharByPurchasePlanList()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                string result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByPurchasePlanList(ref result);
                return result;
            }
        }

        internal  int Pro_PreventRpeatLogin(string userID)
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                int? result = 0;
                dc.Pro_PreventRpeatLogin(userID,ref result);
                return result.Value;
            }
        }

        internal bool? Pro_UpdatePurchasePlanListDemandStockInAccomplishStatus(int? purchasePlanListMaterialDetailsSID, string accomplishStatusModiOperatorID, string accomplishStatusModiOperatorName, DateTime? accomplishStatusModiTime)
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext(FTEnv.DBADDRESS))
            {
                bool? result = false ;
                dc.Pro_UpdatePurchasePlanListDemandStockInAccomplishStatus(purchasePlanListMaterialDetailsSID,accomplishStatusModiOperatorID,accomplishStatusModiOperatorName,accomplishStatusModiTime,ref result);
                return result.Value;
            }
        }

        #endregion
    }
}