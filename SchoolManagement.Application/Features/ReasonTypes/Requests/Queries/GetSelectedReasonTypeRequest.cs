using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ReasonTypeTypes.Requests.Queries
{
    public class GetSelectedReasonTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
