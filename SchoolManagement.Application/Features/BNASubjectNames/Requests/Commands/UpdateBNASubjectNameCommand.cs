using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectName;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Requests.Commands
{
    public class UpdateBnaSubjectNameCommand : IRequest<Unit>   
    { 
        public BnaSubjectNameDto BnaSubjectNameDto { get; set; }     
    }
}
 