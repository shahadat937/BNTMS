using MediatR;
using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Application.DTOs.CourseDurations;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetInterServiceCourseListByCourseNameIdAndOrganizationNameIdRequest : IRequest<List<CourseDurationDto>>
    {
        public int CourseTypeId { get; set; }
        public int CourseNameId { get; set; }
        public int OrganizationNameId { get; set; }
    }
}

 