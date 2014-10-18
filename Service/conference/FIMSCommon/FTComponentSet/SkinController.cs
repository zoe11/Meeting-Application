using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.PowerPacks;
using System.Drawing;
using System.Windows.Forms;



namespace FTComponentSet
{
    public class SkinController
    {
       //设置LineShape 皮肤
        public static void SetLineShapesSkin(params LineShape[] ls)
        {
            for (int i = 0; i < ls.Length; i++)
            {
                ls[i].BorderColor = Env_Const.LineShapeColor;
            }
        }

        //设置每个控件的皮肤
        public static void SetFTContrsSkin( Control[] control)
        {

            for (int i = 0; i < control.Length; i++)
            {
                
                SetFTContrSkin(control[i]);
            }
        }
        private static void SetFTContrSkin(Control control)
        {
            if (control.GetType().Name .Equals("ButtonFT"))
                {
                    ButtonFT temp = (ButtonFT)(control);
                    SetFTButtonSkin(temp);
                    //temp.SetColors();
                }
            else if (control.GetType().Name.Equals("CheckBoxFT"))
                {
                    CheckBoxFT temp = (CheckBoxFT)(control);
                    SetFTCheckBoxSkin(temp);
                }
            else if (control.GetType().Name .Equals("ComboBoxFT"))
                {
                    ComboBoxFT temp = (ComboBoxFT)(control);
                    SetFTComboBoxSkin(temp);
                    temp.SetLabelPosition(temp.Parent);
                }
            else if (control.GetType().Name.Equals("DataGridViewFT"))
            {
                DataGridViewFT temp = (DataGridViewFT)(control);
                SetFTDataGridViewSkin(temp);
            }
            else if (control.GetType().Name.Equals("DateTimePickerFT"))
            {
                DateTimePickerFT temp = (DateTimePickerFT)(control);
                SetFTDateTimePickerSkin(temp);
                temp.SetLabelPosition(temp.Parent);
                
            }
            else if (control.GetType().Name.Equals("ErrorProviderFT"))
            {
                //ErrorProviderFT temp = (ErrorProviderFT)(control);
                //SetFTErrorProviderSkin(temp);
            }
            else if (control.GetType().Name.Equals("GroupBoxFT"))
            {
                GroupBoxFT temp = (GroupBoxFT)(control);
                SetFTGroupBoxSkin(temp);
            }
            else if (control.GetType().Name.Equals("LabelFT"))
            {
                LabelFT temp = (LabelFT)(control);
                SetFTLabelSkin(temp);
            }
            else if (control.GetType().Name.Equals("PanelFT"))
            {
                PanelFT temp = (PanelFT)(control);
                SetFTPanelSkin(temp);
            }
            else if (control.GetType().Name.Equals("PictureBoxFT"))
            {
                PictureBoxFT temp = (PictureBoxFT)(control);
                SetFTPictureBoxSkin(temp);
            }
            else if (control.GetType().Name.Equals("RadioButtonFT"))
            {
                RadioButtonFT temp = (RadioButtonFT)(control);
                SetFTRadioButtonSkin(temp);
            }
            else if (control.GetType().Name.Equals("RichTextBoxFT"))
            {
                RichTextBoxFT temp = (RichTextBoxFT)(control);
                SetFTRichTextBoxSkin(temp);
            }
            else if (control.GetType().Name.Equals("TabControlFT"))
            {
                TabControlFT temp = (TabControlFT)(control);
                SetFTTabControlSkin(temp);
            }
            else if (control.GetType().Name.Equals("TextBoxFT"))
            {
                TextBoxFT temp = (TextBoxFT)(control);
                SetFTTextBoxSkin(temp);
                temp.SetLabelPosition(temp.Parent);
            }
            else if (control.GetType().Name.Equals("TextBoxInt32FT"))
            {
                TextBoxInt32FT temp = (TextBoxInt32FT)(control);
                SetFTTextBoxInt32Skin(temp);
                temp.SetLabelPosition(temp.Parent);
            }
            else if (control.GetType().Name.Equals("TextBoxFloatFT"))
            {
                TextBoxFloatFT temp = (TextBoxFloatFT)(control);
                SetFTTextBoxFloatSkin(temp);
                temp.SetLabelPosition(temp.Parent);
                
            }
            else if (control.GetType().Name.Equals("TextBoxStringFT"))
            {
                TextBoxStringFT temp = (TextBoxStringFT)(control);
                SetFTTextBoxStringSkin(temp);
                temp.SetLabelPosition(temp.Parent);
            }
            else if (control.GetType().Name.Equals("TreeViewFT"))
            {
                TreeViewFT temp = (TreeViewFT)(control);
                SetFTTreeViewSkin(temp);
            }
            else if (control.GetType().Name.Equals("ComboBoxFT"))
            {
                ComboBoxFT temp = (ComboBoxFT)(control);
                SetFTComboBoxSkin(temp);
            }
            else if (control.GetType().Name.Equals("ButtonFT4Test"))
            {
                ButtonFT4Test temp = (ButtonFT4Test)(control);
                SetFTButtonSkin(temp);
            }
        }
        public static void SetFTButtonSkin(ButtonFT temp)
        {

          //ButtonFT temp;
            //去掉边框
            temp.FlatStyle = FlatStyle.Popup;
            
            temp.BackColor = Env_Const.buttonColorGreen;
            temp.ForeColor = Color.White;

            //字体
            temp.Font = Env_Const.textFont;
            temp.SetColors();

        }

