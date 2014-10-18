using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FT_Utils
{
    public class MoveNoTitleWin
    {
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hWnd, int wMsg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern int ReleaseCapture();
        private const int WM_SysCommand = 0x0112;
        private const int SC_MOVE = 0xF012;


        public void SendMessage(Int32 Handle)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_SysCommand, SC_MOVE, 0);
        }
    }
}
