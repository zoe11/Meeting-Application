using System.Configuration;
namespace FT_ENV
{
    public partial class FTEnv
    {


        public static readonly bool IsDebug = bool.Parse(ConfigurationManager.AppSettings["IsDebug"] ?? "true");
        public static readonly bool IsMessageOn = bool.Parse(GetDecryptBoolStr("IsMessageOn") ?? "true");
        public static readonly bool IsAutoUpdateOn = bool.Parse(GetDecryptBoolStr("IsAutoUpdateOn") ?? "true");

        #region FTMessageBox

        //FTMessageBox中提示信息
        public static readonly string Caption = "友情提示";

        #endregion FTMessageBox

        #region DataGridView标题行高度，数据行高度
        public static readonly int ColumnHeaderHeight = 37;
        public static readonly int ColumnRowHeight = 30;
        #endregion

        #region 审核状态

        //审核后通过
        public static readonly string ACC = "ACC";
        public static readonly string AuditAccept = "审核后通过";

        //待审核
        public static readonly string PED = "PED";
        public static readonly string AuditPending = "待审核";
        //审核后废弃
        public static readonly string STP = "STP";
        public static readonly string AuditStop = "审核后废弃";
        //审核后修改
        public static readonly string MOD = "MOD";
        public static readonly string AuditModify = "审核后修改";
        //待提交
        public static readonly string TBS = "TBS";
        public static readonly string AuditSubmit = "待提交";

        #endregion 审核状态

        #region 完成状态

        public static readonly string PS001 = "时间未到-未完成";
        public static readonly string PS002 = "时间延迟-未完成";
        public static readonly string PS003 = "准时-已完成";
        public static readonly string PS004 = "时间延迟-已完成";
        public static readonly string PS005 = "取消-已完成";


        public static readonly string PS001_Code = "PS001";
        public static readonly string PS002_Code = "PS002";
        public static readonly string PS003_Code = "PS003";
        public static readonly string PS004_Code = "PS004";
        public static readonly string PS005_Code = "PS005";

        #endregion

        #region QC 完成状态
        public static readonly string QCAS001 = "未完成";
        public static readonly string QCAS002 = "完成";
        public static readonly string QCAS001_Code = "AS001";
        public static readonly string QCAS002_Code = "AS002";
        #endregion

        #region 采购计划单系统状态
        public static readonly string PPLSysStatus001 = "分派中";
        public static readonly string PPLSysStatus001_Code = "S001";
        public static readonly string PPLSysStatus002 = "分派完成";
        public static readonly string PPLSysStatus002_Code = "S002";
        public static readonly string PPLSysStatus003 = "已实施";
        public static readonly string PPLSysStatus003_Code = "S003";
        #endregion

        #region 内部销售订单系统状态
        public static readonly string ISOSysStatus001 = "销售期";
        public static readonly string ISOSysStatus001_Code = "S001";
        public static readonly string ISOSysStatus002 = "需求分析期";
        public static readonly string ISOSysStatus002_Code = "S002";
        #endregion

        #region 资产状态
        public static readonly string AssetState001 = "使用中";
        public static readonly string AssetState001_Code = "AS-001";
        public static readonly string AssetState002 = "闲置";
        public static readonly string AssetState002_Code = "AS-002";
        public static readonly string AssetState003 = "维修中";
        public static readonly string AssetState003_Code = "AS-003";
        public static readonly string AssetState004 = "已报废";
        public static readonly string AssetState004_Code = "AS-004";
        #endregion

        #region 内部销售订单来源
        public static readonly string ISOOrderSource001 = "在手订单";
        public static readonly string ISOOrderSource001_Code = "SS001";
        public static readonly string ISOOrderSource002 = "客户预测";
        public static readonly string ISOOrderSource002_Code = "SS002";
        public static readonly string ISOOrderSource003 = "内部预测";
        public static readonly string ISOOrderSource003_Code = "SS003";
        #endregion

