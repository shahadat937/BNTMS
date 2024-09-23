using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.GlobalSearch
{
    public class QueryDto
    {
        public string Query {  get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
