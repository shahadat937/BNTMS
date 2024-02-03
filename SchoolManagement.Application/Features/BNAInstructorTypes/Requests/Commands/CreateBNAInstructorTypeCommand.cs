using SchoolManagement.Application.DTOs.BnaInstructorType;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaInstructorTypes.Requests.Commands
{
    public class CreateBnaInstructorTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateBnaInstructorTypeDto BnaInstructorTypeDto { get; set; }

    }
}