        #region 客户发货通知单系统状态
        public static readonly string CNDSysStatus001 = "已制定";
        public static readonly string CNDSysStatus001_Code = "S001";
        public static readonly string CNDSysStatus002 = "已分发";
        public static readonly string CNDSysStatus002_Code = "S002";
        public static readonly string CNDSysStatus003 = "已出货";
        public static readonly string CNDSysStatus003_Code = "S003";
        #endregion

        #region 价格类型
        public static readonly string PriceType_SUP = "样品价格";
        public static readonly string PriceType_SUP_Code = "SUP";
        public static readonly string PriceType_FUP = "批量固定价";
        public static readonly string PriceType_FUP_Code = "FUP";
        public static readonly string PriceType_STP = "批量梯形价";
        public static readonly string PriceType_STP_Code = "STP";
        #endregion

        #region 币种
        public static readonly string RMB = "人民币";
        public static readonly string RMB_Code = "RMB";
        #endregion

        #region 核准状态

        //核准后通过
        public static readonly string AppACC = "ACC";
        public static readonly string AppAccept = "核准后通过";
        //待核准
        public static readonly string AppPED = "PED";
        public static readonly string AppPending = "待核准";
        //核准后废弃
        public static readonly string AppSTP = "STP";
        public static readonly string AppStop = "核准后废止";

        #endregion 核准状态

        #region 锁定状态

        public const string L01_Code = "L01";
        public const string L02_Code = "L02";

        public const string L01 = "不加锁";
        public const string L02 = "加锁";
        #endregion

        public static readonly string OPEN = "OPEN";
        public static readonly string CLOSE = "CLOSE";

        #region ReceiptsAuditLevel

        public const string RAL_Material = "1";
        public const string RAL_BOMGroup = "2";
        public const string RAL_AttachmentVersion = "3";
        public const string RAL_ProductionDemandAnalysisList = "4";
        public const string RAL_ProductionDemandAnalysisListDetails = "5";
        public const string RAL_CheckItem = "6";
        public const string RAL_CustomerContacts = "7";
        public const string RAL_CustomerInfo = "8";
        public const string RAL_CustomerMaterialCompare = "9";
        public const string RAL_DeliveryOrderBill = "10";
        public const string RAL_Equipment = "11";
        public const string RAL_InnerSalesOrder = "12";
        public const string RAL_MaterialCustomerPriceScheme = "13";
        public const string RAL_MaterialPubPriceScheme = "14";
        public const string RAL_MaterialReplace = "15";
        public const string RAL_MaterialVendorPriceScheme = "16";
        public const string RAL_ProductionPlanList = "17";
        public const string RAL_PurchaseList = "18";
        public const string RAL_PurchasePlanList = "19";
        public const string RAL_VendorContacts = "20";
        public const string RAL_VendorInfo = "21";
        public const string RAL_VendorMaterialCompare = "22";
        public const string RAL_VendorList_H = "23";
        public const string RAL_CustomerList_H = "24";
        public const string RAL_OutStockInList = "25";
        public const string RAL_MateriaCheckoutPlan = "26";
        public const string RAL_IQCBatchCheckout = "27";
        public const string RAL_OQCBatchCheckout = "28";
        public const string RAL_FQCBatchCheckout = "29";
        public const string RAL_IPQCBatchCheckout = "30";
        public const string RAL_ProcessFlowCardTemplet = "31";
        public const string RAL_InternalStorageBill = "32";
        public const string RAL_InternalOutboundOrderBill = "33";
        public const string RAL_InternalReturnMaterialBill = "34";
        public const string RAL_StockCountBill = "35";
        public const string RAL_ExternalReturnBill = "36";
        public const string RAL_CustomerDeliveryNotice = "37";

        public const string RAL_AssetsRegister = "38";//资产登记单
        public const string RAL_AssetsTakeUse = "39";//资产领用单
        public const string RAL_AssetsRepair = "40";//资产送修单
        public const string RAL_AssetsReturn = "41";//资产归还单
        public const string RAL_AssetsScrap = "42";//资产报废单

