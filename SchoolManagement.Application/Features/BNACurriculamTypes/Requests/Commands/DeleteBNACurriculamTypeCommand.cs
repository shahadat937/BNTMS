using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaCurriculamTypes.Requests.Commands
{
    public class DeleteBnaCurriculamTypeCommand : IRequest
    {
        public int BnaCurriculamTypeId { get; set; }
    }
}
 