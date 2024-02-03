using MediatR;
using SchoolManagement.Application.DTOs.ClassPeriod;
using SchoolManagement.Application.DTOs.IndividualBulletin;

namespace SchoolManagement.Application.Features.IndividualBulletins.Requests.Queries
{
    public class GetIndividualBulletinByDurationRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
        public int CourseDurationId { get; set; }
    }
}

  