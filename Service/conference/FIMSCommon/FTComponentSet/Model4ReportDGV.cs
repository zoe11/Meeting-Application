using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FT_ControlsUtils;

namespace FTComponentSet
{
    /// <summary>
    /// 报表需要的Model
    /// </summary>
    public class Model4ReportDGV
    {
        public string ReportNo { get; set; }
        public string ReportName { get; set; }
        public Model4Client ReportInnerArgsModel { get; set; }
        public string ReportDescription { get; set; }
        public bool HasParameters { get; set; }
        public FTForm FilterForm { get; set; }
        //public Type UcType { get; set; }
    }
}
