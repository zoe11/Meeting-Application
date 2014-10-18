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
    public partial class NewReportForm : FTForm,IReportForm
    {
        private Model4Client argModel;
        public NewReportForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
        }

        internal new FormStartPosition StartPosition
        {
            get { return base.StartPosition; }
            set { base.StartPosition = value; }
        }

        public void IniteReportModel(Model4Client model4Report)
        {
            this.argModel = model4Report;
        }

        public void ShowReport()
        {
            this.Show();
        }

        //internal new void Show()
        //{
        //    base.Show();
        //    //if (argModel != null)
        //    //{
        //    //    this.reportViewer1.ServerReport.ReportPath = argModel.Path;
        //    //    InitialReportViewer();
        //    //    this.reportViewer1.RefreshReport();
        //    //}
        //}

        internal void ShowWithoutParameters()
        {
            InitialReportViewer();
            this.reportViewer1.ServerReport.ReportPath = argModel.Path;
            this.reportViewer1.RefreshReport();
        }

        public void ShowWithParameters(IEnumerable<ReportParameter> paramters)
        {
            InitialReportViewer();
            //Console.WriteLine(this.re);
            this.reportViewer1.ServerReport.ReportPath = argModel.Path;
            this.reportViewer1.ServerReport.SetParameters(paramters);
            this.reportViewer1.RefreshReport();
        }

        /// <summary>
        /// 报表的账号密码和相对路径
        /// </summary>
        private void InitialReportViewer()
        {
            this.reportViewer1.ServerReport.ReportServerUrl = new Uri(FTEnv.REPORTSERVER_ADDRESS);
            this.reportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials =
                new System.Net.NetworkCredential(FTEnv.REPORTSERVER_USER, FTEnv.REPORTSERVER_PASSWORD, argModel.Path);
            this.reportViewer1.ShowParameterPrompts = false;
            this.reportViewer1.Visible = true;
        }


        private class CustomReportCredentials : Microsoft.Reporting.WinForms.IReportServerCredentials
        {
            private string _UserName;
            private string _PassWord;
            private string _DomainName;

            public CustomReportCredentials(string UserName, string PassWord, string DomainName)
            {
                _UserName = UserName;
                _PassWord = PassWord;
                _DomainName = DomainName;
            }

            public System.Security.Principal.WindowsIdentity ImpersonationUser
            {
                get { return null; }
            }

            public System.Net.ICredentials NetworkCredentials
            {
                get { return new System.Net.NetworkCredential(_UserName, _PassWord, _DomainName); }
            }

            public bool GetFormsCredentials(out System.Net.Cookie authCookie, out string user,
             out string password, out string authority)
            {
                authCookie = null;
                user = password = authority = null;
                return false;
            }
        }
    }
}
