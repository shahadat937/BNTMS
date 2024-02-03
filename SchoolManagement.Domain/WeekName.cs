using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class WeekName : BaseDomainEntity
    {
        

        public int WeekNameId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        
       
    }
}
