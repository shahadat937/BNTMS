using MediatR;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetInterServiceCourseByParametersRequest : IRequest<List<CourseDurationDto>>
    {
        public int CourseNameId { get; set; }
        public int OrganizationNameId { get; set; }
    }
}
 