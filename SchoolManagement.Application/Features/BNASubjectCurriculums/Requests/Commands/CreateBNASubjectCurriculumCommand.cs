using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectCurriculum;
using SchoolManagement.Application.DTOs.BnaSubjectCurriculums;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaSubjectCurriculums.Requests.Commands
{
    public class CreateBnaSubjectCurriculumCommand : IRequest<BaseCommandResponse>
    {
        public CreateBnaSubjectCurriculumDto BnaSubjectCurriculumDto { get; set; }
    }
}
 