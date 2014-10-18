using System;

namespace FT_Utils
{
    public class AutoAuditInfo
    {
        public string AuditStatusCode { get; set; }

        public string AuditStatus { get; set; }

        public string ApprovedStateCode { get; set; }

        public string ApprovedState { get; set; }

        public string ApprovedOperatorID { get; set; }

        public string ApprovedOperatorName { get; set; }

        public System.Nullable<DateTime> ApprovedTime { get; set; }

        public string CreateOperatorID { get; set; }

        public string CreateOperatorName { get; set; }

        public DateTime CreateTime { get; set; }

        public string LastModiOperatorID { get; set; }

        public string LastModiOperatorName { get; set; }

        public DateTime LastModiTime { get; set; }

        public string LastAuditOperatorID { get; set; }

        public string LastAuditOperatorName { get; set; }

        public System.Nullable<DateTime> LastAuditTime { get; set; }
    }
}