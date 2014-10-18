using System.ComponentModel;

namespace FT_Utils
{
    public enum UnitTypeCodeEnum
    {
        [Description("采购单位")]
        PurchaseUnit,
        [Description("入库单位")]
        StockInUnit,
        [Description("出库单位")]
        StockOutUnit,
        [Description("库存单位")]
        StockUnit,
        [Description("领料单位")]
        GetUnit,
        [Description("生产单位")]
        ProductionUnit,
        [Description("销售单位")]
        SalesUnit
    };

    public class UnitModel
    {
        
        public string UnitCode { get; set; }

        public string UnitName { get; set; }

        public double Value { get; set; }
    }

   


}