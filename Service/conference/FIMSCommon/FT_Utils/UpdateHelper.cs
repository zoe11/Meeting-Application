using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using FT_ControlsUtils;

namespace FT_Utils
{
    public class UpdateHelper
    {
        public static bool StartUpdate()
        {
            string processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            string Msg;
            bool result = StartProcess("Update.exe", processName,out Msg);
            if (!result)
            {
                //FTMessageBox.ShowErrorDialog(Msg);
                FTMessageBox.ShowErrorDialog("自动更新失败，系统将无法启动！请联系系统管理员！");
                LogHelper.LogWrite(Msg);
                return false;
            }
            return true;
        }

        public static bool StartProcess(string aProPath, string processName,out string Msg)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = aProPath;
                Info.Arguments = processName;
                Info.UseShellExecute = false;
                Process ps = Process.Start(Info);//开启进程
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return false;                                    //失败
            }
            Msg = "Success";
            return true;                                        //成功
        }
    }
}