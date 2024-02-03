using MediatR;
using SchoolManagement.Application.DTOs.TdecQuestionName;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TdecQuestionNames.Requests.Commands
{
    public class UpdateTdecQuestionNameCommand : IRequest<Unit>
    {
        public TdecQuestionNameDto TdecQuestionNameDto { get; set; }
    }
}
