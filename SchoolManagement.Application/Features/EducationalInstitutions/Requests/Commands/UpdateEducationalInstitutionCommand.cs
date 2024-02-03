using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.Height;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.EducationalInstitutions;

namespace SchoolManagement.Application.Features.EducationalInstitutions.Requests.Commands
{
    public class UpdateEducationalInstitutionCommand : IRequest<Unit>  
    { 
        public EducationalInstitutionDto EducationalInstitutionDto { get; set; }     
    }
}
