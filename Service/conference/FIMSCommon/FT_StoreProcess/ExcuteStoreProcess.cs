using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FT_StoreProcess
{
    public class ExcuteStoreProcess
    {
        private StoreProcesscsLinq storeProcessLinq = new StoreProcesscsLinq();
        private StoreProcessADO storeProcessADO = new StoreProcessADO();

        #region 生成流水号 无参数
        public object GetSerialIDByStoreProcessName(StoreProcessEnum enumArg)
        {
            #region 工程管理
            if (enumArg == StoreProcessEnum.GetSerialIDIntByBOM)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByBOM();
            }
            else if (enumArg == StoreProcessEnum.GetSerialIDIntByMaterial)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByMaterial();
            }
            else if (enumArg == StoreProcessEnum.GetSerialIDIntByAttachment)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByAttachment();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByProcessFlowCardTempletDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByProcessFlowCardTempletDetails();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByProcessFlowCardTemplet)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByProcessFlowCardTemplet();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByInternalReturnMaterialBillDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByInternalReturnMaterialBillDetails();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByInternalReturnMaterialBill)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByInternalReturnMaterialBill();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByMaterialVendorUnitRelation)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByMaterialVendorUnitRelation();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByMaterialUnitRelation)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByMaterialUnitRelation();
            }
            #endregion

            #region 库存管理
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByStockDetailsUnits)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByStockDetailsUnits();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByDefectiveGoodsStockDetailsUnits)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByDefectiveGoodsStockDetailsUnits();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDIntByStockOutRecordDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByStockOutRecordDetails();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDIntByStockInRecordDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByStockInRecordDetails();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDIntByEntityCampOnStockOutRecordDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByEntityCampOnStockOutRecordDetails();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDIntByEntityCampOnStockInRecordDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByEntityCampOnStockInRecordDetails();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDIntByEntityFreeStockOutRecordDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByEntityFreeStockOutRecordDetails();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDIntByEntityFreeStockInRecordDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByEntityFreeStockInRecordDetails();
            }
            else if (enumArg == StoreProcessEnum.GetSerialIDIntByBeMadeCampOnStockOutRecordDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByBeMadeCampOnStockOutRecordDetails();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDIntByBeMadeCampOnStockInRecordDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByBeMadeCampOnStockInRecordDetails();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDIntByBeMadeFreeStockOutRecordDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByBeMadeFreeStockOutRecordDetails();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDIntByBeMadeFreeStockInRecordDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByBeMadeFreeStockInRecordDetails();
            }
            //
            else if (enumArg == StoreProcessEnum.GetSerialIDNvarcharByDeliveryOrderBill)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByDeliveryOrderBill();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDNvarcharByOutStockInList)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByOutStockInList();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDIntByDeliveryOrderBillDetailsRegister)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByDeliveryOrderBillDetailsRegister();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDIntByDeliveryOrderBillDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByDeliveryOrderBillDetails();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDIntByOutStockInListDetailsVesting)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByOutStockInListDetailsVesting();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDIntByOutStockInListDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByOutStockInListDetails();
            }
            //库存 内部入库单号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByInternalStorageBill)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByInternalStorageBill();
            }
            //库存 内部入库单明细流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByInternalStorageBillDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByInternalStorageBillDetails();
            }
            //库存 内部出库单号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByInternalOutboundOrderBill)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByInternalOutboundOrderBill();
            }
            //库存 内部出库单明细流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByInternalOutboundOrderBillDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByInternalOutboundOrderBillDetails();
            }
            //库存 登记流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByInternalOutboundOrderBillDetailsRegister)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByInternalOutboundOrderBillDetailsRegister();
            }
            //库存 不良品库存明细流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByDefectiveGoodsStockDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByDefectiveGoodsStockDetails();
            }
            //库存 不良品库存入库登记明细流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByDefectiveGoodsStockInRecordDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByDefectiveGoodsStockInRecordDetails();
            }
            //库存 库存明细流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByStockDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByStockDetails();
            }
            //库存 不良品库存出库登记明细流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByDefectiveGoodsStockOutRecordDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByDefectiveGoodsStockOutRecordDetails();
            }

            //库存 盘点清单明细流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByStockCountBillDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByStockCountBillDetails();
            }
            //库存 盘点分析流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByStockCountAnalysis)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByStockCountAnalysis();
            }
            //库存 盘点清单号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByStockCountBill)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByStockCountBill();
            }
            //库存 外部退货明细流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByExternalReturnBillDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByExternalReturnBillDetails();
            }
            //库存 外部退货单编号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByExternalReturnBill)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByExternalReturnBill();
            }
            #endregion

            #region 销售管理
            else if (enumArg == StoreProcessEnum.GetSerialIDIntByCustomerContacts)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByCustomerContacts();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDIntByInnerSalesOrderDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByInnerSalesOrderDetails();
            }
            else if (enumArg == StoreProcessEnum.GetSerialIDNvarcharByCustomerInfo)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByCustomerInfo();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDNvarcharByVendorInfo)
            {
                return storeProcessLinq.Pro_GetSeriaIDNvarcharByVendorInfo();
            }

            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByCustomerDeliveryNotice)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByCustomerDeliveryNotice();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByInnerSalesOrderDetailsUnits)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByInnerSalesOrderDetailsUnits();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByPreSaleGoal)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByPreSaleGoal();
            }
            #endregion

            #region 采购管理
            else if (enumArg == StoreProcessEnum.GetSerialIDIntByVendorContacts)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByVendorContacts();
            }
            else if (enumArg == StoreProcessEnum.GetSerialIDIntByPurchasePlanListVendorDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByPurchasePlanListVendorDetails();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDIntByPurchasePlanListMaterialDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByPurchasePlanListMaterialDetails();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDIntByPurchaseCarryOutListVendorDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByPurchaseCarryOutListVendorDetails();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDIntByPurchaseCarryOutListMaterialDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByPurchaseCarryOutListMaterialDetails();
            }
            else if (enumArg == StoreProcessEnum.GetSerialIDNvarcharByPurchasePlanList)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByPurchasePlanList();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDNvarcharByPurchaseList)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByPurchaseList();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDNvarcharByInnerSalesOrder)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByInnerSalesOrder();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDNvarcharByProductionDemandAnalysisList)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByProductionDemandAnalysisList();
            }
            // 该存储过程产生int类型的采购供应商明细单位登记表流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByPurchaseListVendorDetailsUnits)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByPurchaseListVendorDetailsUnits();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByPurchaseCarryOutListMaterialDetailsUnits)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByPurchaseCarryOutListMaterialDetailsUnits();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByPrePurchaseGoal )
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByPrePurchaseGoal();
            }
            #endregion

            #region 运营管理
            else if (enumArg == StoreProcessEnum.GetSerialIDIntByEquipmentCheckList)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByEquipmentCheckList();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDIntByProductionDemandAnalys)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByProductionDemandAnalysisListContributeAmountDetails();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDIntByProductionDemandAnalysisListDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByProductionDemandAnalysisListDetails();
            }

            else if (enumArg == StoreProcessEnum.GetSerialIDIntByProductionDemandAnalysisListConsumptionDetails)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByProductionDemandAnalysisListConsumptionDetails();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByProductionPlanImplementList)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByProductionPlanImplementList();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByProcessFlowDetailSerialList)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByProcessFlowDetailSerialList();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByProcessFlowDetailSerialListUnits)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByProcessFlowDetailSerialListUnits();
            }
            #endregion

            #region 质量管理
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByMaterialDetermineCheckoutDetail)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByMaterialDetermineCheckoutDetail();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByMaterialAmountsCheckoutDetail)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByMaterialAmountsCheckoutDetail();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByIQCMaterialDetermineTheAmontCheckoutDetail)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByIQCMaterialDetermineTheAmontCheckoutDetail();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByIQCDetermineTheNatureDetail)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByIQCDetermineTheNatureDetail();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByIQCDefectiveMaterialClassifyStatistics)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByIQCDefectiveMaterialClassifyStatistics();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByFQCMaterialDetermineTheAmontCheckoutDetail)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByFQCMaterialDetermineTheAmontCheckoutDetail();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByFQCDetermineTheNatureDetail)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByFQCDetermineTheNatureDetail();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByFQCDefectiveMaterialClassifyStatistics)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByFQCDefectiveMaterialClassifyStatistics();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByIPQCMaterialDetermineTheAmontCheckoutDetail)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByIPQCMaterialDetermineTheAmontCheckoutDetail();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByIPQCDetermineTheNatureDetail)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByIPQCDetermineTheNatureDetail();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByIPQCDefectiveMaterialClassifyStatistics)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByIPQCDefectiveMaterialClassifyStatistics();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByStepOneTeamOrg)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByStepOneTeamOrg();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByStepTwoProblemDescription)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByStepTwoProblemDescription();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByStepTwoProblemDescriptionAttachment)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByStepTwoProblemDescriptionAttachment();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByStepThreeContainmentActions)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByStepThreeContainmentActions();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByStepThreeContainmentActionsAttachment)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByStepThreeContainmentActionsAttachment();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByStepFourRootCauses)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByStepFourRootCauses();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByStepFourRootCausesAttachment)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByStepFourRootCausesAttachment();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByStepFiveCorrectiveActions)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByStepFiveCorrectiveActions();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByStepFiveCorrectiveActionsAttachment)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByStepFiveCorrectiveActionsAttachment();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByStepSevenPreventiveActions)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByStepSevenPreventiveActions();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByStepSevenPreventiveActionsAttachment)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByStepSevenPreventiveActionsAttachment();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByStepEightReview)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByStepEightReview();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByStepEightReviewAttachment)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByStepEightReviewAttachment();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByInnerNotify_StepOneProDescription)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByInnerNotify_StepOneProDescription();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByInnerNotify_StepOneProDescriptionAttachment)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByInnerNotify_StepOneProDescriptionAttachment();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByInnerNotify_StepTwoTakeAction)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByInnerNotify_StepTwoTakeAction();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByInnerNotify_StepTwoTakeActionAttachment)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByInnerNotify_StepTwoTakeActionAttachment();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByInnerNotify_StepThreeSuspiciousMaterial)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByInnerNotify_StepThreeSuspiciousMaterial();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByInnerNotify_StepFourRelevantOperatorSignaturecConfirmation)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByInnerNotify_StepFourRelevantOperatorSignaturecConfirmation();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByIPQCBatchCheckout)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByIPQCBatchCheckout();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByCorrectMeasureReport)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByCorrectMeasureReport();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByInnerNotifyAndProcessReceipts)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByInnerNotifyAndProcessReceipts();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByFQCBatchCheckout)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByFQCBatchCheckout();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByOQCBatchCheckout)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByOQCBatchCheckout();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByIQCBatchCheckout)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByIQCBatchCheckout();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByOQCDefectiveMaterialClassifyStatistics)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByOQCDefectiveMaterialClassifyStatistics();
            }
            //质量 客户抱怨及问题通知单流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByCustomerNotifyAndProcessReceipts)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByCustomerNotifyAndProcessReceipts();
            }
            //质量 问题描述流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByCustomerNotify_StepOneProDescription)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByCustomerNotify_StepOneProDescription();
            }
            //质量 问题描述附件流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByCustomerNotify_StepOneProDescriptionAttachment)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByCustomerNotify_StepOneProDescriptionAttachment();
            }
            //质量 采取行动描述流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByCustomerNotify_StepTwoTakeAction)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByCustomerNotify_StepTwoTakeAction();
            }
            //质量 采取行动描述附件流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByCustomerNotify_StepTwoTakeActionAttachment)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByCustomerNotify_StepTwoTakeActionAttachment();
            }
            //质量 可疑物料处理流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByCustomerNotify_StepThreeSuspiciousMaterial)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByCustomerNotify_StepThreeSuspiciousMaterial();
            }
            //质量 相关人员签字确认流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByCustomerNotify_StepFourSign)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByCustomerNotify_StepFourSign();
            }
            //质量 供应商问题通知及处理单流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByVendorNotifyAndProcessReceipts)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByVendorNotifyAndProcessReceipts();
            }
            //质量 问题描述附件流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByVendorNotify_StepOneProDescription)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByVendorNotify_StepOneProDescription();
            }
            //质量 采取行动描述流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByVendorNotify_StepTwoTakeAction)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByVendorNotify_StepTwoTakeAction();
            }
            //质量 采取行动描述附件流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByVendorNotify_StepTwoTakeActionAttachment)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByVendorNotify_StepTwoTakeActionAttachment();
            }
            //质量 可疑物料处理流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByVendorNotify_StepThreeSuspiciousMaterial)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByVendorNotify_StepThreeSuspiciousMaterial();
            }
            //质量 相关人员签字确认流水号
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByVendorNotify_StepFourSign)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByVendorNotify_StepFourSign();
            }
            #endregion

            #region  人事管理
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByDepartment)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByDepartment();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByDepContact)
            {
                return storeProcessLinq.Pro_GetSerialIDIntByDepContact();
            }
            #endregion

            #region 资产管理
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByAssetsChangeDetail)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByAssetsChangeDetail();
            }
            #endregion

            #region 消息
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByMsgBox)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByMsgBox();
            }
            #endregion

            #region 成本管理
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByPackingCost)
            {//包装成本流水号
                return storeProcessLinq.Pro_GetSerialIDIntByPackingCost();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByPackingCostDetails)
            {//包装成本明细流水号
                return storeProcessLinq.Pro_GetSerialIDIntByPackingCostDetails();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByStandardCosts)
            {//标准成本表流水号
                return storeProcessLinq.Pro_GetSerialIDIntByStandardCosts();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByRecycledMaterialCost)
            {//材料回收成本流水号
                return storeProcessLinq.Pro_GetSerialIDIntByRecycledMaterialCost();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByRecycledMaterialCostDetails)
            {//材料回收成本明细流水号
                return storeProcessLinq.Pro_GetSerialIDIntByRecycledMaterialCostDetails();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntBySubsidiaryMaterialCost)
            {//辅助材料成本流水号
                return storeProcessLinq.Pro_GetSerialIDIntBySubsidiaryMaterialCost();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntBySubsidiaryMaterialCostDetails)
            {//辅助材料成本明细流水号
                return storeProcessLinq.Pro_GetSerialIDIntBySubsidiaryMaterialCostDetails();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByToolSharingCost)
            {//工具分摊成本流水号
                return storeProcessLinq.Pro_GetSerialIDIntByToolSharingCost();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByToolSharingCostDetails)
            {//工具分摊成本明细流水号
                return storeProcessLinq.Pro_GetSerialIDIntByToolSharingCostDetails();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByProductionProcesses)
            {//工艺工序流水号
                return storeProcessLinq.Pro_GetSerialIDIntByProductionProcesses();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByManagementCost)
            {//管理成本流水号
                return storeProcessLinq.Pro_GetSerialIDIntByManagementCost();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByManagementCostCardinalateSet)
            {//管理成本基数设置表流水号
                return storeProcessLinq.Pro_GetSerialIDIntByManagementCostCardinalateSet();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByReprocessingCost)
            {//后处理成本流水号
                return storeProcessLinq.Pro_GetSerialIDIntByReprocessingCost();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByReprocessingCostDetails)
            {//后处理成本明细流水号
                return storeProcessLinq.Pro_GetSerialIDIntByReprocessingCostDetails();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByExchangeRateSet)
            {//汇率设置表流水号
                return storeProcessLinq.Pro_GetSerialIDIntByExchangeRateSet();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByProfitBaseSet)
            {//利润基数设置表流水号
                return storeProcessLinq.Pro_GetSerialIDIntByProfitBaseSet();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByProfit)
            {//利润流水号
                return storeProcessLinq.Pro_GetSerialIDIntByProfit();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByEquipmentManufacturingCost)
            {//设备加工成本流水号
                return storeProcessLinq.Pro_GetSerialIDIntByEquipmentManufacturingCost();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByEquipmentManufacturingCostDetails)
            {//设备加工成本明细流水号
                return storeProcessLinq.Pro_GetSerialIDIntByEquipmentManufacturingCostDetails();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByActualCosts)
            {//实际成本流水号
                return storeProcessLinq.Pro_GetSerialIDIntByActualCosts();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByRawMaterialCost)
            {//原材料成本流水号
                return storeProcessLinq.Pro_GetSerialIDIntByRawMaterialCost();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByRawMaterialCostDetails)
            {//原材料成本明细流水号
                return storeProcessLinq.Pro_GetSerialIDIntByRawMaterialCostDetails();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByTransportationCost)
            {//运输成本流水号
                return storeProcessLinq.Pro_GetSerialIDIntByTransportationCost();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByTransportationCostDetails)
            {//运输成本明细流水号
                return storeProcessLinq.Pro_GetSerialIDIntByTransportationCostDetails();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByDirectLaborCost)
            {//直接人工成本流水号
                return storeProcessLinq.Pro_GetSerialIDIntByDirectLaborCost();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByDirectLaborCostDetails)
            {//直接人工成本明细流水号
                return storeProcessLinq.Pro_GetSerialIDIntByDirectLaborCostDetails();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByDirectToolingAndEquipmentManufacturingSet)
            {//直接人工和设备加工设置表流水号
                return storeProcessLinq.Pro_GetSerialIDIntByDirectToolingAndEquipmentManufacturingSet();
            }
            #endregion

            #region 工程变更
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByEngineerChangeApplyTable)
            {//包装成本流水号
                return storeProcessLinq.Pro_GetSerialIDNvarcharByEngineerChangeApplyTable();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByEngineerChangeApplyTableDtails)
            {//包装成本流水号
                return storeProcessLinq.Pro_GetSerialIDIntByEngineerChangeApplyTableDtails();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByDocumentProvide)
            {//包装成本流水号
                return storeProcessLinq.Pro_GetSerialIDIntByDocumentProvide();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByChangeBeforeAttachment)
            {//包装成本流水号
                return storeProcessLinq.Pro_GetSerialIDIntByChangeBeforeAttachment();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByChangeAfterAttachment)
            {//包装成本流水号
                return storeProcessLinq.Pro_GetSerialIDIntByChangeAfterAttachment();
            }
            #endregion 工程变更

            #region 公共管理-报废单
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByAbateList)
            {//报废单编号
                return storeProcessLinq.Pro_GetSerialIDNvarcharByAbateList();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByAbateListMaterialDetails)
            {//报废单明细流水号
                return storeProcessLinq.Pro_GetSerialIDIntByAbateListMaterialDetails();
            }
            #endregion

            #region 项目管理
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByRFQProjectInfo)
            {//报废单明细流水号
                return storeProcessLinq.Pro_GetSerialIDNvarcharByRFQProjectInfo();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByRFQProjectTeamInfo)
            {//报废单明细流水号
                return storeProcessLinq.Pro_GetSerialIDIntByRFQProjectTeamInfo();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByProcessQuoteParametersTable)
            {//报废单明细流水号
                return storeProcessLinq.Pro_GetSerialIDNvarcharByProcessQuoteParametersTable();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByProcessQuoteParametersDetails)
            {//报废单明细流水号
                return storeProcessLinq.Pro_GetSerialIDIntByProcessQuoteParametersDetails();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByPurchaseMaterialQuoteParametersTable)
            {//报废单明细流水号
                return storeProcessLinq.Pro_GetSerialIDNvarcharByPurchaseMaterialQuoteParametersTable();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByPurchaseMaterialQuoteParametersDetails)
            {//报废单明细流水号
                return storeProcessLinq.Pro_GetSerialIDNvarcharByPurchaseMaterialQuoteParametersDetails();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByPurchaseQuoteParametersVendorDetails)
            {//报废单明细流水号
                return storeProcessLinq.Pro_GetSerialIDIntByPurchaseQuoteParametersVendorDetails();
            }

            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByPurchaseQuoteDetails)
            {//报废单明细流水号
                return storeProcessLinq.Pro_GetSerialIDNvarcharByPurchaseQuoteDetails();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByRawMaterialslQuoteDetails)
            {//报废单明细流水号
                return storeProcessLinq.Pro_GetSerialIDNvarcharByRawMaterialslQuoteDetails();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByCustomerQuoteList)
            {//报废单明细流水号
                return storeProcessLinq.Pro_GetSerialIDNvarcharByCustomerQuoteList();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByCustomerQuoteListDetails)
            {//报废单明细流水号
                return storeProcessLinq.Pro_GetSerialIDIntByCustomerQuoteListDetails();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByToolProcessingQuote)
            {//报废单明细流水号
                return storeProcessLinq.Pro_GetSerialIDNvarcharByToolProcessingQuote();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByOtherQuote)
            {//报废单明细流水号
                return storeProcessLinq.Pro_GetSerialIDNvarcharByOtherQuote();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByUnitPriceQuote)
            {//报废单明细流水号
                return storeProcessLinq.Pro_GetSerialIDNvarcharByUnitPriceQuote();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByProcessingQuote)
            {//报废单明细流水号
                return storeProcessLinq.Pro_GetSerialIDNvarcharByProcessingQuote();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByRDProjectTeamInfo)
            {//报废单明细流水号
                return storeProcessLinq.Pro_GetSerialIDIntByRDProjectTeamInfo();
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDIntByRDProjectProgressControlTable)
            {//报废单明细流水号
                return storeProcessLinq.Pro_GetSerialIDIntByRDProjectProgressControlTable();
            }
            #endregion
            throw new Exception("StoreProcessEnum设置有误");
        }
        #endregion

        #region 生成流水号 带参数
        public object GetSerialIDByStoreProcessName(StoreProcessEnum enumArg, string materialID, string materialVersion)
        {
            if (enumArg == StoreProcessEnum.GetSerialIDNvarcharByMaterialCustomerPriceScheme)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByMaterialCustomerPriceScheme(materialID, materialVersion);
            }
            else if (enumArg == StoreProcessEnum.GetSerialIDNvarcharByMaterialPubPriceScheme)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByMaterialPubPriceScheme(materialID, materialVersion);
            }
            else if (enumArg == StoreProcessEnum.GetSerialIDNvarcharByMaterialVendorPriceScheme)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByMaterialVendorPriceScheme(materialID, materialVersion);
            }
            else if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByMateriaCheckoutPlan)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByMateriaCheckoutPlan(materialID, materialVersion);
            }
            throw new Exception("StoreProcessEnum设置有误");
        }

        public object GetSerialIDByStoreProcessName(StoreProcessEnum enumArg, string para1)
        {
            //资产管理：资产编号
            if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByAssetsInfo)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByAssetsInfo(para1);
            }
            //物料编号生成器
            if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByMaterial)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarchar_Material(para1);
            }
            throw new Exception("StoreProcessEnum设置有误");
        }

        //人事管理：岗位
        public object GetPostSerialIDByStoreProcessName(StoreProcessEnum enumArg, int DepID, string JobCode)
        {
            if (enumArg == StoreProcessEnum.Pro_GetSerialIDNvarcharByPost)
            {
                return storeProcessLinq.Pro_GetSerialIDNvarcharByPost(DepID, JobCode);
            }
            throw new Exception("StoreProcessEnum设置有误");
        }

        #endregion

        #region 业务功能类
        
        #region 销售管理
        #endregion

        #region 采购管理
        public bool Pro_CreateT_PurchaseList(string purchasePlanListID, string createOperatorID, string createOperatorName)
        {
            return storeProcessADO.Pro_CreateT_PurchaseList(purchasePlanListID, createOperatorID, createOperatorName);
        }

        public void Pro_UpdatePurchasePlanListDemandStockInAccomplishStatus(int? purchasePlanListMaterialDetailsSID, string accomplishStatusModiOperatorID, string accomplishStatusModiOperatorName, DateTime? accomplishStatusModiTime)
        {
            bool? result;
            result = storeProcessLinq.Pro_UpdatePurchasePlanListDemandStockInAccomplishStatus(purchasePlanListMaterialDetailsSID, accomplishStatusModiOperatorID, accomplishStatusModiOperatorName, accomplishStatusModiTime);
            if (result.Value == false)
            {
                throw new Exception("存储过程：Pro_UpdatePurchasePlanListDemandStockInAccomplishStatus调用失败");
            }
        }

        public void Pro_UpdatePurchaseListDemandDeliveryAccomplishStatus(string purchaseListID, string purchaseCarryOutListMaterialDetailsSID, string accomplishStatusModiOperatorID, string accomplishStatusModiOperatorName, DateTime accomplishStatusModiTime)
        {
            bool result = false;
            result = storeProcessADO.Pro_UpdatePurchaseListDemandDeliveryAccomplishStatus(purchaseListID, purchaseCarryOutListMaterialDetailsSID, accomplishStatusModiOperatorID, accomplishStatusModiOperatorName, accomplishStatusModiTime);
            if (result == false)
            {
                throw new Exception("存储过程：Pro_UpdatePurchaseListDemandDeliveryAccomplishStatus调用失败");
            }
        }
        #endregion

        #region 运营管理
        /// <summary>
        /// 生产需求分析单分发
        /// </summary>
        /// <param name="ProductionDemandAnalysisListID"></param>
        /// <param name="operatorID"></param>
        /// <param name="operatorName"></param>
        public void ProductionDemandAnalysisList_Deliver(string ProductionDemandAnalysisListID, string operatorID, string operatorName, ref int purresult, ref int proresult)
        {
            int result = storeProcessADO.Pro_ProductionDemandAnalysisList_Deliver(ProductionDemandAnalysisListID, operatorID, operatorName, ref purresult, ref proresult);
            if (result == 0)
            {
                throw new Exception("存储过程：ProductionDemandAnalysisList_Deliver调用错误");
            }
        }

        /// <summary>
        /// 组合了3个存储过程，共同完整生成需求分析单和明细的数据填充和库存的修改及记录
        /// </summary>
        /// <param name="ISOID"></param>
        /// <param name="campOnLevelCode"></param>
        /// <param name="campOnLevel"></param>
        /// <param name="entryClerkID"></param>
        /// <param name="entryClerkName"></param>
        /// <returns></returns>
        public string Pro_ProductionDemandAnalysisListSerial(string ISOID, string campOnLevelCode, string campOnLevel, string entryClerkID, string entryClerkName)
        {
            string result = "";
            storeProcessADO.Pro_ProductionDemandAnalysisListSerial(ISOID, campOnLevelCode, campOnLevel, entryClerkID, entryClerkName, ref result);
            return result;
        }

        /// <summary>
        /// 生成计划领料单
        /// </summary>
        /// <param name="processFlowCardID"></param>
        public void Pro_CreateT_PlanGetMaterialList(string processFlowCardID)
        {
            bool result = false;
            result = storeProcessADO.Pro_CreateT_PlanGetMaterialList(processFlowCardID);
            if (result == false)
            {
                throw new Exception("存储过程：Pro_CreateT_PlanGetMaterialList调用失败");
            }
        }

        /// <summary>
        /// 将生产计划单和明细合并成生产计划实施跟踪单
        /// </summary>
        /// <param name="productionPlanListID"></param>
        public void Pro_CreateT_ProductionPlanImplementTrackingList(string productionPlanListID)
        {
            bool result = false;
            result = storeProcessADO.Pro_CreateT_ProductionPlanImplementTrackingList(productionPlanListID);
            if(result == false)
            {
                throw new Exception("存储过程：Pro_CreateT_ProductionPlanImplementTrackingList调用失败");
            }
        }

        public void Pro_Get_ExtMaterialInfo(string ISOID,string materialID,string materialVersion,out string extMaterialID,out string extMaterialVersion)
        {
            bool result = false;
            result = storeProcessADO.Pro_Get_ExtMaterialInfo(ISOID,materialID,materialVersion,out extMaterialID,out extMaterialVersion);
            if (result == false)
            {
                throw new Exception("存储过程：Pro_Get_ExtMaterialInfo调用失败");
            }
        }
        #endregion

        #region 库存管理
        /// <summary>
        ///  生成盘点明细
        /// </summary>
        /// <param name="StockCountBillID">盘点主表单号，必填</param>
        /// <param name="OperatorID">操作人工号，必填</param>
        /// <param name="OperatorName">操作人姓名，必填</param>
        /// <param name="MaterialTypeCode">物料类型编号，非必填</param>
        /// <param name="MaterialDetailTypeCode">物料细类编号，非必填</param>
        /// <param name="MaterialResourceCode">物料来源编号，非必填</param>
        /// <param name="MaterialID">物料编号，非必填</param>
        /// <param name="MaterialVersion">物料版本，非必填</param>
        /// <param name="BatchID">批次编号，非必填</param>
        /// <param name="Bar">工序，非必填</param>
        public void Pro_createT_StockCountBillDetails(string StockCountBillID, string OperatorID, string OperatorName, string MaterialTypeCode, string MaterialDetailTypeCode, string MaterialResourceCode, string MaterialID, string MaterialVersion, string BatchID, string Bar)
        {
            bool result = false;
            result = storeProcessADO.Pro_createT_StockCountBillDetails(StockCountBillID, OperatorID, OperatorName, MaterialTypeCode, MaterialDetailTypeCode, MaterialResourceCode, MaterialID, MaterialVersion, BatchID, Bar);
            if (result == false)
            {
                throw new Exception("存储过程：Pro_createT_StockCountBillDetails调用失败");
            }
        }
        #endregion

        #region 质量管理
        public void CreateXQC_DetermineTheXXXCheckoutDetail(string CheckoutPlanTypeID, string BatchID, int SampleAmount, string MaterialID, string MaterialVersion, int WorkStageID)
        {
            int result = 0;
            result = storeProcessADO.Pro_CreateXQC_DetermineTheXXXCheckoutDetail(CheckoutPlanTypeID, BatchID, SampleAmount, MaterialID, MaterialVersion, WorkStageID);
            if (result == 0)
            {
                throw new Exception("该物料的可用检验计划明细不合规范！");
            }
        }

        public void CreateXQC_DetermineTheXXXCheckoutDetail(string CheckoutPlanTypeID, string BatchID, int SampleAmount, string MaterialID, string MaterialVersion)
        {
            int result = 0;
            result = storeProcessADO.Pro_CreateXQC_DetermineTheXXXCheckoutDetail(CheckoutPlanTypeID, BatchID, SampleAmount, MaterialID, MaterialVersion);
            if (result == 0)
            {
                throw new Exception("该物料的可用检验计划明细不合规范！");
            }
        }

        /// <summary>
        /// 检查是否修改FQC对应的内部入库单的系统状态
        /// </summary>
        /// <param name="InternalStorageBillID"></param>
        public void Pro_FQC_InternalStorageBill_SystemStatus(string InternalStorageBillID)
        {
            int result = 0;
            result = storeProcessADO.Pro_FQC_InternalStorageBill_SystemStatus(InternalStorageBillID);
        }

        /// <summary>
        /// 检查是否修改IQC对应的外部入库单的系统状态
        /// </summary>
        /// <param name="OutStockInListID"></param>
        public void Pro_IQC_OutStockInList_SystemStatus(string OutStockInListID)
        {
            int result = 0;
            result = storeProcessADO.Pro_IQC_OutStockInList_SystemStatus(OutStockInListID);
        }

        /// <summary>
        /// 检查是否修改OQC对应的外部出货单的系统状态
        /// </summary>
        /// <param name="DOBID"></param>
        public void Pro_OQC_DeliveryOrderBill_SystemStatus(string DOBID)
        {
            int result = 0;
            result = storeProcessADO.Pro_OQC_DeliveryOrderBill_SystemStatus(DOBID);
        }
        #endregion

        #endregion

    }
}