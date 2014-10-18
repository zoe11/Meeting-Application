using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FT_ENV;
using FT_ControlsUtils;

namespace FT_Utils
{
    public class StatusHelper
    {
        /// <summary>
        /// 一级审核，根据审核状态编码设置核准状态
        /// </summary>
        /// <param name="auditStatusString">审核状态编码</param>
        /// <returns>拥有核准状态编码和核准状态中文名称的Model</returns>
        public static AppStatus SetAppStatusByAuditStatus1Level(string auditStatusString)
        {
            if (FTEnv.MOD.Equals(auditStatusString) || FTEnv.PED.Equals(auditStatusString) || FTEnv.TBS.Equals(auditStatusString))
            {
                return new AppStatus();
            }
            try
            {
                using (DictDataContext ddc = new DictDataContext(FTEnv.USERCONN))
                {
                    IList<DIC_ApprovedState> appStatusList = ddc.DIC_ApprovedState.Where(o => o.ApprovedStateCode != "").ToList();
                    if (FTEnv.ACC.Equals(auditStatusString))
                    {
                        int index = GetIndexByCode(FTEnv.AppACC, appStatusList);
                        if (-1 != index)
                        {
                            return new AppStatus(appStatusList[index].ApprovedStateChinese, appStatusList[index].ApprovedStateCode);
                        }
                    }
                    if (FTEnv.STP.Equals(auditStatusString))
                    {
                        int index = GetIndexByCode(FTEnv.AppSTP, appStatusList);
                        if (-1 != index)
                        {
                            return new AppStatus(appStatusList[index].ApprovedStateChinese, appStatusList[index].ApprovedStateCode);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                FTMessageBox.ShowErrorDialog(e.Message);
            }

            return null;
        }

       /// <summary>
        /// 二级审核，根据审核状态编码设置核准状态
        /// </summary>
        /// <param name="auditStatusString">审核状态编码</param>
        /// <returns>拥有核准状态编码和核准状态中文名称的Model</returns>
        public static AppStatus SetAppStatusByAuditStatus2Level(string auditStatusString)
        {
            if (FTEnv.MOD.Equals(auditStatusString) || FTEnv.PED.Equals(auditStatusString) || FTEnv.TBS.Equals(auditStatusString))
            {
                return new AppStatus();
            }
            try
            {
                using (DictDataContext ddc = new DictDataContext(FTEnv.USERCONN))
                {
                    IList<DIC_ApprovedState> appStatusList = ddc.DIC_ApprovedState.Where(o => o.ApprovedStateCode != "").ToList();
                    if (FTEnv.ACC.Equals(auditStatusString))
                    {
                        int index = GetIndexByCode(FTEnv.AppPED, appStatusList);
                        if (-1 != index)
                        {
                            return new AppStatus(appStatusList[index].ApprovedStateChinese, appStatusList[index].ApprovedStateCode);
                        }
                    }
                    if (FTEnv.STP.Equals(auditStatusString))
                    {
                        int index = GetIndexByCode(FTEnv.AppSTP, appStatusList);
                        if (-1 != index)
                        {
                            return new AppStatus(appStatusList[index].ApprovedStateChinese, appStatusList[index].ApprovedStateCode);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                FTMessageBox.ShowErrorDialog(e.Message);
            }

            return null;
        }

        private static int GetIndexByCode(string ApproveStatusCode, IList<DIC_ApprovedState> appStatusList)
        {
            int i = 0;
            for (i=0; i < appStatusList.Count; i++)
            {
                if (ApproveStatusCode.Equals(appStatusList[i].ApprovedStateCode))
                    return i;
            }
            return -1;
        }
    }

    public class AppStatus
    {
        public AppStatus()
        {
            this.ApproveStatus = "";
            this.ApproveStatusCode = "";
        }
        public AppStatus(string ApproveStatus, string ApproveStatusCode)
        {
            this.ApproveStatus = ApproveStatus;
            this.ApproveStatusCode = ApproveStatusCode;
        }
        public string ApproveStatusCode {set;get; }
        public string ApproveStatus { set; get; }
    }
}
