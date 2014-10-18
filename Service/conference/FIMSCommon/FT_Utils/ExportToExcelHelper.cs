﻿#region 文件注释
/*----------------------------------------------------------------
	// Copyright (C) 2013 武汉飞特信息技术有限公司
	// 版权所有。 
        //
        // 文件名：
        // 文件功能描述：
        //
        // 
        // 创建标识：FT.XWQ
        // 修改标识：
        // 修改描述：
        //
        // 修改标识：
        // 修改描述：
	//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using FT_ControlsUtils;
using System.Reflection;


namespace FT_Utils
{
    ///
    ///导出excel
    ///
    public class ExportToExcelHelper
    {


        #region DataGridView导出到Excel，有一定的判断性
        /// <summary> 
        ///方法，导出DataGridView中的数据到Excel文件 
        /// </summary> 
        /// <remarks>
        /// add com "Microsoft Excel 11.0 Object Library"
        /// using Excel=Microsoft.Office.Interop.Excel;
        /// using System.Reflection;
        /// </remarks>
        /// <param name= "dgv"> DataGridView </param> 
        public static void DataGridViewToExcel(DataGridView dgv)
        {
            //申明保存对话框 
            SaveFileDialog dlg = new SaveFileDialog();
            //默然文件后缀 
            dlg.DefaultExt = "xls";
            //dlg.DefaultExt = "xlsx";
            //文件后缀列表 
            //dlg.Filter = "EXCEL文件(*.XLSX)|*.xlsx";
            dlg.Filter = "Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx";
            //默然路径是系统当前路径 
            //dlg.FileName = this.tbStockCountBillID.Text;
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            //打开保存对话框 
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            //返回文件路径 
            string fileNameString = dlg.FileName;
            //验证strFileName是否为空或值无效 
            if (fileNameString.Trim() == "")
            {
                return;
            }


            #region   验证可操作性


            //定义表格内数据的行数和列数 
            int rowscount = dgv.Rows.Count;
            int colscount = dgv.Columns.Count;
            //行数必须大于0 
            if (rowscount <= 0)
            {
                FTMessageBox.ShowErrorDialog("没有数据可供保存 ");
                return;
            }

            //列数必须大于0 
            if (colscount <= 0)
            {
                FTMessageBox.ShowErrorDialog("没有数据可供保存 ");
                return;
            }

            //行数不可以大于65536 
            if (rowscount > 65536)
            {
                FTMessageBox.ShowErrorDialog("数据记录数太多(最多不能超过65536条)，不能保存 ");
                return;
            }

            //列数不可以大于255 
            if (colscount > 255)
            {
                FTMessageBox.ShowErrorDialog("数据记录行数太多，不能保存 ");
                return;
            }

            //验证以fileNameString命名的文件是否存在，如果存在删除它 
            FileInfo file = new FileInfo(fileNameString);
            if (file.Exists)
            {
                try
                {
                    file.Delete();
                }
                catch (Exception error)
                {
                    FTMessageBox.ShowErrorDialog(error.Message);
                    return;
                }
            }
            #endregion


            Excel.Application objExcel = null;
            Excel.Workbook objWorkbook = null;
            Excel.Worksheet objsheet = null;
            try
            {
                //申明对象 
                objExcel = new Microsoft.Office.Interop.Excel.Application();
                objWorkbook = objExcel.Workbooks.Add(Missing.Value);
                objsheet = (Excel.Worksheet)objWorkbook.ActiveSheet;
                //设置EXCEL不可见 
                objExcel.Visible = false;

                //向Excel中写入表格的表头 
                int displayColumnsCount = 1;
                for (int i = 0; i <= dgv.ColumnCount - 1; i++)
                {
                    if (dgv.Columns[i].Visible == true)
                    {
                        objExcel.Cells[1, displayColumnsCount] = dgv.Columns[i].HeaderText.Trim();
                        displayColumnsCount++;
                    }
                }
                //设置进度条 
                //tempProgressBar.Visible = true;
                //tempProgressBar.Refresh();
                //tempProgressBar.Visible = true;
                //tempProgressBar.Minimum = 1;
                //tempProgressBar.Maximum = dgv.RowCount;
                //tempProgressBar.Step = 1;
                //向Excel中逐行逐列写入表格中的数据 
                for (int row = 0; row <= dgv.RowCount - 1; row++)
                {
                    //tempProgressBar.PerformStep();

                    displayColumnsCount = 1;
                    for (int col = 0; col < colscount; col++)
                    {
                        if (dgv.Columns[col].Visible == true)
                        {
                            try
                            {
                                if (dgv.Rows[row].Cells[col].ValueType == typeof(DateTime))
                                {
                                    objExcel.Cells[row + 2, displayColumnsCount] = "'" + DateTime.Parse(dgv.Rows[row].Cells[col].Value.ToString()).ToString("yyyy-MM-dd");
                                }
                                else
                                {
                                    objExcel.Cells[row + 2, displayColumnsCount] = "'" + dgv.Rows[row].Cells[col].Value.ToString().Trim();
                                }
                                displayColumnsCount++;
                            }
                            catch (Exception)
                            {

                            }

                        }
                    }
                }
                //隐藏进度条 
                //tempProgressBar.Visible   =   false; 
                //保存文件 
                objWorkbook.SaveAs(fileNameString, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Excel.XlSaveAsAccessMode.xlShared, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value);

                FTMessageBox.ShowSuccessDialog(fileNameString + "\n导出完毕! ");
                //tempProgressBar.Visible = false;

            }
            catch (Exception error)
            {
                FTMessageBox.ShowErrorDialog(error.Message);
                return;
            }
            finally
            {
                //关闭Excel应用 
                if (objWorkbook != null)
                    objWorkbook.Close(Missing.Value, Missing.Value, Missing.Value);
                if (objExcel.Workbooks != null)
                    objExcel.Workbooks.Close();
                if (objExcel != null)
                    objExcel.Quit();

                objsheet = null;
                objWorkbook = null;
                objExcel = null;
            }

        }

        #endregion



    }

}
