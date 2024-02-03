using SchoolManagement.Application.Responses;
using MediatR;
using SchoolManagement.Application.DTOs.BnaExamMark;

namespace SchoolManagement.Application.Features.BnaExamMarks.Requests.Commands
{
    public class CreateBnaExamMarkListCommand : IRequest<BaseCommandResponse>
    {
         public BnaExamMarkListDto BnaExamMarkListDto { get; set; }
    }
} 
 