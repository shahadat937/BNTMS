using MediatR;
using SchoolManagement.Application.Features.GlobalSearch.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GlobalSearch.Handlers.Queries
{
    public class GetSearchedInstructorDetailRequestHandler: IRequestHandler<GetSearchedInstructorDetailRequest,object>
    {
        public async Task<object> Handle(GetSearchedInstructorDetailRequest request, CancellationToken cancellationToken)
        {
            //TODO: Yet to implement
            return "Yet to implement";
        }
    }
}
