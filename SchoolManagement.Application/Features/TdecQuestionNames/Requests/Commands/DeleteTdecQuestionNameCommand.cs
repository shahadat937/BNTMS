using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TdecQuestionNames.Requests.Commands
{
    public class DeleteTdecQuestionNameCommand : IRequest
    {
        public int TdecQuestionNameId { get; set; }
    }
}
