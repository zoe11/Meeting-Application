using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Conference_Model
{
    public class User
    {
        [DisplayName("用户I")]
        public string UserID { get; set; }

        [DisplayName("用户")]
        public string UserName { get; set; }

        [DisplayName("密")]
        public string Password { get; set; }

        [DisplayName("是否内置用")]
        public System.Nullable<bool> IsInnerUser { get; set; }

        [DisplayName("是否注销用")]
        public System.Nullable<bool> IsLogoutUser { get; set; }

        [DisplayName("创建人姓")]
        public string CreateOperatorName { get; set; }

        [DisplayName("创建")]
        public string CreateOperatorID { get; set; }

        [DisplayName("创建时")]
        public System.Nullable<System.DateTime> CreateTime { get; set; }

        [DisplayName("最后修改人姓")]
        public string LastModiOperatorName { get; set; }

        [DisplayName("最后修改")]
        public string LastModiOperatorID { get; set; }

        [DisplayName("最后修改时")]
        public System.Nullable<System.DateTime> LastModiTime { get; set; }

        [DisplayName("备")]
        public string Notes { get; set; }
    }
}
