using MediatR;
using SchoolManagement.Application.DTOs.KindOfSubjects;

namespace SchoolManagement.Application.Features.KindOfSubjects.Requests.Commands
{
    public class UpdateKindOfSubjectCommand : IRequest<Unit> 
    { 
        public KindOfSubjectDto KindOfSubjectDto { get; set; }   
    }
}
