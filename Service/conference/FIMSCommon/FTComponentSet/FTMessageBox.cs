using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FT_ENV;

namespace FT_ControlsUtils
{
    /// <summary>
    /// 弹出的框
    /// </summary>
    public class FTMessageBox
    {
        /// <summary>
        /// 错误输出的提示框
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DialogResult ShowErrorDialog(string text)
        {
            return MessageBox.Show(text, FTEnv.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowSuccessDialog(string text)
        {
            return MessageBox.Show(text, FTEnv.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowQuestionDialog(string text, string caption)
        {
            return MessageBox.Show(text, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        public static DialogResult ShowQuestionYesNoDialog(string text, string caption)
        {
            return MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult Show(string text)
        {
            return MessageBox.Show(text);
        }

        public static DialogResult Show(string text, string caption)
        {
            return MessageBox.Show(text, caption);
        }

        public static DialogResult Show(string text, string caption,
                                                             MessageBoxButtons buttons)
        {
            return MessageBox.Show(text, caption, buttons);
        }
        public static DialogResult Show(string text, string caption,
                                                             MessageBoxButtons buttons,
                                                             MessageBoxIcon icon)
        {
            return MessageBox.Show(text, caption, buttons, icon);
        }

        public static DialogResult Show(string text, string caption,
                                                             MessageBoxButtons buttons,
                                                             MessageBoxIcon icon,
                                                             MessageBoxDefaultButton defaultButton)    
        {
            return MessageBox.Show(text, caption, buttons, icon, defaultButton);
        }

        public static DialogResult Show(string text, string caption,
                                                             MessageBoxButtons buttons,
                                                             MessageBoxIcon icon,
                                                             MessageBoxDefaultButton defaultButton,
                                                             MessageBoxOptions options)
        {
            return MessageBox.Show(text, caption, buttons, icon, defaultButton, options);
        }

        public static System.Windows.Forms.DialogResult Show(System.Windows.Forms.IWin32Window owner, string text,
                                                             string caption,
                                                             System.Windows.Forms.MessageBoxButtons buttons,
                                                             System.Windows.Forms.MessageBoxIcon icon,
                                                             System.Windows.Forms.MessageBoxDefaultButton defaultButton,
                                                             System.Windows.Forms.MessageBoxOptions options,
                                                             string helpFilePath,
                                                             System.Windows.Forms.HelpNavigator navigator, object param)
        {
            return MessageBox.Show(owner,text, caption, buttons, icon, defaultButton, options, helpFilePath, navigator, param);
        }
    }
}
