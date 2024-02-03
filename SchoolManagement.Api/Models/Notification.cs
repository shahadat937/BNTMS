using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public string SenderRole { get; set; }
        public string ReceiverRole { get; set; }
        public int? SendBaseSchoolNameId { get; set; }
        public int? ReceivedBaseSchoolNameId { get; set; }
        public string Notes { get; set; }
        public int? ReciverSeenStatus { get; set; }
        public DateTime? EndDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName ReceivedBaseSchoolName { get; set; }
        public virtual BaseSchoolName SendBaseSchoolName { get; set; }
    }
}
