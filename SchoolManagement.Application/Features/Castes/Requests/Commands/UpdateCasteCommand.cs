using SchoolManagement.Application.DTOs.Caste;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Castes.Requests.Commands
{
    public class UpdateCasteCommand : IRequest<Unit>
    {
        public CasteDto CasteDto { get; set; }

    }
}
