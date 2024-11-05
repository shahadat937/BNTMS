using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Instructor.Requests.Queries
{
    public class GetInstructorBySchoolRequest : IRequest<object>
    {
        public int Pno { set; get; }
        public int BaseSchoolNameId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
