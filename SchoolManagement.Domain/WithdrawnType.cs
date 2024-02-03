using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class WithdrawnType : BaseDomainEntity
    {
        public WithdrawnType()
        {

            //Relegations = new HashSet<Relegation>();
           
        }

        public int WithdrawnTypeId { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        //public virtual ICollection<Relegation> Relegations { get; set; }
        

    }
}
