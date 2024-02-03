using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamTypes.Requests.Queries
{
    public class GetSelectedExamTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
