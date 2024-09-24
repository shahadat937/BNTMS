using MediatR;
using SchoolManagement.Application.DTOs.GlobalSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GlobalSearch.Requests.Queries
{
    public class SearchQueryRequest : IRequest<object>
    {
        public QueryDto Query { get; set; }
    }
}
