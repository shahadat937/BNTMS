using MediatR;
using SchoolManagement.Application.DTOs.UniversityCourseResult;

namespace SchoolManagement.Application.Features.UniversityCourseResults.Requests.Queries
{
    public class GetUniversityCourseResultByTraineeIdRequest : IRequest<UniversityCourseResultDto>
    {
        public int TraineeId { get; set; }
    }
}
