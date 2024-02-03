using SchoolManagement.Application.DTOs.BnaInstructorType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaInstructorTypes.Requests.Commands
{
    public class UpdateBnaInstructorTypeCommand : IRequest<Unit>
    {
        public BnaInstructorTypeDto BnaInstructorTypeDto { get; set; }

    }
}
 