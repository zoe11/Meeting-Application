using System;
using System.Linq;

namespace FT_Utils
{
    public class UnitTransform
    {
        /// <summary>
        /// 物料单位转换函数
        /// </summary>
        /// <param name="isToDefault">
        /// true为界面要求单位转物料基本单位
        /// false为物料基本单位转界面需求单位
        /// </param>
        /// <param name="materialID">物料编号</param>
        /// <param name="materialVersion">物料版本</param>
        /// <param name="unitTypeCodeEnum">
        /// 物料单位类型：
        /// PurchaseUnit    采购单位
        /// GetUnit    领料单位
        /// ProductionUnit    生产单位
        /// SalesUnit    销售单位
        /// StockInUnit    入库单位
        /// StockOutUnit    出库单位
        /// StockUnit    库存单位
        /// </param>
        /// <param name="value">待转换后数值</param>
        /// <returns>转换后数值</returns>
        public static UnitModel TransMaterialUnit(bool isToDefault, string materialID, string materialVersion, UnitTypeCodeEnum unitTypeCodeEnum, double value)
        {
            return isToDefault
                       ? TransUnitToDefault(materialID, materialVersion, unitTypeCodeEnum, value)
                       : TransDefaultToUnit(materialID, materialVersion, unitTypeCodeEnum, value);
        }

