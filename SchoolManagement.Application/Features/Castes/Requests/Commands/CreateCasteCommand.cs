using SchoolManagement.Application.DTOs.Caste;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Castes.Requests.Commands
{
    public class CreateCasteCommand : IRequest<BaseCommandResponse>
    {
        public CreateCasteDto CasteDto { get; set; }

    }
}
