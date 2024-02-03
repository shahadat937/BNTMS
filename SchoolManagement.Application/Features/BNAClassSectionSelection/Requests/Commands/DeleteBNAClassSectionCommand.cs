using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaClassSections.Requests.Commands
{
    public class DeleteBnaClassSectionCommand : IRequest
    {
        public int Id { get; set; }
    }
}
 