using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetCourseCommanceBySundayRequest : IRequest<object>
    {
        public DateTime NextSundayDate { get; set; }

    }
}
