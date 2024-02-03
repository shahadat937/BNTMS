using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectCurriculum;
using SchoolManagement.Application.DTOs.BnaSubjectCurriculums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaSubjectCurriculums.Requests.Queries
{
    public class GetBnaSubjectCurriculumDetailRequest : IRequest<BnaSubjectCurriculumDto>
    {
        public int BnaSubjectCurriculumId { get; set; }
    }
}
 