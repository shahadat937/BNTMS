using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetCourseReportByDateRangeRequest : IRequest<object>
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
