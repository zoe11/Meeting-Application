using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FT_ControlsUtils
{
    public abstract class ComboBoxDelegate
    {
        protected DBBuilder Builder = new DBBuilder();
        public string RelationOwner { get; set; }

        public DataTable InitialDataTable()
        {
            InitDataSource();
            return AssemblyDataTale();
        }
        internal abstract void InitDataSource();
        internal abstract DataTable AssemblyDataTale();
    }
}