        public const string RAL_StandardCosts = "43";//标准成本制作的审核
        public const string RAL_EngineerChangeApplyTable = "44";//工程变更申请

        public const string RAL_AbateList = "45";//报废单

        public const string RAL_ProcessQuoteParameter = "46";//工程报价参数
        public const string RAL_CustomerQuoteList = "47";//工程报价参数
        public const string RAL_ProjectStartList = "48";//项目启动单
        #endregion

        public static readonly string DELETESUCCESS = "删除成功！";

        #region 付款方式
        public static readonly string PAYMENTTYPE_SET = "SET";//付款方式为账期
        #endregion

        #region 库存质检开关 * 7——是否需要质检——[总设置、分模块设置]

        public static readonly bool StockQualityCheck_All = true;//库存质检——全部需要质检

        public static readonly bool StockQualityCheck_ExternalOutbound = true;//库存质检——外部出库

        public static readonly bool StockQualityCheck_ExternalReturn = false;//库存质检——外部退货

        public static readonly bool StockQualityCheck_ExternalStorage = true;//库存质检——外部入库

        public static readonly bool StockQualityCheck_InternalOutbound = false;//库存质检——内部出库

        public static readonly bool StockQualityCheck_InternalReturnMaterial = false;//库存质检——内部退料

        public static readonly bool StockQualityCheck_InternalStorage = true;//库存质检——内部入库

        #endregion


        #region 授权开关
        public static readonly bool IsEmpowerEnable = bool.Parse(GetDecryptBoolStr("IsEquipAuthOn") ?? "true");
        public static readonly bool IsCPUEmpower = true;
        public static readonly bool IsHardDiskEmpower = true;
        public static readonly bool IsMACEmpower = true;
        #endregion


