using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamAttemptTypes.Requests.Queries
{
    public class GetSelectedExamAttemptTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}  
  