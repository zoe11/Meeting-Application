using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using FT_ENV;

namespace FTComponentSet
{
    public class DataGridViewFT : DataGridView
    {
        private IList<string> timeColumnName = new List<string>();
        private IList<string> dateColumnName = new List<string>();
        private IList<string> doubleColumnName = new List<string>();
        private bool isFirstRowDisEnable = true;
        private int autoSizeNumber = 100;



        public int AutoSizeNumber
        {
            get
            {
                return this.Columns.Count;
            }
            set
            {
                if (value > this.Columns.Count)
                {
                    autoSizeNumber = this.Columns.Count;
                }
                this.autoSizeNumber = value;

            }
        }


        public bool IsFirstRowDisEnable
        {
            get
            {
                return this.isFirstRowDisEnable;
            }
            set
            {
                this.isFirstRowDisEnable = value;
                if (value)
                {
                    this.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridViewFT_DataBindingComplete);
                }
                else
                {
                    this.DataBindingComplete += null;
                }
            }
        }

        public string TimeColumnName
        {
            get
            {
                return null;
            }
            set
            {
                this.timeColumnName.Add(value);
                FormatTimeColumn();
            }

        }

        public string DateColumnName
        {
            get
            {
                return null;
            }
            set
            {
                this.dateColumnName.Add(value);
                FormatDateColumn();
            }

        }

        public string DoubleColumnName
        {
            get
            {
                return null;
            }
            set
            {
                this.doubleColumnName.Add(value);
                FormatDoubleColumn();
            }

        }



        public DataGridViewFT()
            : base()
        {
            SkinController.SetFTDataGridViewSkin(this);
            InitializeComponent();
        }
        private void FormatTimeColumn()
        {
            foreach (string timeColumn in this.timeColumnName)
            {
                if (!String.IsNullOrEmpty(timeColumn))
                {
                    this.Columns[timeColumn].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                }
            }

        }


        private void FormatDateColumn()
        {
            foreach (string dateColumn in this.dateColumnName)
            {
                if (!String.IsNullOrEmpty(dateColumn))
                {
                    this.Columns[dateColumn].DefaultCellStyle.Format = "yyyy-MM-dd";
                }
            }
        }

        private void FormatDoubleColumn()
        {
            foreach (string doubleColumn in this.doubleColumnName)
            {
                if (!String.IsNullOrEmpty(doubleColumn))
                {
                    this.Columns[doubleColumn].DefaultCellStyle.Format = "#0.000";
                }
            }
        }


        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewFT
            // 
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ColumnHeadersHeight = FT_ENV.FTEnv.ColumnHeaderHeight;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(DataGridViewFT_DataBindingComplete_AutoSize);

            this.Paint += new PaintEventHandler(DataGridViewFT_Paint);
        }

        void DataGridViewFT_Paint(object sender, PaintEventArgs e)
        {
            bool hasFill;
            int sumWidth = CalculateWidth(out hasFill);
            if (hasFill)
            {
                return;
            }
            int addedWidth = this.Width - sumWidth;
            if (addedWidth > 0)
            {
                for (int i = AutoSizeNumber - 1; i > 0; i--)
                {
                    if (this.Columns[i].Visible == false)
                    {
                        continue;
                    }
                    this.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    this.Columns[i].Width += addedWidth;
                    //this.ScrollBars = ScrollBars.Vertical;
                    break;
                }
            }
        }

        private int CalculateWidth(out bool hasFill)
        {
            hasFill = false;
            int wid = 0;
            for (int i = 0; i < this.Columns.Count; i++)
            {
                if (this.Columns[i].AutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
                {
                    hasFill = true;
                    break;
                }
                if (this.Columns[i].Visible == false)
                {
                    continue;
                }
                wid += this.Columns[i].Width;
            }
            return wid;
        }

        private void DataGridViewFT_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ColumnHeadersHeight = FT_ENV.FTEnv.ColumnHeaderHeight;
            if (autoSizeNumber > this.Columns.Count)
            {
                autoSizeNumber = this.Columns.Count;
            }
            for (int i = 0; i < AutoSizeNumber; i++)
            {
                //if (this.Columns[i].AutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
                //{

                //    continue;
                //}
                this.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            if (this.IsFirstRowDisEnable)
            {
                this.CurrentCell = null;
            }

        }

        private void DataGridViewFT_DataBindingComplete_AutoSize(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ColumnHeadersHeight = FT_ENV.FTEnv.ColumnHeaderHeight;
            if (autoSizeNumber > this.Columns.Count)
            {
                autoSizeNumber = this.Columns.Count;
            }
            for (int i = 0; i < AutoSizeNumber; i++)
            {
                //if (this.Columns[i].AutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
                //{

                //    continue;
                //}
                this.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
            //if (this.Rows.Count==0)
            //{
            //    return;
            //}
            //bool hasFill = false;
            //this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            //this.ColumnHeadersHeight = FT_ENV.FTEnv.ColumnHeaderHeight;
            //if (autoSizeNumber > this.Columns.Count)
            //{
            //    autoSizeNumber = this.Columns.Count;
            //}
            //for (int i = 0; i < AutoSizeNumber; i++)
            //{
            //    //if (this.Columns[i].AutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
            //    //{
            //    //    //hasFill = true;
            //    //    continue;
            //    //}
            //    this.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //}
            //_widSum = 0;
            //if (hasFill)
            //{
            //    this.Columns[AutoSizeNumber-1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //}
            //else
            //{
            //    for (int i = AutoSizeNumber - 1; i>0; i--)
            //    {
            //        if (this.Columns[i].Visible == false)
            //        {
            //            continue;
            //        }
            //        this.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //        break;
            //    }
            //}
        }

    

}
