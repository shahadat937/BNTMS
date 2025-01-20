using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetIsAllPassingOutCourseCompleteRequest : IRequest<bool>
    {
        public int CourseTypeId { get; set; }
    }
}
