using MediatR;
using SchoolManagement.Application.DTOs.CourseWeeks;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CourseWeeks.Requests.Queries
{
    public class GetAutoCourseWeekCountForBnaRequest : IRequest<object>
    {
        public int BnaSemesterDurationId { get; set; }
    }
}
