using MediatR;
using SchoolManagement.Application.DTOs.DefenseType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DefenseTypes.Requests.Commands
{
    public class UpdateDefenseTypeCommand : IRequest<Unit>
    {
        public DefenseTypeDto DefenseTypeDto { get; set; }
    }
}
