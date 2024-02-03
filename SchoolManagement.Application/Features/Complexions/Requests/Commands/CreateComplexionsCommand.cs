using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Complexions.Requests.Commands
{
    public class CreateComplexionsCommand : IRequest<BaseCommandResponse>
    {
        public CreateComplexionDto ComplexionDto { get; set; }   

    }
}
