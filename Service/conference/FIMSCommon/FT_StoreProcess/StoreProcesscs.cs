using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FT_StoreProcess
{
    class StoreProcesscs
    {
        internal  string Pro_BOMCircleCheck(string parentMaterialID,string parentMaterialVersion,string childMaterialID,string childMaterialVersion,string upOrDown)
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                string result= String.Empty;
                dc.Pro_BOMCircleCheck(parentMaterialID, parentMaterialVersion, childMaterialID, childMaterialVersion, upOrDown, ref result);
                return result;
            }
        }
        //internal  void Pro_EquipmentCheckList(string equipmentID, int? checkYear, int? checkMonth)
        //{
        //    using (StoreProcessDataContext dc = new StoreProcessDataContext())
        //    {
        //        dc.Pro_EquipmentCheckList(equipmentID,checkYear,checkMonth);
        //    }
        //}

        internal  string Pro_GetSeriaIDNvarcharByVendorInfo()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                string result = String.Empty;
                dc.Pro_GetSeriaIDNvarcharByVendorInfo(ref result);
                return result;
            }
        }

        internal  int Pro_GetSerialIDIntByAttachment()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? result = 0;
                dc.Pro_GetSerialIDIntByAttachment(ref result);
                return result.Value;
            }
        }

        internal  int Pro_GetSerialIDIntByBeMadeCampOnStockInRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByBeMadeCampOnStockInRecordDetails(ref serialID);
                return serialID.Value;
            }
        }


        internal  int Pro_GetSerialIDIntByBeMadeCampOnStockOutRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByBeMadeCampOnStockOutRecordDetails(ref serialID);
                return serialID.Value;
            }
        }

        internal  int Pro_GetSerialIDIntByBeMadeFreeStockInRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByBeMadeFreeStockInRecordDetails(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByBeMadeFreeStockOutRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByBeMadeFreeStockOutRecordDetails(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByBOM()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByBOM(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByCustomerContacts()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByCustomerContacts(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByEntityCampOnStockInRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByEntityCampOnStockInRecordDetails(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByEntityCampOnStockOutRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByEntityCampOnStockOutRecordDetails(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByEntityFreeStockInRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByEntityFreeStockInRecordDetails(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByEntityFreeStockOutRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByEntityFreeStockOutRecordDetails(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByEquipmentCheckList()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByEquipmentCheckList(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByInnerSalesOrderDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByInnerSalesOrderDetails(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByMaterial()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByMaterial(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByProductionDemandAnalysisListConsumptionDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByProductionDemandAnalysisListConsumptionDetails(ref serialID);
                return serialID.Value;
            }
        }
        //ERROR
        internal  int Pro_GetSerialIDIntByProductionDemandAnalysisListContributeAmountDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByProductionDemandAnalysisListContributeAmountDetails(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByProductionDemandAnalysisListDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByProductionDemandAnalysisListDetails(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByPurchaseCarryOutListMaterialDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByPurchaseCarryOutListMaterialDetails(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByPurchaseCarryOutListVendorDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByPurchaseCarryOutListVendorDetails(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByPurchasePlanListMaterialDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByPurchasePlanListMaterialDetails(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByPurchasePlanListVendorDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByPurchasePlanListVendorDetails(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByStockInRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByStockInRecordDetails(ref serialID);
                return serialID.Value;
            }
        }
        internal  int Pro_GetSerialIDIntByStockOutRecordDetails()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByStockOutRecordDetails(ref serialID);
                return serialID.Value;
            }
        }
        //....
        internal  int Pro_GetSerialIDIntByVendorContacts()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? serialID = 0;
                dc.Pro_GetSerialIDIntByVendorContacts(ref serialID);
                return serialID.Value;
            }
        }
        internal  string Pro_GetSerialIDNvarcharByCustomerDeliveryNotice()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByCustomerDeliveryNotice(ref result);
                return result;
            }
        }
        internal  string Pro_GetSerialIDNvarcharByCustomerInfo()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByCustomerInfo(ref result);
                return result;
            }
        }
        internal  string Pro_GetSerialIDNvarcharByDeliveryOrderBill()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByDeliveryOrderBill(ref result);
                return result;
            }
        }
        internal  string Pro_GetSerialIDNvarcharByInnerSalesOrder()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByInnerSalesOrder(ref result);
                return result;
            }
        }
        internal  string Pro_GetSerialIDNvarcharByMaterialCustomerPriceScheme(string materialID, string materialVersion)
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByMaterialCustomerPriceScheme(materialID,materialVersion,ref result);
                return result;
            }
        }
        internal string Pro_GetSerialIDNvarcharByMaterialPubPriceScheme(string materialID, string materialVersion)
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByMaterialPubPriceScheme(materialID, materialVersion, ref result);
                return result;
            }
        }
        internal  string Pro_GetSerialIDNvarcharByMaterialVendorPriceScheme(string materialID, string materialVersion)
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                String result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByMaterialVendorPriceScheme(materialID, materialVersion, ref result);
                return result;
            }
        }

        internal  string Pro_GetSerialIDNvarcharByProductionDemandAnalysisList()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                string result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByProductionDemandAnalysisList(ref result);
                return result;
            }
        }
        internal  string Pro_GetSerialIDNvarcharByPurchaseList()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                string result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByPurchaseList(ref result);
                return result;
            }
        }
        internal  string Pro_GetSerialIDNvarcharByPurchasePlanList()
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                string result = String.Empty;
                dc.Pro_GetSerialIDNvarcharByPurchasePlanList(ref result);
                return result;
            }
        }
        internal  int Pro_PreventRpeatLogin(string userID)
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                int? result = 0;
                dc.Pro_PreventRpeatLogin(userID,ref result);
                return result.Value;
            }
        }

        internal void Pro_ProductionDemandAnalysisList_Deliver(string ProductionDemandAnalysisListID, string operatorID)
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                dc.Pro_ProductionDemandAnalysisList_Deliver(ProductionDemandAnalysisListID, operatorID);
            }
        }

        internal string Pro_ProductionDemandAnalysisListSerial(string ISOID, string campOnLevelCode, string campOnLevel, string entryClerkID)
        {
            using (StoreProcessDataContext dc = new StoreProcessDataContext())
            {
                string result = String.Empty;
                dc.Pro_ProductionDemandAnalysisListSerial(ISOID,campOnLevelCode,campOnLevel,entryClerkID, ref result);
                return result;
            }
        }
    }
}
