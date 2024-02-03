using MediatR;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Queries
{
    public class GetTraineeNominationCountByCourseNameIdAndTraineeIdRequest : IRequest<int>
    { 
        public int CourseNameId { get; set; }
        public int TraineeId { get; set; } 
    }
}

 