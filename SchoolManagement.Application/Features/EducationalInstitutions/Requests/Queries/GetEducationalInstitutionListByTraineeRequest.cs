using SchoolManagement.Application.DTOs.EducationalInstitutions;
using MediatR;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.EducationalInstitutions.Requests.Queries
{
    public class GetEducationalInstitutionListByTraineeRequest : IRequest<List<EducationalInstitutionDto>>
    {
        public int Traineeid { get; set; }
    }
}
