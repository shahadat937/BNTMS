using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.EducationalInstitutions;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Models;
using System; 
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.EducationalInstitutions.Requests.Queries 
{ 
    public class GetEducationalInstitutionListRequest : IRequest<PagedResult<EducationalInstitutionDto>>
    { 
        public QueryParams QueryParams { get; set; }  
    }
}
