using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Assessments.Requests.Queries
{
    public class GetSelectedAssessmentRequest : IRequest<List<SelectedModel>>
    {
    }
}
