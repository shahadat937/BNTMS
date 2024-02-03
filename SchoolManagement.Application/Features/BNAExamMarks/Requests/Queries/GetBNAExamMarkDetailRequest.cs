using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.BnaExamMark;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaExamMarks.Requests.Queries
{
    public class GetBnaExamMarkDetailRequest : IRequest<BnaExamMarkDto>
    {
        public int BnaExamMarkId { get; set; }
    }
}
 