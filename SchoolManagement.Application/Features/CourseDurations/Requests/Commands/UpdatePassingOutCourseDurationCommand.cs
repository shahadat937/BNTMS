using MediatR;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Commands
{
    public class UpdatePassingOutCourseDurationCommand : IRequest<Unit>
    {
        public int CoureseTypeId { get; set; }
    }
}
