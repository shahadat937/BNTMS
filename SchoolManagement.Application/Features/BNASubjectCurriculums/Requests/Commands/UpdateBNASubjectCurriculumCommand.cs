using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectCurriculum;
using SchoolManagement.Application.DTOs.BnaSubjectCurriculums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaSubjectCurriculums.Requests.Commands
{
    public class UpdateBnaSubjectCurriculumCommand : IRequest<Unit>
    {
        public BnaSubjectCurriculumDto BnaSubjectCurriculumDto { get; set; }
    }
}
  