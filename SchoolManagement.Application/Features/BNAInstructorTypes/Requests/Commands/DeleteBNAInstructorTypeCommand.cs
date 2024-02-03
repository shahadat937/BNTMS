using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaInstructorTypes.Requests.Commands
{
    public class DeleteBnaInstructorTypeCommand : IRequest
    {
        public int BnaInstructorTypeId { get; set; }
    }
}
