using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaServiceTypes.Requests.Queries
{
    public class GetSelectedBnaServiceTypeRequest : IRequest<List<SelectedModel>>
    {
    }
} 
 