using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GlobalSearch.Requests.Queries
{
    public class SearchQueryRequest : IRequest<object>
    {
        public string Query { get; set; }
        public int? PageSize {  get; set; }
        public int? PageIndex { get; set; }
    }
}
