using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FT_ENV;
using FT_Utils;
using Conference_Model;
using System.Linq.Expressions;

namespace Conference_DAL
{
    public class DAL_Conference
    {
        private readonly string ObjectName = "用户信息";
        public Result GetUserInfo(User filter)
        {
            Result result = new Result();
            try
            {
                using (var dc = new DataClassesCFDataContext())
                {
                    Expression<Func<T_User, bool>> expr = PredicateExtensionses.True<T_User>();
                    //获得内部订单信息查询条件
                    GetUserInfoFilter(filter, ref expr);
                    var pModels = (from c in dc.T_User.Where(expr) select c).ToList();//延迟加载,数据库没有任何操作 

                    if (pModels.Count != 0)
                    {
                        IList<User> vModels = new List<User>();
                        ConversionList(vModels, pModels);//将查询内部订单信息填入到vModel中
                        result = Result.SetResult(vModels, "", ResCode.Correct);
                    }
                    else
                    {
                        result = Result.SetResult(null, ObjectName + "信息不存在！", ResCode.NotExist);
                    }
                }
            }
            catch (Exception e)
            {
                result = Result.SetResult(null, e.Message, ResCode.SQLError);
            }

            return result; 
        }

        private void GetUserInfoFilter(User Filter, ref Expression<Func<T_User, bool>> expr)
        {
            if (!string.IsNullOrEmpty(Filter.UserName))
            {
                expr = expr.And(c => (c.UserName == Filter.UserName));//1次组合 
            }
            /*
            if (!string.IsNullOrEmpty(Filter.CustomerID))
            {
                expr = expr.And(c => (c.CustomerID == Filter.CustomerID)); //2次组合 
            }
            if (!string.IsNullOrEmpty(Filter.RFQProjectNO))
            {
                expr = expr.And(c => (c.RFQProjectNO == Filter.RFQProjectNO)); //3次组合 
            }
            if (Filter.ReceiveStartDate != null && Filter.ReceiveEndDate != null)
            {
                expr = expr.And(c => (c.ReceiveDate >= Filter.ReceiveStartDate && c.ReceiveDate <= Filter.ReceiveEndDate));
            }
             * */
        }

        private void ConversionList(IList<User> vModels, List<T_User> pModels)
        {
            foreach (var pModel in pModels)
            {
                User vModel = new User();
                ConvertUtil.conversion(vModel, pModel);//Model转换
                vModels.Add(vModel);
            }
        }
    }
}
