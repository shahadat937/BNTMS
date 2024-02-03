using MediatR;
using SchoolManagement.Application.DTOs.DefenseType;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DefenseTypes.Requests.Commands
{
    public class CreateDefenseTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateDefenseTypeDto DefenseTypeDto { get; set; }
    }
}
