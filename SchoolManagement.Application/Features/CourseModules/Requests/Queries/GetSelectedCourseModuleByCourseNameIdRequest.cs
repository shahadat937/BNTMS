using MediatR;
using SchoolManagement.Application.DTOs.CourseModule;

namespace SchoolManagement.Application.Features.CourseModules.Requests.Queries
{
    public class GetSelectedCourseModuleByCourseNameIdRequest : IRequest<List<CourseModuleDto>>
    {
        public int CourseNameId { get; set; }
    }
}

