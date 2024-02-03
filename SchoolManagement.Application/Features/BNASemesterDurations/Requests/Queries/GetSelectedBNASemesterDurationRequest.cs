using MediatR;
using SchoolManagement.Shared.Models;
using System;

using System.Collections.Generic; 
using System.Text;

namespace SchoolManagement.Application.Features.BnaSemesterDurations.Requests.Queries  
{
    public class GetSelectedBnaSemesterDurationRequest : IRequest<List<SelectedModel>> 
    {
    }
}
  

