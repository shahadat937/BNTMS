using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetSelectedMarkTypeFromClassRoutineRequest : IRequest<List<SelectedModel>>
    {
        public int ClassRoutineId { get; set; }
    }
}
 