using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetNominatedForeignTraineeBySchoolFromSpRequest : IRequest<object>
    {        
        public DateTime? CurrentDate { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? OfficerTypeId { get; set; }
    }
}
