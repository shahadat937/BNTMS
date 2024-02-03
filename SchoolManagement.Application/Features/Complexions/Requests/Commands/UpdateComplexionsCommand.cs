using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Complexions.Requests.Commands
{
    public class UpdateComplexionsCommand : IRequest<Unit> 
    {
        public ComplexionDto ComplexionDto { get; set; }  
    }
}
