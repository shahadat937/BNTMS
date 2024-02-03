using SchoolManagement.Application.DTOs.BnaServiceType;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaServiceTypes.Requests.Commands
{
    public class CreateBnaServiceTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateBnaServiceTypeDto BnaServiceTypeDto { get; set; }

    }
}
 