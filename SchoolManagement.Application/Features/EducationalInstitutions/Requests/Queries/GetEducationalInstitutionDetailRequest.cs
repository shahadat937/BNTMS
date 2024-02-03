using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.EducationalInstitutions;
using SchoolManagement.Application.DTOs.Height;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.Features.EducationalInstitutions.Requests.Queries
{
    public class GetEducationalInstitutionDetailRequest : IRequest<EducationalInstitutionDto> 
    {
        public int EducationalInstitutionId { get; set; } 
    }
}
