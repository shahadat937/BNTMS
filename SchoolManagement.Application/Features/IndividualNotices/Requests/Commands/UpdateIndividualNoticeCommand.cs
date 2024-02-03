using MediatR;
using SchoolManagement.Application.DTOs.IndividualNotice;

namespace SchoolManagement.Application.Features.IndividualNotices.Requests.Commands
{
    public class UpdateIndividualNoticeCommand : IRequest<Unit>
    {
        public IndividualNoticeDto IndividualNoticeDto { get; set; }
    }
} 
