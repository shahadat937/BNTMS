using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaSubjectCurriculums.Requests.Commands
{
    public class DeleteBnaSubjectCurriculumCommand : IRequest
    {
        public int BnaSubjectCurriculumId { get; set; }
    }
}
  