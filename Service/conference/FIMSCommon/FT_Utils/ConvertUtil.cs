using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;

namespace FT_Utils
{
    /// <summary>
    /// PO与VO之间转换
    /// </summary>
    public static class ConvertUtil
    {
        /// <summary>
        /// 默认不包含的属性名称集合
        /// </summary>
        //static string[] _DefaultExcludeName = new string[] { };

        #region 对单个对象的conversion方法重载
        /// <summary>
        /// 
        /// </summary>
        /// <param name="desModel"></param>
        /// <param name="srcModel"></param>
        /// <returns></returns>
        public static int conversion(object desModel, object srcModel)
        {
            if (desModel == null || srcModel == null)
            {
                return 0;
            }
            return conversion(desModel,srcModel,srcModel.GetType());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="desModel"></param>
        /// <param name="srcModel"></param>
        /// <param name="srcType"></param>
        /// <returns></returns>
        public static int conversion(object desModel, object srcModel, Type srcType)
        {
            return conversion(desModel, srcModel, srcType, true, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="desModel"></param>
        /// <param name="srcModel"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public static int conversion(object desModel, object srcModel, IEnumerable<string> properties)
        {
            return conversion(desModel, srcModel, srcModel.GetType(), true, properties);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="desModel"></param>
        /// <param name="srcModel"></param>
        /// <param name="isIncluded"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public static int conversion(object desModel, object srcModel, bool isIncluded, IEnumerable<string> properties)
        {
            return conversion( desModel, srcModel, srcModel.GetType(), isIncluded, properties);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="desModel"></param>
        /// <param name="srcModel"></param>
        /// <param name="srcType"></param>
        /// <param name="isIncluded"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public static int conversion(object desModel, object srcModel, Type srcType, bool isIncluded, IEnumerable<string> properties)
        {
            int count = 0;
            if (desModel == null || srcModel == null)
            {
                return 0;
            }
            Type desType = desModel.GetType();

            foreach (PropertyInfo property in srcType.GetProperties())
            {
                if (properties != null)
                {
                    if (!isIncluded && properties.Contains(property.Name))
                        continue;
                    else if (isIncluded && !properties.Contains(property.Name))
                        continue;
                }
                try
                {
                    PropertyInfo des = desType.GetProperty(property.Name);
                    if (des != null && des.CanWrite && property.CanRead)
                    {
                        var tmp = srcType.InvokeMember(property.Name, BindingFlags.GetProperty, null, srcModel, null);

                        if (property.PropertyType == typeof(Nullable<DateTime>) && (tmp == null || (DateTime)tmp == new DateTime(1, 1, 1)))
                        {
                            tmp = null;
                        }
                        desType.InvokeMember(property.Name, BindingFlags.SetProperty, null, desModel, new object[] { tmp });

                        count++;
                    }
                }
                catch (Exception e)
                {
                    return 0;
                }
            }
            return count;
        }

#endregion
    }
}
