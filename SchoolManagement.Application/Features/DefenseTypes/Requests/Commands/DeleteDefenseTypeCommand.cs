using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DefenseTypes.Requests.Commands
{
    public class DeleteDefenseTypeCommand : IRequest
    {
        public int DefenseTypeId { get; set; }
    }
}
