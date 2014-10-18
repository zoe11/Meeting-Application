using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTComponentSet
{
    public interface IReportForm
    {
        void IniteReportModel(Model4Client model4Report);
        void ShowReport();
    }
}
