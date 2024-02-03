using MediatR;
using SchoolManagement.Application.DTOs.TdecQuestionName;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TdecQuestionNames.Requests.Queries
{
    public class GetTdecQuestionNameDetailRequest : IRequest<TdecQuestionNameDto>
    {
        public int TdecQuestionNameId { get; set; }
    }
}
