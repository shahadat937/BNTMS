using MediatR;
using SchoolManagement.Application.DTOs.ClassRoutine;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetClassRoutineByParametersRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }  
        public int CourseNameId { get; set; }
        public int BnaSubjectNameId { get; set; }
    }
}

 