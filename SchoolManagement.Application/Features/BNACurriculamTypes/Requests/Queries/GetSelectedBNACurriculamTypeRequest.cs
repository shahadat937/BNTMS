using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CurriculamTypes.Requests.Queries
{
    public class GetSelectedBnaCurriculamTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}  
  