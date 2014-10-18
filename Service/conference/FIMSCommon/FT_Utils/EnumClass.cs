using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FT_Utils
{
    public enum StepEnum
    {
        Create,
        Modify,
        Audit,
        Approve
    }

    public enum StatusEnum
    {
        AuditAccept,//审核后通过
        AuditModify,//审核后修改
        AudtiStop,//审核后废弃
        ApprovedAccept,//核准后通过
        ApprovedStop,//核准后废止
        Pending,//待审核
        ToBeSubmitted//待提交
    }
}
