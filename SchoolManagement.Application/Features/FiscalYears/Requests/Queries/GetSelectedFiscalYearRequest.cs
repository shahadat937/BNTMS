using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FiscalYears.Requests.Queries
{
    public class GetSelectedFiscalYearRequest : IRequest<List<SelectedModel>>
    {
    }
} 
