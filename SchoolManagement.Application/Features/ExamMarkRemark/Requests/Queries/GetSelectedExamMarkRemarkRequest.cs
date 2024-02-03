using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamMarkRemark.Requests.Queries
{
    public class GetSelectedExamMarkRemarkRequest : IRequest<List<SelectedModel>>
    {
    }
}
