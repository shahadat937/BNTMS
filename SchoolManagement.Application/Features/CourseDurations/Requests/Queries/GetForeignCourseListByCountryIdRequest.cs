using MediatR;
using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Application.DTOs.CourseDurations;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetForeignCourseListByCountryIdRequest : IRequest<List<CourseDurationDto>>
    {
        public int CountryId { get; set; }
    }
}

 