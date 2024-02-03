using SchoolManagement.Application.DTOs.EmploymentBeforeJoinBna;
using MediatR;

namespace SchoolManagement.Application.Features.EmploymentBeforeJoinBnas.Requests.Queries
{
    public class GetEmploymentBeforeJoinBnaDetailRequest : IRequest<EmploymentBeforeJoinBnaDto>
    {
        public int EmploymentBeforeJoinBnaId { get; set; }
    }
}
