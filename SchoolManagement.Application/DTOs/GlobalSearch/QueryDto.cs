using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.GlobalSearch
{
    public class QueryDto
    {
        public string? keyword {  get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public List<string> Filters { get; set; } = new List<string>();
    }
}
