using MediatR;
using SchoolManagement.Application.DTOs.ClassPeriod;
using SchoolManagement.Application.DTOs.IndividualBulletin;

namespace SchoolManagement.Application.Features.IndividualBulletins.Requests.Queries
{
    public class GetSelectedIndividualBulletinBySchoolRequest : IRequest<List<IndividualBulletinDto>>
    {
        public int BaseSchoolNameId { get; set; }
    }
}

  