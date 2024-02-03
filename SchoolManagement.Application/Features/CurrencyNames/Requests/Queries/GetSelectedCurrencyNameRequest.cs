using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CurrencyNames.Requests.Queries
{
    public class GetSelectedCurrencyNameRequest : IRequest<List<SelectedModel>>
    {
    }
}  
  