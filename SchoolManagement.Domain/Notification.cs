using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Notification : BaseDomainEntity
    {
        public Notification()
        {
           
        }

        public int NotificationId { get; set; }
        public int? SendBaseSchoolNameId { get; set; }
        public int? ReceivedBaseSchoolNameId { get; set; }
        public string? ReceiverRole { get; set; }
        public string? SenderRole { get; set; }
        public string? Notes { get; set; }
        public int? ReciverSeenStatus { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }

    }
}
