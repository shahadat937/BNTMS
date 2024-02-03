using SchoolManagement.Application.DTOs.ClassRoutine;
using MediatR;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetCentralExamRoutineListByParamsRequest : IRequest<List<ClassRoutineDto>>
    {
        public int? CourseDurationId { get; set; }
    }
}
