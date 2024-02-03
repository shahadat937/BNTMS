using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectCurriculum;
using SchoolManagement.Application.DTOs.BnaSubjectCurriculums;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaSubjectCurriculums.Requests.Queries
{
   public class GetBnaSubjectCurriculumListRequest : IRequest<PagedResult<BnaSubjectCurriculumDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
 