using MediatR;
using SchoolManagement.Application.DTOs.EmploymentBeforeJoinBna;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.EmploymentBeforeJoinBnas.Requests.Queries
{
    public class GetEmploymentBeforeJoinBnaListByTraineeRequest : IRequest<List<EmploymentBeforeJoinBnaDto>>
    {
        public int Traineeid { get; set; }
    }
    
}
