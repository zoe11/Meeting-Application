using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using FT_ENV;
using System.Net;

namespace FT_Utils
{
    public class GetHardwareInfo
    {
        #region 获取系统硬件信息
        /// <summary>
        /// 获取CPU序列号
        /// </summary>
        /// <returns>CPU序列号</returns>
        /// 
        private string GetSysPlatForm()
        {
            return "WIN32";
        }

        public string GetCpuID()
        {
            try
            {
                ManagementClass mc =null;
                if (GetSysPlatForm()=="WIN32")
                {
                    mc = new ManagementClass("Win32_Processor");
                }
                
                ManagementObjectCollection moc = mc.GetInstances();

                string strCpuID = "";
                string processId;
                if (moc == null||moc.Count ==0)
                {
                    strCpuID = "CPUEmpty";
                    return strCpuID;
                }
                foreach (ManagementObject mo in moc)
                {
                    try
                    {
                        processId = mo.Properties["ProcessorId"].Value.ToString();
                    }
                    catch (Exception)
                    {
                        processId = "null";
                    }

                    strCpuID += processId;
                }
                return strCpuID;
            }
            catch(Exception e)
            {
                LogHelper.CreateLogFile();
                LogHelper.LogWrite("获取CPU信息失败：" + e.Message + ":" + TimeHelper.SetDateTime());
                return "ErrorCPUInfo";
            }

        }

        /// <summary>
        /// 获取第一块硬盘的序列号
        /// </summary>
        /// <returns>第一块硬盘的序列号</returns>
        public string GetHardDiskID()
        {
            string logHelp = "searcher is null";
            try
            {
                ManagementObjectSearcher searcher = null;
                if (GetSysPlatForm() == "WIN32")
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive ");
                }
                
                ManagementObjectCollection objects = searcher.Get();
                string strHardDiskID = "";
                if (objects == null || objects.Count == 0)
                {
                    strHardDiskID = "HardDiskEmpty";
                    return strHardDiskID;
                }
                string hardDiskId;
                foreach (ManagementObject mo in objects)
                {
                    try
                    {
                        if (mo.Properties["InterfaceType"].Value.ToString() != "USB")
                        {
                            hardDiskId = mo.Properties["signature"].Value.ToString();
                        }
                        else
                        {
                            continue;
                        }
                    }
                    catch (Exception)
                    {
                        hardDiskId = "null";
                    }
                    logHelp = "searcher not null";
                    strHardDiskID += hardDiskId;
                    logHelp += " mo[SerialNumber] is null";
                }
                return strHardDiskID;
            }
            catch(Exception e)
            {
                LogHelper.CreateLogFile();
                LogHelper.LogWrite("获取硬盘信息失败：" + e.Message + ":" + TimeHelper.SetDateTime()+"->"+logHelp);
                return "ErrorHardDiskInfo";
            }
        }

        /// <summary>
        /// 获取Mac地址
        /// </summary>
        /// <returns>MAC地址（第一块有IP的网卡）</returns>
        public string GetMacAddress()
        {
            string logHelp = "";
            try
            {
                //获取网卡硬件地址 
                string mac = "";
                ManagementClass mc = null;
                string macAddress;
                if (GetSysPlatForm() == "WIN32")
                {
                    mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                }
                
                ManagementObjectCollection moc = mc.GetInstances();
                if (moc == null || moc.Count == 0)
                {
                    mac = "MacEmpty";
                    return mac;
                }
                foreach (ManagementObject mo in moc)
                {
                    if (mo["IPEnabled"].ToString() == "True")
                    {
                        try
                        {
                            macAddress = mo.Properties["MacAddress"].Value.ToString().Trim();
                        }
                        catch (Exception ex)
                        {
                            macAddress = "null";
                        }
                        mac += macAddress;
                    }
                }
                return mac;
            }
            catch(Exception e)
            {
                LogHelper.CreateLogFile();
                LogHelper.LogWrite("获取MAC信息失败：" + e.Message + ":" + TimeHelper.SetDateTime() + "->" + logHelp);
                return "ErrorMacInfo";
            }
        }

        /// <summary>
        /// 获取IP地址
        /// //2013-11-21 add by XWQ
        /// </summary>
        /// <returns>IP地址</returns>
        public string GetIPAddress()
        {
            string logHelp = "";
            try
            {
                string strHostName = Dns.GetHostName(); //得到本机的主机名
                IPHostEntry ipEntry = Dns.GetHostByName(strHostName); //取得本机IP
                string strAddr = ipEntry.AddressList[0].ToString();
                return strAddr;
            }
            catch (Exception e)
            {
                LogHelper.CreateLogFile();
                logHelp = "ErrorIPInfo";
                LogHelper.LogWrite("获取MAC信息失败：" + e.Message + ":" + TimeHelper.SetDateTime() + "->" + logHelp);
                return "ErrorIPInfo";
            }
        }

        #endregion

        #region 产生序列号
        /// <summary>
        /// 得到序列号
        /// </summary>
        /// <param name="serialid">序列号</param>
        /// <returns>获取成功返回true，否则返回false</returns>
        public bool GetGenerateSerialID(out string serialid)
        {
            serialid = null;
            string temp = null;
            if (FTEnv.IsCPUEmpower)
            {
                temp = GetCpuID();
                serialid += temp;
            }

            if (FTEnv.IsHardDiskEmpower)
            {
                temp = GetHardDiskID();
                serialid += temp;
            }

            if (FTEnv.IsMACEmpower)
            {
                temp = GetMacAddress();
                serialid += temp;
            }
            return true;

        }
        #endregion

        #region 得到当前主机名
        /// <summary>
        /// 获取主机名
        /// </summary>
        /// <returns>当前主机名</returns>
        public string GetHostName()
        {
            return System.Net.Dns.GetHostName();
        }
        #endregion
    }
}
