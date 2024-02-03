using MediatR;
using SchoolManagement.Application.DTOs.TdecQuestionName;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TdecQuestionNames.Requests.Commands
{
    public class CreateTdecQuestionNameCommand : IRequest<BaseCommandResponse>
    {
        public CreateTdecQuestionNameDto TdecQuestionNameDto { get; set; }
    }
}
