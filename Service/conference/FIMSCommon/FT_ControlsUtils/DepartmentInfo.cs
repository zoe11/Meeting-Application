using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FT_ControlsUtils
{
    public class DepartmentInfo
    {
        [DisplayName("")]
        public int DepID { get; set; }

        [DisplayName("")]
        public string DepNO { get; set; }

        [DisplayName("")]
        public string DepName { get; set; }

        [DisplayName("")]
        public string DepEnName { get; set; }

        [DisplayName("")]
        public int DepPriority { get; set; }
    }
}
