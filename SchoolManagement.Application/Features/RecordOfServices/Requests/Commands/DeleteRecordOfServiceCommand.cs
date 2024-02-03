using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.RecordOfServices.Requests.Commands
{
    public class DeleteRecordOfServiceCommand : IRequest  
    {  
        public int Id { get; set; }
    }
}
