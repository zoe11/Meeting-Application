using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FT_StoreProcess
{
    public enum StoreProcessEnum
    {
        #region 未归类
        GetSerialIDIntByAttachment,
        GetSerialIDIntByBOM,
        GetSerialIDIntByMaterial,
        GetSerialIDIntByCustomerContacts,
        GetSerialIDIntByInnerSalesOrderDetails,
        GetSerialIDIntByPurchasePlanListMaterialDetails,
        GetSerialIDIntByPurchasePlanListVendorDetails,
        GetSerialIDIntByPurchaseCarryOutListVendorDetails,
        GetSerialIDIntByPurchaseCarryOutListMaterialDetails,
        GetSerialIDIntByVendorContacts,
        GetSerialIDIntByEquipmentCheckList,
        GetSerialIDIntByProductionDemandAnalysisListDetails,
        GetSerialIDIntByProductionDemandAnalysisListConsumptionDetails,
        GetSerialIDIntByProductionDemandAnalys,

        //库存
        Pro_GetSerialIDNvarcharByStockDetailsUnits,//库存明细单位转换
        Pro_GetSerialIDNvarcharByDefectiveGoodsStockDetailsUnits,//库存明细单位转换

        GetSerialIDIntByEntityFreeStockInRecordDetails,
        GetSerialIDIntByEntityFreeStockOutRecordDetails,
        GetSerialIDIntByEntityCampOnStockOutRecordDetails,
        GetSerialIDIntByEntityCampOnStockInRecordDetails,
        GetSerialIDIntByBeMadeFreeStockInRecordDetails,
        GetSerialIDIntByBeMadeFreeStockOutRecordDetails,
        GetSerialIDIntByBeMadeCampOnStockInRecordDetails,
        GetSerialIDIntByBeMadeCampOnStockOutRecordDetails,
        GetSerialIDIntByStockInRecordDetails,
        GetSerialIDIntByStockOutRecordDetails,

        GetSerialIDNvarcharByDeliveryOrderBill,
        GetSerialIDNvarcharByOutStockInList,
        GetSerialIDIntByDeliveryOrderBillDetailsRegister,
        GetSerialIDIntByDeliveryOrderBillDetails,
        GetSerialIDIntByOutStockInListDetailsVesting,
        GetSerialIDIntByOutStockInListDetails,
        //

        GetSerialIDNvarcharByMaterialCustomerPriceScheme,
        GetSerialIDNvarcharByMaterialPubPriceScheme,
        GetSerialIDNvarcharByCustomerInfo,
        GetSerialIDNvarcharByPurchasePlanList,
        GetSerialIDNvarcharByPurchaseList,
        GetSerialIDNvarcharByMaterialVendorPriceScheme,
        GetSerialIDNvarcharByVendorInfo,
        GetSerialIDNvarcharByInnerSalesOrder,
        GetSerialIDNvarcharByProductionDemandAnalysisList,
        Pro_GetSerialIDIntByMaterialDetermineCheckoutDetail,
        Pro_GetSerialIDIntByMaterialAmountsCheckoutDetail,
        Pro_GetSerialIDIntByIQCMaterialDetermineTheAmontCheckoutDetail,
        Pro_GetSerialIDIntByIQCDetermineTheNatureDetail,
        Pro_GetSerialIDIntByIQCDefectiveMaterialClassifyStatistics,
        Pro_GetSerialIDIntByOQCMaterialDetermineTheAmontCheckoutDetail,
        Pro_GetSerialIDIntByOQCDetermineTheNatureDetail,
        Pro_GetSerialIDIntByOQCDefectiveMaterialClassifyStatistics,
        Pro_GetSerialIDIntByFQCMaterialDetermineTheAmontCheckoutDetail,
        Pro_GetSerialIDIntByFQCDetermineTheNatureDetail,
        Pro_GetSerialIDIntByFQCDefectiveMaterialClassifyStatistics,
        Pro_GetSerialIDIntByIPQCMaterialDetermineTheAmontCheckoutDetail,
        Pro_GetSerialIDIntByIPQCDetermineTheNatureDetail,
        Pro_GetSerialIDIntByIPQCDefectiveMaterialClassifyStatistics,
        Pro_GetSerialIDIntByStepOneTeamOrg,
        Pro_GetSerialIDIntByStepTwoProblemDescription,
        Pro_GetSerialIDIntByStepTwoProblemDescriptionAttachment,
        Pro_GetSerialIDIntByStepThreeContainmentActions,
        Pro_GetSerialIDIntByStepThreeContainmentActionsAttachment,
        Pro_GetSerialIDIntByStepFourRootCauses,
        Pro_GetSerialIDIntByStepFourRootCausesAttachment,
        Pro_GetSerialIDIntByStepFiveCorrectiveActions,
        Pro_GetSerialIDIntByStepFiveCorrectiveActionsAttachment,
        Pro_GetSerialIDIntByStepSevenPreventiveActions,
        Pro_GetSerialIDIntByStepSevenPreventiveActionsAttachment,
        Pro_GetSerialIDIntByStepEightReview,
        Pro_GetSerialIDIntByStepEightReviewAttachment,
        Pro_GetSerialIDIntByInnerNotify_StepOneProDescription,
        Pro_GetSerialIDIntByInnerNotify_StepOneProDescriptionAttachment,
        Pro_GetSerialIDIntByInnerNotify_StepTwoTakeAction,
        Pro_GetSerialIDIntByInnerNotify_StepTwoTakeActionAttachment,
        Pro_GetSerialIDIntByInnerNotify_StepThreeSuspiciousMaterial,
        Pro_GetSerialIDIntByInnerNotify_StepFourRelevantOperatorSignaturecConfirmation,
        Pro_GetSerialIDNvarcharByIQCBatchCheckout,
        Pro_GetSerialIDNvarcharByOQCBatchCheckout,
        Pro_GetSerialIDNvarcharByFQCBatchCheckout,
        Pro_GetSerialIDNvarcharByInnerNotifyAndProcessReceipts,
        Pro_GetSerialIDNvarcharByCorrectMeasureReport,
        Pro_GetSerialIDNvarcharByIPQCBatchCheckout,
        Pro_GetSerialIDNvarcharByProductionPlanImplementList,
        #endregion

        #region 销售管理
        Pro_GetSerialIDNvarcharByCustomerDeliveryNotice,
        Pro_GetSerialIDNvarcharByInnerSalesOrderDetailsUnits,//内部销售订单明细单位登记
        Pro_GetSerialIDNvarcharByPreSaleGoal,//该存储过程产生字符串类型的销售目标设定表流水号
        #endregion

        #region 采购管理
        Pro_GetSerialIDIntByPurchaseListVendorDetailsUnits,//该存储过程产生int类型的采购供应商明细单位登记表流水号
        Pro_GetSerialIDIntByPurchaseCarryOutListMaterialDetailsUnits,//该存储过程产生int类型的采购实施单物料明细单位登记表流水号
        Pro_GetSerialIDNvarcharByPrePurchaseGoal,//该存储过程产生字符串类型的采购目标设定表流水号
        #endregion

        #region 质量管理
        Pro_GetSerialIDNvarcharByCustomerNotifyAndProcessReceipts,
        Pro_GetSerialIDIntByCustomerNotify_StepOneProDescription,
        Pro_GetSerialIDIntByCustomerNotify_StepOneProDescriptionAttachment,
        Pro_GetSerialIDIntByCustomerNotify_StepTwoTakeAction,
        Pro_GetSerialIDIntByCustomerNotify_StepTwoTakeActionAttachment,
        Pro_GetSerialIDIntByCustomerNotify_StepThreeSuspiciousMaterial,
        Pro_GetSerialIDIntByCustomerNotify_StepFourSign,
        Pro_GetSerialIDNvarcharByVendorNotifyAndProcessReceipts,
        Pro_GetSerialIDIntByVendorNotify_StepOneProDescription,
        Pro_GetSerialIDIntByVendorNotify_StepOneProDescriptionAttachment,
        Pro_GetSerialIDIntByVendorNotify_StepTwoTakeAction,
        Pro_GetSerialIDIntByVendorNotify_StepTwoTakeActionAttachment,
        Pro_GetSerialIDIntByVendorNotify_StepThreeSuspiciousMaterial,
        Pro_GetSerialIDIntByVendorNotify_StepFourSign,
        Pro_GetSerialIDNvarcharByMateriaCheckoutPlan,//物料检验计划ID
        #endregion

        #region 库存管理
        Pro_GetSerialIDNvarcharByInternalStorageBill,//内部入库单号
        Pro_GetSerialIDIntByInternalStorageBillDetails,//内部入库单明细流水号
        Pro_GetSerialIDNvarcharByInternalOutboundOrderBill,//内部出库单号
        Pro_GetSerialIDIntByInternalOutboundOrderBillDetails,//内部出库单明细流水号
        Pro_GetSerialIDIntByInternalOutboundOrderBillDetailsRegister,//登记流水号

        Pro_GetSerialIDIntByDefectiveGoodsStockOutRecordDetails,//不良品库存出库登记明细流水号
        Pro_GetSerialIDIntByDefectiveGoodsStockDetails,//不良品库存明细流水号
        Pro_GetSerialIDIntByDefectiveGoodsStockInRecordDetails,//不良品库存入库登记明细流水号
        Pro_GetSerialIDIntByStockDetails,//库存明细流水号

        Pro_GetSerialIDIntByInternalReturnMaterialBillDetails,//内部退料单明细流水号
        Pro_GetSerialIDNvarcharByInternalReturnMaterialBill,//内部退料单号

        Pro_GetSerialIDNvarcharByStockCountBillDetails,//盘点清单明细流水号
        Pro_GetSerialIDNvarcharByStockCountAnalysis,//盘点分析流水号
        Pro_GetSerialIDNvarcharByStockCountBill,//盘点清单号
        Pro_GetSerialIDIntByExternalReturnBillDetails,//外部退货明细流水号
        Pro_GetSerialIDNvarcharByExternalReturnBill,//外部退货单编号


        #endregion

        #region 工程管理
        Pro_GetSerialIDIntByProcessFlowCardTemplet,
        Pro_GetSerialIDIntByProcessFlowCardTempletDetails,
        Pro_GetSerialIDNvarcharByMaterial,//自动生成物料编号
        Pro_GetSerialIDIntByMaterialVendorUnitRelation,// 供应商物料单位换算流水号
        Pro_GetSerialIDIntByMaterialUnitRelation,//物料单位换算流水号
        #endregion

        #region 运营管理
        Pro_GetSerialIDIntByProcessFlowDetailSerialList,
        Pro_GetSerialIDNvarcharByProcessFlowDetailSerialListUnits,//计划领料登记明细表流水号
        #endregion

        #region 人事管理
        Pro_GetSerialIDIntByDepartment,//部门流水号
        Pro_GetSerialIDNvarcharByPost,//岗位流水号
        Pro_GetSerialIDIntByDepContact,//部门联系人
        #endregion

        #region 消息
        Pro_GetSerialIDNvarcharByMsgBox,//消息
        #endregion

        #region 资产管理
        Pro_GetSerialIDNvarcharByAssetsInfo,//资产编号  
        Pro_GetSerialIDNvarcharByAssetsChangeDetail,//资产变动编号
        #endregion

        #region 成本管理
        Pro_GetSerialIDIntByPackingCost,//包装成本流水号
        Pro_GetSerialIDIntByPackingCostDetails,//包装成本明细流水号
        Pro_GetSerialIDIntByStandardCosts,//标准成本表流水号
        Pro_GetSerialIDIntByRecycledMaterialCost,//材料回收成本流水号
        Pro_GetSerialIDIntByRecycledMaterialCostDetails,//材料回收成本明细流水号
        Pro_GetSerialIDIntBySubsidiaryMaterialCost,//辅助材料成本流水号
        Pro_GetSerialIDIntBySubsidiaryMaterialCostDetails,//辅助材料成本明细流水号
        Pro_GetSerialIDIntByToolSharingCost,//工具分摊成本流水号
        Pro_GetSerialIDIntByToolSharingCostDetails,//工具分摊成本明细流水号
        Pro_GetSerialIDIntByProductionProcesses,//工艺工序流水号
        Pro_GetSerialIDIntByManagementCostCardinalateSet,//管理成本基数设置表流水号
        Pro_GetSerialIDIntByManagementCost,//管理成本流水号
        Pro_GetSerialIDIntByReprocessingCost,//后处理成本流水号
        Pro_GetSerialIDIntByReprocessingCostDetails,//后处理成本明细流水号
        Pro_GetSerialIDIntByExchangeRateSet,//汇率设置表流水号
        Pro_GetSerialIDIntByProfitBaseSet,//利润基数设置表流水号
        Pro_GetSerialIDIntByProfit,//利润流水号
        Pro_GetSerialIDIntByEquipmentManufacturingCost,//设备加工成本流水号
        Pro_GetSerialIDIntByEquipmentManufacturingCostDetails,//设备加工成本明细流水号
        Pro_GetSerialIDIntByActualCosts,//实际成本流水号
        Pro_GetSerialIDIntByRawMaterialCost,//原材料成本流水号
        Pro_GetSerialIDIntByRawMaterialCostDetails,//原材料成本明细流水号
        Pro_GetSerialIDIntByTransportationCost,//运输成本流水号
        Pro_GetSerialIDIntByTransportationCostDetails,//运输成本明细流水号
        Pro_GetSerialIDIntByDirectLaborCost,//直接人工成本流水号
        Pro_GetSerialIDIntByDirectLaborCostDetails,//直接人工成本明细流水号
        Pro_GetSerialIDIntByDirectToolingAndEquipmentManufacturingSet,//直接人工和设备加工设置表流水号
        #endregion

        #region 工程变更
        Pro_GetSerialIDNvarcharByEngineerChangeApplyTable,//包装成本流水号
        Pro_GetSerialIDIntByEngineerChangeApplyTableDtails,//包装成本流水号
        Pro_GetSerialIDIntByDocumentProvide,//包装成本流水号
        Pro_GetSerialIDIntByChangeBeforeAttachment,//包装成本流水号
        Pro_GetSerialIDIntByChangeAfterAttachment,//包装成本流水号
        #endregion 工程变更

        #region 公共管理-报废单
        Pro_GetSerialIDNvarcharByAbateList,//该存储过程产生nvarchar类型的报废单编号
        Pro_GetSerialIDIntByAbateListMaterialDetails,//该存储过程产生int类型的报废单明细流水号
        #endregion

        #region 项目信息
        Pro_GetSerialIDNvarcharByRFQProjectInfo,
        Pro_GetSerialIDIntByRFQProjectTeamInfo,
        Pro_GetSerialIDNvarcharByProcessQuoteParametersTable,
        Pro_GetSerialIDIntByProcessQuoteParametersDetails,
        Pro_GetSerialIDNvarcharByPurchaseMaterialQuoteParametersDetails,
        Pro_GetSerialIDNvarcharByPurchaseMaterialQuoteParametersTable,
        Pro_GetSerialIDIntByPurchaseQuoteParametersVendorDetails,

        Pro_GetSerialIDNvarcharByPurchaseQuoteDetails,
        Pro_GetSerialIDNvarcharByRawMaterialslQuoteDetails,

        Pro_GetSerialIDNvarcharByCustomerQuoteList,
        Pro_GetSerialIDIntByCustomerQuoteListDetails,
        Pro_GetSerialIDNvarcharByToolProcessingQuote,
        Pro_GetSerialIDNvarcharByOtherQuote,
        Pro_GetSerialIDNvarcharByUnitPriceQuote,
        Pro_GetSerialIDNvarcharByProcessingQuote,

        Pro_GetSerialIDIntByRDProjectTeamInfo,
        Pro_GetSerialIDIntByRDProjectProgressControlTable,
        #endregion

    }
}