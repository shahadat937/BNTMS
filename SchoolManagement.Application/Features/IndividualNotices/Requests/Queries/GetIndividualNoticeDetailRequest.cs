using MediatR;
using SchoolManagement.Application.DTOs.IndividualNotice;

namespace SchoolManagement.Application.Features.IndividualNotices.Requests.Queries
{
    public class GetIndividualNoticeDetailRequest : IRequest<IndividualNoticeDto>
    {
        public int IndividualNoticeId { get; set; }
    }
}
 