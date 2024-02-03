using SchoolManagement.Application.Responses;
using MediatR;
using SchoolManagement.Application.DTOs.BnaExamMark;

namespace SchoolManagement.Application.Features.BnaExamMarks.Requests.Commands
{
    public class ApproveBnaExamMarkListCommand : IRequest<BaseCommandResponse>
    {
         public ApproveBnaExamMarkListDto ApproveBnaExamMarkListDto { get; set; }
    }
} 
 