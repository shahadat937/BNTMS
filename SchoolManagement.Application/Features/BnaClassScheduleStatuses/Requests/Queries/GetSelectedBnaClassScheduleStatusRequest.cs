using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.BnaClassScheduleStatuss.Requests.Queries
{
    public class GetSelectedBnaClassScheduleStatusRequest : IRequest<List<SelectedModel>>
    {
    }
} 
