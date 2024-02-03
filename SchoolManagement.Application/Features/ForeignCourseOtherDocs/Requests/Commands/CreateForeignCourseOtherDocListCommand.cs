using SchoolManagement.Application.Responses;
using MediatR;
using SchoolManagement.Application.DTOs.ForeignCourseOtherDoc;

namespace SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Commands
{
    public class CreateForeignCourseOtherDocListCommand : IRequest<BaseCommandResponse>
    {
         public ForeignCourseOtherDocListDto ForeignCourseOtherDocListDto { get; set; }
    }
} 
  