using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FT_ControlsUtils;
using FT_ENV;

namespace FTComponentSet
{
    public partial class ReportContainerDGV : UserControl
    {
        private IReportForm _reportForm;
        private DataTable _dt;
        private Model4Client _model;
        public ReportContainerDGV()
        {
            InitializeComponent();
            _dt = CreateDTArchitectrue();

        }

        //public void InitReportInnerArgsByModel(Model4Client clientModel)
        //{
        //    this._model = clientModel;
        //}
        public void InitDataSourceByDataTable(DataTable dt)
        {
            this.dataGridViewFT1.DataSource = dt;
        }

        public void InitDataSourceByReportModel(Model4ReportDGV model)
        {
            _dt.Rows.Clear();
            _dt.Rows.Add(model.ReportNo, model.ReportName, model.ReportInnerArgsModel, model.ReportDescription);
            this.dataGridViewFT1.DataSource = _dt;
        }

        /// <summary>
        /// 报表的方法
        /// </summary>
        /// <param name="models"></param>
        public void InitDataSourceByReportModels(IList<Model4ReportDGV> models)
        {
            DataTable dt = CreateDTArchitectrue();
            foreach (Model4ReportDGV model in models)
            {
                DataRow row = dt.NewRow();
                row["ReportNo"] = model.ReportNo;
                row["ReportName"] = model.ReportName;
                row["ReportModel"] = model.ReportInnerArgsModel;
                row["ReportDescription"] = model.ReportDescription;
                row["HasParameters"] = model.HasParameters;
                row["FilterForm"] = model.FilterForm;
                //row["UcType"] = model.UcType;
                dt.Rows.Add(row);
            }
            this.dataGridViewFT1.DataSource = dt;

            this.dataGridViewFT1.Columns["HasParameters"].Visible = false;
            this.dataGridViewFT1.Columns["FilterForm"].Visible = false;
            //this.dataGridViewFT1.Columns["UcType"].Visible = false;
        }

        private DataTable CreateDTArchitectrue()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ReportNo", typeof(string)));
            dt.Columns.Add(new DataColumn("ReportName", typeof(string)));
            dt.Columns.Add(new DataColumn("ReportModel", typeof(Model4Client)));
            dt.Columns.Add(new DataColumn("ReportDescription", typeof(string)));
            dt.Columns.Add(new DataColumn("HasParameters", typeof(bool)));
            dt.Columns.Add(new DataColumn("FilterForm", typeof(FTForm)));
            //dt.Columns.Add(new DataColumn("UcType", typeof(Type)));
            return dt;
        }

        private void dataGridViewFT1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (this.dataGridViewFT1.CurrentRow == null)
            {
                return;
            }
            int row = this.dataGridViewFT1.CurrentRow.Index;
            _model = (Model4Client)this.dataGridViewFT1.Rows[row].Cells["ReportModelColumn"].Value;

            var hasParameters = (bool)this.dataGridViewFT1.Rows[row].Cells["HasParameters"].Value;
            if (hasParameters)
            {
                //_reportForm = NewReportFormForParameters.CreateInstance();
                //var ucType = (Type)this.dataGridViewFT1.Rows[row].Cells["UcType"].Value;
                //if (ucType != null)
                //{
                //    var handel = Activator.CreateInstance(ucType);
                //    var uc = (UserControl)handel;
                //    ((NewReportFormForParameters)_reportForm).SetSelectArea(uc);
                //}

                var item = this.dataGridViewFT1.Rows[row].Cells["FilterForm"].Value;
                if (!item.IsNull())
                {
                    FTForm filterForm = (FTForm)item;
                    if (!filterForm.IsNull())
                    {
                        filterForm.ShowDialog();

                        return;
                    }
                }
            }
            else
            {
                _reportForm = new NewReportForm();
            }
            this._reportForm.IniteReportModel(_model);
            this._reportForm.ShowReport();
        }

        private void buttonFT1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Helper.IsClosed = true;
        }

        private void dataGridViewFT1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dataGridViewFT1.Columns[3].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
