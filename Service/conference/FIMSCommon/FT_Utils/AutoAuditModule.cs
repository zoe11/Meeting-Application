using System;
using System.Linq;
using FT_ENV;

// 
namespace FT_Utils
{
    public class AutoAuditModule
    {
        public static AutoAuditInfo AssemblyAuditInfo(string receiptCode, StepEnum step, StatusEnum status, string operatorId,
                                               string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {
            string auditLevel = GetReceiptsAuditLevel(receiptCode);
            int level = -1;
            if (!string.IsNullOrEmpty(auditLevel))
            {
                level = int.Parse(auditLevel);
            }
            if (level == -1)
            {
                return null;
            }

            switch (level)
            {
                case 0:
                    autoAuditInfo = AssemblyAuditInfo4LevelZero(step, status, operatorId, operatorName, operateTime, autoAuditInfo);
                    break;

                case 1:
                    autoAuditInfo = AssemblyAuditInfo4LevelOne(step, status, operatorId, operatorName, operateTime, autoAuditInfo);
                    break;

                case 2:
                    autoAuditInfo = AssemblyAuditInfo4LevelTwo(step, status, operatorId, operatorName, operateTime, autoAuditInfo);
                    break;
            }
            return autoAuditInfo;
        }

        #region 0级

        private static AutoAuditInfo AssemblyAuditInfo4LevelZero(StepEnum step, StatusEnum status, string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {
            switch (step)
            {
                //录入
                case StepEnum.Create:
            autoAuditInfo = AssemblyAuditInfo4LevelZeroCreate(status, operatorId, operatorName, operateTime, autoAuditInfo);
                    break;

                //修改
                case StepEnum.Modify:
                    autoAuditInfo = AssemblyAuditInfo4LevelZeroModify(status, operatorId, operatorName, operateTime, autoAuditInfo);
                    break;
            }
            return autoAuditInfo;
        }

        private static AutoAuditInfo AssemblyAuditInfo4LevelZeroCreate(StatusEnum status, string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {
            return status == StatusEnum.ToBeSubmitted ? AssemblyAuditInfo4ToBeSubmitted(operatorId, operatorName, operateTime, autoAuditInfo) : AssemblyAuditInfo4LevelZeroCreatePending(operatorId, operatorName, operateTime, autoAuditInfo);
        }

        /// <summary>
        /// 0级审核录入操作自动审核完成
        /// </summary>
        /// <param name="operatorId"></param>
        /// <param name="operatorName"></param>
        /// <param name="operateTime"></param>
        /// <param name="autoAuditInfo"></param>
        /// <returns></returns>
        private static AutoAuditInfo AssemblyAuditInfo4LevelZeroCreatePending(string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {
            autoAuditInfo.CreateOperatorID = operatorId;
            autoAuditInfo.CreateOperatorName = operatorName;
            autoAuditInfo.CreateTime = operateTime;
            autoAuditInfo.LastModiOperatorID = operatorId;
            autoAuditInfo.LastModiOperatorName = operatorName;
            autoAuditInfo.LastModiTime = operateTime;
            autoAuditInfo.AuditStatus = FTEnv.AuditAccept;
            autoAuditInfo.AuditStatusCode = FTEnv.ACC;
            autoAuditInfo.LastAuditOperatorID = LoginHelper.GetSystem();
            autoAuditInfo.LastAuditOperatorName = LoginHelper.GetSystemName();
            autoAuditInfo.LastAuditTime = operateTime;
            autoAuditInfo.ApprovedOperatorID = LoginHelper.GetSystem();
            autoAuditInfo.ApprovedOperatorName = LoginHelper.GetSystemName();
            autoAuditInfo.ApprovedState = FTEnv.AppAccept;
            autoAuditInfo.ApprovedStateCode = FTEnv.AppACC;
            autoAuditInfo.ApprovedTime = operateTime;
            return autoAuditInfo;
        }

        private static AutoAuditInfo AssemblyAuditInfo4LevelZeroModify(StatusEnum status, string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {
            return status == StatusEnum.ToBeSubmitted ? AssemblyAuditInfo4ModifyToBeSubmitted(operatorId, operatorName, operateTime, autoAuditInfo) : AssemblyAuditInfo4LevelZeroModifyPending(operatorId, operatorName, operateTime, autoAuditInfo);
        }

        /// <summary>
        /// 0级审核修改操作自动审核完成
        /// </summary>
        /// <param name="operatorId"></param>
        /// <param name="operatorName"></param>
        /// <param name="operateTime"></param>
        /// <param name="autoAuditInfo"></param>
        /// <returns></returns>
        private static AutoAuditInfo AssemblyAuditInfo4LevelZeroModifyPending(string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {

            autoAuditInfo.LastModiOperatorID = operatorId;
            autoAuditInfo.LastModiOperatorName = operatorName;
            autoAuditInfo.LastModiTime = operateTime;
            autoAuditInfo.AuditStatus = FTEnv.AuditAccept;
            autoAuditInfo.AuditStatusCode = FTEnv.ACC;
            autoAuditInfo.LastAuditOperatorID = LoginHelper.GetSystem();
            autoAuditInfo.LastAuditOperatorName = LoginHelper.GetSystemName();
            autoAuditInfo.LastAuditTime = operateTime;
            autoAuditInfo.ApprovedOperatorID = LoginHelper.GetSystem();
            autoAuditInfo.ApprovedOperatorName = LoginHelper.GetSystemName();
            autoAuditInfo.ApprovedState = FTEnv.AppAccept;
            autoAuditInfo.ApprovedStateCode = FTEnv.AppACC;
            autoAuditInfo.ApprovedTime = operateTime;
            return autoAuditInfo;
        }

        #endregion 0级

        #region 1级

        private static AutoAuditInfo AssemblyAuditInfo4LevelOne(StepEnum step, StatusEnum status, string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {
            switch (step)
            {
                //录入
                case StepEnum.Create:
                    autoAuditInfo = AssemblyAuditInfo4LevelOneCreate(status, operatorId, operatorName, operateTime, autoAuditInfo);
                    break;

                //修改
                case StepEnum.Modify:
                    autoAuditInfo = AssemblyAuditInfo4LevelOneModify(status, operatorId, operatorName, operateTime, autoAuditInfo);
                    break;

                case StepEnum.Audit:
                    autoAuditInfo = AssemblyAuditInfo4LevelOneAudit(status, operatorId, operatorName, operateTime, autoAuditInfo);
                    break;
            }
            return autoAuditInfo;
        }

        private static AutoAuditInfo AssemblyAuditInfo4LevelOneCreate(StatusEnum status, string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {
            return status == StatusEnum.ToBeSubmitted ? AssemblyAuditInfo4ToBeSubmitted(operatorId, operatorName, operateTime, autoAuditInfo) : AssemblyAuditInfo4LevelOneAndTwoCreatePending(operatorId, operatorName, operateTime, autoAuditInfo);
        }

        private static AutoAuditInfo AssemblyAuditInfo4LevelOneModify(StatusEnum status, string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {
            return status == StatusEnum.ToBeSubmitted ? AssemblyAuditInfo4ModifyToBeSubmitted(operatorId, operatorName, operateTime, autoAuditInfo) : AssemblyAuditInfo4LevelOneAndTwoModifyPending(operatorId, operatorName, operateTime, autoAuditInfo);
        }

        private static AutoAuditInfo AssemblyAuditInfo4LevelOneAudit(StatusEnum status, string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {
            switch (status)
            {
                case StatusEnum.AuditAccept:
                    return AssemblyAuditInfo4LevelOneAuditAccept(operatorId, operatorName, operateTime, autoAuditInfo);
                case StatusEnum.AuditModify:
                    return AssemblyAuditInfo4LevelOneAndTwoAuditModify(operatorId, operatorName, operateTime, autoAuditInfo);
                case StatusEnum.AudtiStop:
                    return AssemblyAuditInfo4LevelOneAndTwoAuditStop(operatorId, operatorName, operateTime, autoAuditInfo);
            }
            return null;
        }

        private static AutoAuditInfo AssemblyAuditInfo4LevelOneAuditAccept(string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {
            autoAuditInfo.AuditStatus = FTEnv.AuditAccept;
            autoAuditInfo.AuditStatusCode = FTEnv.ACC;
            autoAuditInfo.LastAuditOperatorID = operatorId;
            autoAuditInfo.LastAuditOperatorName = operatorName;
            autoAuditInfo.LastAuditTime = operateTime;
            autoAuditInfo.ApprovedState = FTEnv.AppAccept;
            autoAuditInfo.ApprovedStateCode = FTEnv.AppACC;
            autoAuditInfo.ApprovedOperatorID = LoginHelper.GetSystem();
            autoAuditInfo.ApprovedOperatorName = LoginHelper.GetSystemName();
            autoAuditInfo.ApprovedTime = operateTime;
              return autoAuditInfo;
        }

        #endregion 1级

        #region 2级

        private static AutoAuditInfo AssemblyAuditInfo4LevelTwo(StepEnum step, StatusEnum status, string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {
            
            switch (step)
            {
                //录入
                case StepEnum.Create:
                    autoAuditInfo = AssemblyAuditInfo4LevelTwoCreate(status, operatorId, operatorName, operateTime, autoAuditInfo);
                    break;

                //修改
                case StepEnum.Modify:
                    autoAuditInfo = AssemblyAuditInfo4LevelTwoModify(status, operatorId, operatorName, operateTime, autoAuditInfo);
                    break;

                case StepEnum.Audit:
                    autoAuditInfo = AssemblyAuditInfo4LevelTwoAudit(status, operatorId, operatorName, operateTime, autoAuditInfo);
                    break;

                case StepEnum.Approve:
                    autoAuditInfo = AssemblyAuditInfo4LevelTwoApprove(status, operatorId, operatorName, operateTime, autoAuditInfo);
                    break;
            }
            return autoAuditInfo;
        }

        private static AutoAuditInfo AssemblyAuditInfo4LevelTwoCreate(StatusEnum status, string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {
            return status == StatusEnum.ToBeSubmitted ? AssemblyAuditInfo4ToBeSubmitted(operatorId, operatorName, operateTime, autoAuditInfo) : AssemblyAuditInfo4LevelOneAndTwoCreatePending(operatorId, operatorName, operateTime, autoAuditInfo);
        }

        private static AutoAuditInfo AssemblyAuditInfo4LevelTwoModify(StatusEnum status, string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {
            return status == StatusEnum.ToBeSubmitted ? AssemblyAuditInfo4ModifyToBeSubmitted(operatorId, operatorName, operateTime, autoAuditInfo) : AssemblyAuditInfo4LevelOneAndTwoModifyPending(operatorId, operatorName, operateTime, autoAuditInfo);
        }

        private static AutoAuditInfo AssemblyAuditInfo4LevelTwoAudit(StatusEnum status, string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {
            switch (status)
            {
                case StatusEnum.AuditAccept:
                    return AssemblyAuditInfo4LevelTwoAuditAccept(operatorId, operatorName, operateTime, autoAuditInfo);
                case StatusEnum.AuditModify:
                    return AssemblyAuditInfo4LevelOneAndTwoAuditModify(operatorId, operatorName, operateTime, autoAuditInfo);
                case StatusEnum.AudtiStop:
                    return AssemblyAuditInfo4LevelOneAndTwoAuditStop(operatorId, operatorName, operateTime, autoAuditInfo);
            }
            return null;
        }

        private static AutoAuditInfo AssemblyAuditInfo4LevelTwoAuditAccept(string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {
            autoAuditInfo.AuditStatus = FTEnv.AuditAccept;
            autoAuditInfo.AuditStatusCode = FTEnv.ACC;
            autoAuditInfo.LastAuditOperatorID = operatorId;
            autoAuditInfo.LastAuditOperatorName = operatorName;
            autoAuditInfo.LastAuditTime = operateTime;
            autoAuditInfo.ApprovedState = FTEnv.AppPending;
            autoAuditInfo.ApprovedStateCode = FTEnv.AppPED;
            return autoAuditInfo;
        }

        private static AutoAuditInfo AssemblyAuditInfo4LevelTwoApprove(StatusEnum status, string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {
            switch (status)
            {
                case StatusEnum.ApprovedAccept:
                    return AssemblyAuditInfo4LevelTwoApprovedAccept(operatorId, operatorName, operateTime, autoAuditInfo);
                case StatusEnum.ApprovedStop:
                    return AssemblyAuditInfo4LevelTwoApprovedStop(operatorId, operatorName, operateTime, autoAuditInfo);
            }
            return null;
        }

        private static AutoAuditInfo AssemblyAuditInfo4LevelTwoApprovedAccept(string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {
            autoAuditInfo.ApprovedState = FTEnv.AppAccept;
            autoAuditInfo.ApprovedStateCode = FTEnv.AppACC;
            autoAuditInfo.ApprovedOperatorID = operatorId;
            autoAuditInfo.ApprovedOperatorName = operatorName;
            autoAuditInfo.ApprovedTime = operateTime;
               return autoAuditInfo;
        }

        private static AutoAuditInfo AssemblyAuditInfo4LevelTwoApprovedStop(string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {
            autoAuditInfo.ApprovedState = FTEnv.AppStop;
            autoAuditInfo.ApprovedStateCode = FTEnv.AppSTP;
            autoAuditInfo.ApprovedOperatorID = operatorId;
            autoAuditInfo.ApprovedOperatorName = operatorName;
            autoAuditInfo.ApprovedTime = operateTime;
              return autoAuditInfo;
        }

        #endregion 2级

        #region 1级2级录入提交操作

        private static AutoAuditInfo AssemblyAuditInfo4LevelOneAndTwoCreatePending(string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {
            autoAuditInfo.CreateOperatorID = operatorId;
            autoAuditInfo.CreateOperatorName = operatorName;
            autoAuditInfo.CreateTime = operateTime;
            autoAuditInfo.LastModiOperatorID = operatorId;
            autoAuditInfo.LastModiOperatorName = operatorName;
            autoAuditInfo.LastModiTime = operateTime;
            autoAuditInfo.AuditStatus = FTEnv.AuditPending;
            autoAuditInfo.AuditStatusCode = FTEnv.PED;
            autoAuditInfo.ApprovedOperatorID = null;
            autoAuditInfo.ApprovedOperatorName = null;
            autoAuditInfo.ApprovedState = null;
            autoAuditInfo.ApprovedStateCode = null;
            autoAuditInfo.ApprovedTime = null;
           return autoAuditInfo;
        }

        #endregion 1级2级录入提交操作

        #region 录入保存操作

        /// <summary>
        /// 录入操作待提交
        /// </summary>
        /// <param name="operatorId"></param>
        /// <param name="operatorName"></param>
        /// <param name="operateTime"></param>
        /// <param name="autoAuditInfo"></param>
        /// <returns></returns>
        private static AutoAuditInfo AssemblyAuditInfo4ToBeSubmitted(string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {
            autoAuditInfo.CreateOperatorID = operatorId;
            autoAuditInfo.CreateOperatorName = operatorName;
            autoAuditInfo.CreateTime = operateTime;
            autoAuditInfo.LastModiOperatorID = operatorId;
            autoAuditInfo.LastModiOperatorName = operatorName;
            autoAuditInfo.LastModiTime = operateTime;
            autoAuditInfo.AuditStatus = FTEnv.AuditSubmit;
            autoAuditInfo.AuditStatusCode = FTEnv.TBS;
            autoAuditInfo.LastAuditOperatorID = null;
            autoAuditInfo.LastAuditOperatorName = null;
            autoAuditInfo.LastAuditTime = null;
            autoAuditInfo.ApprovedOperatorID = null;
            autoAuditInfo.ApprovedOperatorName = null;
            autoAuditInfo.ApprovedState = null;
            autoAuditInfo.ApprovedStateCode = null;
            autoAuditInfo.ApprovedTime = null;
            return autoAuditInfo;
        }

        #endregion 录入保存操作

        #region 修改保存操作

        private static AutoAuditInfo AssemblyAuditInfo4ModifyToBeSubmitted(string operatorId, string operatorName,
                                                                           DateTime operateTime,
                                                                           AutoAuditInfo autoAuditInfo)
        {

            autoAuditInfo.LastModiOperatorID = operatorId;
            autoAuditInfo.LastModiOperatorName = operatorName;
            autoAuditInfo.LastModiTime = operateTime;
            autoAuditInfo.AuditStatus = FTEnv.AuditSubmit;
            autoAuditInfo.AuditStatusCode = FTEnv.TBS;
            autoAuditInfo.LastAuditOperatorID = null;
            autoAuditInfo.LastAuditOperatorName = null;
            autoAuditInfo.LastAuditTime = null;
            autoAuditInfo.ApprovedOperatorID = null;
            autoAuditInfo.ApprovedOperatorName = null;
            autoAuditInfo.ApprovedState = null;
            autoAuditInfo.ApprovedStateCode = null;
            autoAuditInfo.ApprovedTime = null;
            return autoAuditInfo;
        }

        #endregion 修改保存操作

        #region 1级2级修改提交

        private static AutoAuditInfo AssemblyAuditInfo4LevelOneAndTwoModifyPending(string operatorId, string operatorName,
                                                                      DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {

            autoAuditInfo.LastModiOperatorID = operatorId;
            autoAuditInfo.LastModiOperatorName = operatorName;
            autoAuditInfo.LastModiTime = operateTime;
            autoAuditInfo.AuditStatus = FTEnv.AuditPending;
            autoAuditInfo.AuditStatusCode = FTEnv.PED;
            autoAuditInfo.ApprovedOperatorID = null;
            autoAuditInfo.ApprovedOperatorName = null;
            autoAuditInfo.ApprovedState = null;
            autoAuditInfo.ApprovedStateCode = null;
            autoAuditInfo.ApprovedTime = null;
            return autoAuditInfo;
        }

        #endregion 1级2级修改提交

        #region 1级2级审核后修改、审核后废止

        private static AutoAuditInfo AssemblyAuditInfo4LevelOneAndTwoAuditModify(string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {
            
                    autoAuditInfo.AuditStatus = FTEnv.AuditModify;
                    autoAuditInfo.AuditStatusCode = FTEnv.MOD;
                    autoAuditInfo.LastAuditOperatorID = operatorId;
                    autoAuditInfo.LastAuditOperatorName = operatorName;
                   autoAuditInfo. LastAuditTime = operateTime;
            return autoAuditInfo;
        }

        private static AutoAuditInfo AssemblyAuditInfo4LevelOneAndTwoAuditStop(string operatorId, string operatorName, DateTime operateTime, AutoAuditInfo autoAuditInfo)
        {

                    autoAuditInfo.AuditStatus = FTEnv.AuditStop;
                    autoAuditInfo.AuditStatusCode = FTEnv.STP;
                    autoAuditInfo.LastAuditOperatorID = operatorId;
                    autoAuditInfo.LastAuditOperatorName = operatorName;
                    autoAuditInfo.LastAuditTime = operateTime;
                    autoAuditInfo.ApprovedState = FTEnv.AppStop;
                    autoAuditInfo.ApprovedStateCode = FTEnv.AppSTP;
                    autoAuditInfo.ApprovedOperatorID = LoginHelper.GetSystem();
                    autoAuditInfo.ApprovedOperatorName = LoginHelper.GetSystemName();
                   autoAuditInfo. ApprovedTime = operateTime;
                return autoAuditInfo;
        }

        #endregion 1级2级审核后修改、审核后废止

        #region 获取审核核准等级

        public static string GetReceiptsAuditLevel(string receiptCode)
        {
            using (var dc = new ReceiptsDataContext(FT_ENV.FTEnv.USERCONN))
            {
                var query = dc.DIC_ReceiptsAuditLevel.FirstOrDefault(o => o.ReceiptsCode == receiptCode);
                return query != null ? query.AuditLevel : "";
            }
        }

        #endregion 获取审核核准等级
    }
}