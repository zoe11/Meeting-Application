using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FT_ControlsUtils;
using FT_ENV;
using Microsoft.Reporting.WinForms;

namespace FTComponentSet
{
    public partial class NewReportFormForParameters : FTForm, IReportForm
    {
        private Model4Client argModel;
        private UserControl _uc;
        private static NewReportFormForParameters form = null;
        private NewReportFormForParameters()
        {
            InitializeComponent();
            this.ControlBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.reportViewer1.ProcessingMode = ProcessingMode.Remote;
        }

        public static NewReportFormForParameters CreateInstance()
        {
            if (form ==null)
            {
                form = new NewReportFormForParameters();
            }
            return form;
        }

        private IList<KeyValuePair<int, List<int>>> valuePairs = null;
        public void SetSelectArea(UserControl uc)
        {
            _uc = uc;
            valuePairs = new List<KeyValuePair<int, List<int>>>();
            for (int i = 0; i < uc.Controls.Count; i++)
            {
                List<int> list = new List<int>()
                    {
                        uc.Controls[i].Width,
                        uc.Controls[i].Height,
                        uc.Controls[i].Left,
                        uc.Controls[i].Top
                    };
                KeyValuePair<int,List<int>> valuePair = new KeyValuePair<int, List<int>>(i,list);
                valuePairs.Add(valuePair);
            }
        }

        public void IniteReportModel(Model4Client model4Report)
        {
            this.argModel = model4Report;
        }

        public void ShowReport()
        {
            this.groupBoxFT1.Controls.Clear();
            this.groupBoxFT1.Controls.Add(_uc);
            //this.groupBoxFT1.AutoSize = true;
            this.groupBoxFT1.Height = _uc.Height;
            _uc.Dock = DockStyle.Fill;

            for (int i = 0; i < valuePairs.Count; i++)
            {
                List<int> list = valuePairs[i].Value;
                _uc.Controls[valuePairs[i].Key].Width = list[0];
                _uc.Controls[valuePairs[i].Key].Height = list[1];
                _uc.Controls[valuePairs[i].Key].Left = list[2];
                _uc.Controls[valuePairs[i].Key].Top = list[3];
            }

            this.Show();
        }

        public void ShowWithParameters(IEnumerable<ReportParameter> paramters)
        {
            InitialReportViewer();
            this.reportViewer1.ServerReport.ReportPath = argModel.Path;
            this.reportViewer1.ServerReport.SetParameters(paramters);
            this.reportViewer1.RefreshReport();
        }

        private void InitialReportViewer()
        {
            this.reportViewer1.ServerReport.ReportServerUrl = new Uri(FTEnv.REPORTSERVER_ADDRESS);
            this.reportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials =
                new System.Net.NetworkCredential(FTEnv.REPORTSERVER_USER, FTEnv.REPORTSERVER_PASSWORD, argModel.Path);
            this.reportViewer1.ShowParameterPrompts = false;
            this.reportViewer1.Visible = true;
        }

        private void NewReportFormForParameters_FormClosing(object sender, FormClosingEventArgs e)
        {
            form = null;
            _uc = null;
        }

    }
}
