using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectName;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries
{
    public class GetBNASubjectNameListByBnaSemesterIdRequest : IRequest<List<BnaSubjectNameDto>>
    {  
        public int BnaSemesterId { get; set; }
    } 
}
 
 