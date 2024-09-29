using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GlobalSearch.Requests.Queries
{
    public class GetSearchedCourseDetailRequest: IRequest<object>
    {
        public int CourseDurationId { get; set; }
    }
}
