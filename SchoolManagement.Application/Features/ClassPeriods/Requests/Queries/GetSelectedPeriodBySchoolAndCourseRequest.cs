using MediatR;
using SchoolManagement.Application.DTOs.ClassPeriod;

namespace SchoolManagement.Application.Features.ClassPeriods.Requests.Queries
{
    public class GetSelectedPeriodBySchoolAndCourseRequest : IRequest<List<ClassPeriodDto>>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
    }
}

 