        /// <summary>
        /// 界面转基本
        /// </summary>
        /// <param name="id">物料编号</param>
        /// <param name="version">物料版本</param>
        /// <param name="typeCode">单位类型</param>
        /// <param name="value">数值</param>
        /// <returns>转换后数值</returns>
        private static UnitModel TransUnitToDefault(string id, string version, UnitTypeCodeEnum typeCode, double value)
        {
            try
            {
                using (UnitTransDataContext dc = new UnitTransDataContext(FT_ENV.FTEnv.USERCONN))
                {
                    var tModel = dc.T_MaterialUnitRelation.Single(
                        o => o.MaterialID == id && o.MaterialVersion == version);
                    if (tModel == null)
                    {
                        return null;
                    }
                    UnitModel unitModel = new UnitModel
                        {
                            UnitCode = tModel.MaterialUnitCode,
                            UnitName = tModel.MaterialUnit
                        };
                    switch (typeCode)
                    {
                        case UnitTypeCodeEnum.PurchaseUnit:
                            unitModel.Value = value * tModel.PurchaseRelation;
                            break;

                        case UnitTypeCodeEnum.GetUnit:
                            unitModel.Value = value * tModel.GetRelation;
                            break;

                        case UnitTypeCodeEnum.ProductionUnit:
                            unitModel.Value = value * tModel.ProductionRelation;
                            break;

                        case UnitTypeCodeEnum.SalesUnit:
                            unitModel.Value = value * tModel.SalesRelation;
                            break;

                        case UnitTypeCodeEnum.StockInUnit:
                            unitModel.Value = value * tModel.StockInRelation;
                            break;

                        case UnitTypeCodeEnum.StockOutUnit:
                            unitModel.Value = value * tModel.StockOutRelation;
                            break;

                        case UnitTypeCodeEnum.StockUnit:
                            unitModel.Value = value * tModel.StockOutRelation;
                            break;

                        default:
                            unitModel.Value = value;
                            break;
                    }
                    return unitModel;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 基本转界面
        /// </summary>
        /// <param name="id">物料编号</param>
        /// <param name="version">物料版本</param>
        /// <param name="typeCode">单位类型</param>
        /// <param name="value">数值</param>
        /// <returns>转换后数值</returns>
        private static UnitModel TransDefaultToUnit(string id, string version, UnitTypeCodeEnum typeCode, double value)
        {
            try
            {
                using (UnitTransDataContext dc = new UnitTransDataContext(FT_ENV.FTEnv.USERCONN))
                {
                    UnitModel unitModel;
                    var tModel = dc.T_MaterialUnitRelation.Single(
                        o => o.MaterialID == id && o.MaterialVersion == version);
                    if (tModel == null)
                    {
                        return null;
                    }
                    switch (typeCode)
                    {
                        case UnitTypeCodeEnum.PurchaseUnit:
                            unitModel = new UnitModel
                                {
                                    UnitCode = tModel.PurchaseUnitCode,
                                    UnitName = tModel.PurchaseUnit,
                                    Value = value / tModel.PurchaseRelation
                                };
                            break;

                        case UnitTypeCodeEnum.GetUnit:
                            unitModel = new UnitModel
                                {
                                    UnitCode = tModel.GetUnitCode,
                                    UnitName = tModel.GetUnit,
                                    Value = value / tModel.GetRelation
                                };
                            break;

                        case UnitTypeCodeEnum.ProductionUnit:
                            unitModel = new UnitModel
                                {
                                    UnitCode = tModel.ProductionUnitCode,
                                    UnitName = tModel.ProductionUnit,
                                    Value = value / tModel.ProductionRelation
                                };
                            break;

                        case UnitTypeCodeEnum.SalesUnit:
                            unitModel = new UnitModel
                            {
                                UnitCode = tModel.SalesUnitCode,
                                UnitName = tModel.SalesUnit,
                                Value = value / tModel.SalesRelation
                            };
                            break;

                        case UnitTypeCodeEnum.StockInUnit:
                            unitModel = new UnitModel
                            {
                                UnitCode = tModel.StockInUnitCode,
                                UnitName = tModel.StockInUnit,
                                Value = value / tModel.StockInRelation
                            };
                            break;

                        case UnitTypeCodeEnum.StockOutUnit:
                            unitModel = new UnitModel
                            {
                                UnitCode = tModel.StockOutUnitCode,
                                UnitName = tModel.StockOutUnit,
                                Value = value / tModel.StockOutRelation
                            };
                            break;

                        case UnitTypeCodeEnum.StockUnit:
                            unitModel = new UnitModel
                            {
                                UnitCode = tModel.StockUnitCode,
                                UnitName = tModel.StockUnit,
                                Value = value / tModel.StockRelation
                            };
                            break;

                        default:
                            unitModel = new UnitModel
                            {
                                UnitCode = tModel.MaterialUnitCode,
                                UnitName = tModel.MaterialUnit,
                                Value = value
                            };
                            break;
                    }
                    return unitModel;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取物料对应模块的单位
        /// </summary>
        /// <param name="id">物料编号</param>
        /// <param name="version">物料版本</param>
        /// <param name="typeCode">单位类型</param>
        /// <returns></returns>
        public static UnitModel GetUnit(string id, string version, UnitTypeCodeEnum typeCode)
        {
            var model = GetMaterialUnitRelation(id, version);
            switch (typeCode)
            {
                case UnitTypeCodeEnum.GetUnit:
                    return new UnitModel
                        {
                            UnitCode = model.GetUnitCode,
                            UnitName = model.GetUnit
                        };
                case UnitTypeCodeEnum.ProductionUnit:
                    return new UnitModel
                    {
                        UnitCode = model.ProductionUnitCode,
                        UnitName = model.ProductionUnit
                    };
                case UnitTypeCodeEnum.PurchaseUnit:
                    return new UnitModel
                    {
                        UnitCode = model.PurchaseUnitCode,
                        UnitName = model.PurchaseUnit
                    };
                case UnitTypeCodeEnum.SalesUnit:
                    return new UnitModel
                    {
                        UnitCode = model.SalesUnitCode,
                        UnitName = model.SalesUnit
                    };
                case UnitTypeCodeEnum.StockInUnit:
                    return new UnitModel
                    {
                        UnitCode = model.StockInUnitCode,
                        UnitName = model.StockInUnit
                    };
                case UnitTypeCodeEnum.StockOutUnit:
                    return new UnitModel
                    {
                        UnitCode = model.StockOutUnitCode,
                        UnitName = model.StockOutUnit
                    };
                case UnitTypeCodeEnum.StockUnit:
                    return new UnitModel
                    {
                        UnitCode = model.StockUnitCode,
                        UnitName = model.StockUnit
                    };
            }
            return null;
        }

        private static T_MaterialUnitRelation GetMaterialUnitRelation(string id, string version)
        {
            try
            {
                using (UnitTransDataContext dc = new UnitTransDataContext(FT_ENV.FTEnv.USERCONN))
                {
                    var tModel =
                        dc.T_MaterialUnitRelation.FirstOrDefault(o => o.MaterialID == id && o.MaterialVersion == version);
                    return tModel;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 获得单位名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <param name="typeCode"></param>
        /// <returns></returns>
        public static string GetUnitName(string id, string version, UnitTypeCodeEnum typeCode)
        {
            var model = GetMaterialUnitRelation(id, version);
            switch (typeCode)
            {
                    case UnitTypeCodeEnum.GetUnit:
                    return model.GetUnit;
                    case UnitTypeCodeEnum.ProductionUnit:
                    return model.ProductionUnit;
                    case UnitTypeCodeEnum.PurchaseUnit:
                    return model.PurchaseUnit;
                    case UnitTypeCodeEnum.SalesUnit:
                    return model.SalesUnit;
                    case UnitTypeCodeEnum.StockInUnit:
                    return model.StockInUnit;
                    case UnitTypeCodeEnum.StockOutUnit:
                    return model.StockOutUnit;
                    case UnitTypeCodeEnum.StockUnit:
                    return model.StockUnit;
            }
            return null;
        }

        /// <summary>
        /// 获得单位编码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <param name="typeCode"></param>
        /// <returns></returns>
        public static string GetUnitCode(string id, string version, UnitTypeCodeEnum typeCode)
        {
            var model = GetMaterialUnitRelation(id, version);
            switch (typeCode)
            {
                case UnitTypeCodeEnum.GetUnit:
                    return model.GetUnitCode;
                case UnitTypeCodeEnum.ProductionUnit:
                    return model.ProductionUnitCode;
                case UnitTypeCodeEnum.PurchaseUnit:
                    return model.PurchaseUnitCode;
                case UnitTypeCodeEnum.SalesUnit:
                    return model.SalesUnitCode;
                case UnitTypeCodeEnum.StockInUnit:
                    return model.StockInUnitCode;
                case UnitTypeCodeEnum.StockOutUnit:
                    return model.StockOutUnitCode;
                case UnitTypeCodeEnum.StockUnit:
                    return model.StockUnitCode;
            }
            return null;
        }

        /// <summary>
        /// 获得转换后数量值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <param name="typeCode"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double GetDefaultToUnitResult(string id, string version, UnitTypeCodeEnum typeCode, double value)
        {
            var model = TransDefaultToUnit(id, version, typeCode, value);
            return model.Value;
        }

        public static double GetUnitToDefaultResult(string id, string version, UnitTypeCodeEnum typeCode, double value)
        {
            var model = TransUnitToDefault(id, version, typeCode, value);
            return model.Value;
        }
    }
}