using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaSubjectCurriculums.Requests.Queries
{
    public class GetSelectedBnaSubjectCurriculumRequest : IRequest<List<SelectedModel>>
    {
    }
}
   