        public static void SetFTButtonSkin(ButtonFT4Test temp)
        {

            //ButtonFT temp;
            //去掉边框
            temp.FlatStyle = FlatStyle.Popup;

            temp.BackColor = Env_Const.buttonColorGreen;
            temp.ForeColor = Color.White;

            //字体
            temp.Font = Env_Const.textFont;
            temp.SetColors();
            if (FT_ENV.FTEnv.IsDebug)
            {
                temp.Visible = true;
            }
            else
            {
                temp.Visible = false;
            }

        }
        public static void SetFTCheckBoxSkin(CheckBoxFT temp)
        {
            //字体
            temp.Font = Env_Const.textFont;

        }
        public static void SetFTComboBoxSkin(ComboBoxFT temp)
        {
            temp.Width = Env_Const.tbWidth;
            temp.Height = Env_Const.tbHeight;

            //字体
            temp.Font = Env_Const.textFont;
            temp.ImeMode = ImeMode.Disable;
        }
        public static void SetFTDataGridViewSkin(DataGridViewFT temp)
        {
            //字体
            temp.Font = Env_Const.textFont;

            //标题栏颜色设置
            temp.EnableHeadersVisualStyles = false;
            //不显示追加行
            temp.AllowUserToAddRows = false;
            //行头隐藏
            temp.RowHeadersVisible = false;

            // temp.SelectionMode           

            //temp.ColumnHeadersHeight = 50;

            //列头单元格样式设置
            temp.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(91, 104, 112);//背景色
            temp.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;//字体颜色
            temp.ColumnHeadersDefaultCellStyle.SelectionBackColor = SystemColors.Highlight;//选择时背景
            temp.ColumnHeadersDefaultCellStyle.SelectionForeColor = SystemColors.Highlight;//选择时字体颜色
            temp.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;//单元格内容太长时显示格式
            temp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//整行选中
            //奇数行单元格样式设置
            temp.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;

            //全部单元格只读
            temp.ReadOnly = true;

            //设定列头的宽度自动调整
            temp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

        }
        public static void SetFTDateTimePickerSkin(DateTimePickerFT temp)
        {
            temp.Width = Env_Const.tbWidth;
            temp.Height = Env_Const.tbHeight;

            //字体
            temp.Font = Env_Const.textFont;

        }
        public static void SetFTErrorProviderSkin(ErrorProviderFT temp)
        {
           
        }
        public static void SetFTGroupBoxSkin(GroupBoxFT temp)
        {
            //字体
            temp.Font = Env_Const.textFont;

        }
        public static void SetFTLabelSkin(LabelFT temp)
        {
            //字体
            temp.Font = Env_Const.textFont;

        }
        public static void SetFTPanelSkin(PanelFT temp)
        {
           

        }
        public static void SetFTPictureBoxSkin(PictureBoxFT temp)
        {
            //字体
            temp.Font = Env_Const.textFont;

        }
        public static void SetFTRadioButtonSkin(RadioButtonFT temp)
        {
           
        }
        public static void SetFTRichTextBoxSkin(RichTextBoxFT temp)
        {
            //字体
            temp.Font = Env_Const.textFont;

        }
        public static void SetFTTabControlSkin(TabControlFT temp)
        {
            //字体
            temp.Font = Env_Const.textFont;

        }
        public static void SetFTTextBoxSkin(TextBoxFT temp)
        {
            //temp.Refresh();
            temp.Width = Env_Const.tbWidth;
            temp.Height = Env_Const.tbHeight;
            //字体
            temp.Font = Env_Const.textFont;
            temp.SetBackColor();
        }
        public static void SetFTTextBoxInt32Skin(TextBoxInt32FT temp)
        {
            //属性设置
            temp.Width = Env_Const.tbWidth;
            temp.Height = Env_Const.tbHeight;

            //字体
            temp.Font = Env_Const.textFont;

        }
        public static void SetFTTextBoxFloatSkin(TextBoxFloatFT temp)
        {
            //属性设置
            temp.Width = Env_Const.tbWidth;
            temp.Height = Env_Const.tbHeight;

            //字体
            temp.Font = Env_Const.textFont;

        }
        public static void SetFTTextBoxStringSkin(TextBoxStringFT temp)
        {
            //属性设置
            temp.Width = Env_Const.tbWidth;
            temp.Height = Env_Const.tbHeight;
            //字体
            temp.Font = Env_Const.textFont;

        }
        public static void SetFTTreeViewSkin(TreeViewFT temp)
        {
            //字体
            temp.Font = Env_Const.textFont;
        }
    }
}


   