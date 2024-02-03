using SchoolManagement.Application.DTOs.BnaServiceType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaServiceTypes.Requests.Commands
{
    public class UpdateBnaServiceTypeCommand : IRequest<Unit>
    {
        public BnaServiceTypeDto BnaServiceTypeDto { get; set; }

    }
}
 