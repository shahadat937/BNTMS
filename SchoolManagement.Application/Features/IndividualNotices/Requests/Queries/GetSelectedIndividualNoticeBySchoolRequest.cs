using MediatR;
using SchoolManagement.Application.DTOs.ClassPeriod;
using SchoolManagement.Application.DTOs.IndividualNotice;

namespace SchoolManagement.Application.Features.IndividualNotices.Requests.Queries
{
    public class GetSelectedIndividualNoticeBySchoolRequest : IRequest<List<IndividualNoticeDto>>
    {
        public int BaseSchoolNameId { get; set; }
    }
}

  