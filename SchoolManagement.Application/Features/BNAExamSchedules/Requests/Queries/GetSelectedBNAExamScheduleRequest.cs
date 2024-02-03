using MediatR;
using SchoolManagement.Shared.Models;
using System;

using System.Collections.Generic; 
using System.Text;

namespace SchoolManagement.Application.Features.BnaExamSchedules.Requests.Queries  
{
    public class GetSelectedBnaExamScheduleRequest : IRequest<List<SelectedModel>> 
    {
    }
}
  

 

