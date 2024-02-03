using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Castes.Requests.Commands
{
    public class DeleteCasteCommand : IRequest
    {
        public int CasteId { get; set; }
    }
}
