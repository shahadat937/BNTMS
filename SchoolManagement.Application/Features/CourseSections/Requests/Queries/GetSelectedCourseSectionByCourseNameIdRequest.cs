using MediatR;
using SchoolManagement.Application.DTOs.CourseSection;

namespace SchoolManagement.Application.Features.CourseSections.Requests.Queries
{
    public class GetSelectedCourseSectionByCourseNameIdRequest : IRequest<List<CourseSectionDto>>
    {
        public int CourseNameId { get; set; }
    }
}

