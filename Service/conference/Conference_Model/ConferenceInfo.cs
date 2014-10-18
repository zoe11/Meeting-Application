using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Conference_Model
{
    public class ConferenceInfo
    {
        [DisplayName("会议I")]
        public string ConferenceID { get; set; }

        [DisplayName("会议名")]
        public string ConferenceName { get; set; }

        [DisplayName("日")]
        public System.Nullable<System.DateTime> ConferenceDate { get; set; }

        [DisplayName("开始时")]
        public System.Nullable<System.DateTime> StartTime { get; set; }

        [DisplayName("预约")]
        public string AppointmentPeople { get; set; }

        [DisplayName("参会")]
        public string ParticipantsPeople { get; set; }

        [DisplayName("议")]
        public string ConferenceTopics { get; set; }

        [DisplayName("地")]
        public string ConferencePlace { get; set; }

        [DisplayName("备")]
        public string Notes { get; set; }


    }
}
