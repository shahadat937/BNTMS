using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamPeriodTypes.Requests.Queries
{
    public class GetSelectedExamPeriodTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
