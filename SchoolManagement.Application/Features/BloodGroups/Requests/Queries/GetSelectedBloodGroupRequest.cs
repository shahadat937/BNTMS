using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BloodGroups.Requests.Queries
{
    public class GetSelectedBloodGroupRequest : IRequest<List<SelectedModel>>
    {
    }
} 
      