        #region MsgBox
        public const string MSG_SAMS_CusinfoInfoInputCommit = "M10001";
        public const string MSG_SAMS_CusinfoInfoInputApproved = "M10002";
        public const string MSG_SAMS_CusinfoContactCommit = "M10003";
        public const string MSG_SAMS_CusinfoListCommit = "M10004";
        public const string MSG_SAMS_CusinfoListApproved = "M10005";
        public const string MSG_SAMS_CustomerMatcompareCommit = "M10006";
        public const string MSG_SAMS_SalesPublicpriceCommit = "M10007";
        public const string MSG_SAMS_SalesCustomerpriceCommit = "M10008";
        public const string MSG_SAMS_CustomerOrderCommit = "M10009";
        public const string MSG_SAMS_CustomerOrderAudit = "M10010";
        public const string MSG_SAMS_CustomerOrderApproved = "M10011";
        public const string MSG_PUMS_VendorinfoInputCommit = "M20001";
        public const string MSG_PUMS_VendorinfoInputApproved = "M20002";
        public const string MSG_PUMS_VendorinfoContactCommit = "M20003";
        public const string MSG_PUMS_VendorinfoListCommit = "M20004";
        public const string MSG_PUMS_VendorinfoListApproved = "M20005";
        public const string MSG_PUMS_VendorMatcompareCommit = "M20006";
        public const string MSG_PUMS_VendorPriceCommit = "M20007";
        public const string MSG_PUMS_BuyOrderCommit = "M20008";
        public const string MSG_PUMS_BuyOrderAudit = "M20009";
        public const string MSG_PUMS_BuyOrderApproved = "M20010";
        public const string MSG_OPMS_DemandInputCommit = "M30001";
        public const string MSG_OPMS_DemandDistributeCommit = "M30002";
        public const string MSG_OPMS_PrdtplanInputCommit = "M30003";
        public const string MSG_OPMS_PrdtplanInputAudit = "M30004";
        public const string MSG_OPMS_ImplementPlanWPConfirm = "M30005";
        public const string MSG_OPMS_ImplementPlanFGConfirm = "M30006";
        public const string MSG_STMS_OutincomeInputCommit = "M40001";
        public const string MSG_STMS_OutincomeInputApproved = "M40002";
        public const string MSG_STMS_OutincomeStockFinished = "M40004";
        public const string MSG_STMS_InnerincomeInputCommit = "M40005";
        public const string MSG_STMS_InnerincomeInputApproved = "M40006";
        public const string MSG_STMS_InnerincomeStockFinished = "M40008";
        public const string MSG_STMS_OutgoInputCommit = "M40010";
        public const string MSG_STMS_OutgoInputApproved = "M40011";
        public const string MSG_STMS_OutgoStockFinished = "M40013";
        public const string MSG_STMS_InnergoInputCommit = "M40015";
        public const string MSG_STMS_InnergoInputApproved = "M40016";
        public const string MSG_STMS_InnergoStockFinished = "M40018";
        public const string MSG_STMS_InreturnInputCommit = "M40020";
        public const string MSG_STMS_InreturnInputApproved = "M40021";
        public const string MSG_STMS_InreturnStockFinished = "M40022";
        public const string MSG_STMS_StockAdjustCommit = "M40023";
        public const string MSG_STMS_StockAdjustApproved = "M40024";
        public const string MSG_STMS_OutreturnInputCommit = "M40026";
        public const string MSG_STMS_OutreturnInputApproved = "M40027";
        public const string MSG_STMS_OutreturnStockFinished = "M40029";
        public const string MSG_ENMS_MatinfoInputCommit = "M50001";
        public const string MSG_ENMS_MatinfoInputAudit = "M50002";
        public const string MSG_ENMS_MatinfoInputApproved = "M50003";
        public const string MSG_ENMS_BomInputCommit = "M50007";
        public const string MSG_ENMS_BomInputAudit = "M50008";
        public const string MSG_ENMS_BomInputApproved = "M50009";
        public const string MSG_ENMS_ReplaceInputCommit = "M50013";
        public const string MSG_ENMS_ReplaceInputAudit = "M50014";
        public const string MSG_ENMS_FlowchartInputCommit = "M50019";
        public const string MSG_ENMS_FlowchartInputAudit = "M50020";
        public const string MSG_QAMS_QplanCreatCommit = "M60001";
        public const string MSG_QAMS_QplanCreatAudit = "M60002";
        public const string MSG_QAMS_QplanCreatApproved = "M60003";
        public const string MSG_QAMS_QplanCreatInUse = "M60004";
        public const string MSG_QAMS_IqcrecordInputCommit = "M60005";
        public const string MSG_QAMS_IqcrecordInputAudit = "M60006";
        public const string MSG_QAMS_IqcrecordInputApproved = "M60007";
        public const string MSG_QAMS_IpqcrecordInputCommit = "M60010";
        public const string MSG_QAMS_IpqcrecordInputAudit = "M60011";
        public const string MSG_QAMS_IpqcrecordInputApproved = "M60012";
        public const string MSG_QAMS_FqcrecordInputCommit = "M60015";
        public const string MSG_QAMS_FqcrecordInputAudit = "M60016";
        public const string MSG_QAMS_FqcrecordInputApproved = "M60017";
        public const string MSG_QAMS_OqcrecordInputCommit = "M60020";
        public const string MSG_QAMS_OqcrecordInputAudit = "M60021";
        public const string MSG_QAMS_OqcrecordInputApproved = "M60022";
        #endregion

        #region 工艺流转卡模板编号前缀
        public static readonly string Prefix_ProcessFlowCardTempletID = "PFCT";
        #endregion

        #region 设备点检检查项目类型编码
        public static readonly string CheckItemType_M001 = "M001";//日常保养
        public static readonly string CheckItemType_M002 = "M002";//重点保养
        public static readonly string CheckItemType_M003 = "M003";//年度保养
        #endregion

        #region 报价状态
        public static readonly string QuoteStatusCode_M001 = "QS001";//成功
        public static readonly string QuoteStatusCode_M003 = "QS003";//待确认
        public static readonly string QuoteStatus_M003 = "待确认";//待确认
        #endregion
    }
}