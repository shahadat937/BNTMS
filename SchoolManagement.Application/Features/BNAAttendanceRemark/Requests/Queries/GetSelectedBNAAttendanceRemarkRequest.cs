using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.BnaAttendanceRemark.Requests.Queries
{
    public class GetSelectedBnaAttendanceRemarkRequest : IRequest<List<SelectedModel>>
    {
    }
} 
 