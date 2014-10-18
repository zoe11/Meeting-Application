using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FT_Utils
{
    public class AccomplishModel
    {
        public string AccomplishStatusCode { get; set; }

        public string AccomplishStatus { get; set; }
    }
    public class AccomplishStatusHelper
    {
        public static AccomplishModel GetMasterAccomplish(IList<AccomplishModel> slavesAccomplish)
        {
            AccomplishModel result = new AccomplishModel();
            result.AccomplishStatus = "时间未到-未完成";
            result.AccomplishStatusCode = "PS001";
            if (slavesAccomplish.Any(o=>o.AccomplishStatusCode=="PS002"))
            {
                result.AccomplishStatusCode = "PS002";
                result.AccomplishStatus = "时间延迟-未完成";
            }

            if (slavesAccomplish.Any(o => o.AccomplishStatusCode == "PS003") && slavesAccomplish.All(o => o.AccomplishStatusCode == "PS003" || o.AccomplishStatusCode == "PS005"))
            {
                result.AccomplishStatusCode = "PS003";
                result.AccomplishStatus = "准时-已完成";
            }
            if (slavesAccomplish.Any(o => o.AccomplishStatusCode == "PS004") && slavesAccomplish.All(o => o.AccomplishStatusCode == "PS003" || o.AccomplishStatusCode == "PS005" || o.AccomplishStatusCode == "PS004"))
            {
                result.AccomplishStatusCode = "PS004";
                result.AccomplishStatus = "时间延迟-已完成";
            }
            if (slavesAccomplish.All(o => o.AccomplishStatusCode == "PS005"))
            {
                result.AccomplishStatusCode = "PS005";
                result.AccomplishStatus = "取消-已完成";
            }
            return result;
        }
    }
}
