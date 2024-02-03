using MediatR;
using SchoolManagement.Application.DTOs.IndividualNotice;
using SchoolManagement.Application.DTOs.IndividualNotices;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.IndividualNotices.Requests.Commands
{
    public class CreateIndividualNoticeCommand : IRequest<BaseCommandResponse>
    {
        public CreateIndividualNoticeListDto IndividualNoticeDto { get; set; }
    }
}
 