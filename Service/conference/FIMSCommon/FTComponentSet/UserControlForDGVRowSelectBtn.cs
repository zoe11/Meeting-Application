using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FTComponentSet
{
    public partial class UserControlForDGVRowSelectBtn : UserControl
    {
        private DataGridViewFT _dgv;

        public UserControlForDGVRowSelectBtn()
        {
            InitializeComponent();

            this.btnSelectAll.Width = 75;
            this.btnSelectAll.Height = 23;

            this.btnReverseSelected.Width = 75;
            this.btnReverseSelected.Height = 23;
        }

        public void SetDGV(DataGridViewFT dgv)
        {
            this._dgv = dgv;
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (_dgv == null)
                return;

            for (int i = 0; i < this._dgv.Rows.Count; i++)
            {
                _dgv.Rows[i].Cells[0].Value = true;
            }
        }

        /// <summary>
        /// 反选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReverseSelected_Click(object sender, EventArgs e)
        {
            if (_dgv == null)
            {
                return;
            }
            for (int i = 0; i < this._dgv.Rows.Count; i++)
            {
                bool temp = (bool)_dgv.Rows[i].Cells[0].EditedFormattedValue;
                _dgv.Rows[i].Cells[0].Value = !temp;
            }
        }
    }
}
