using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.GlobalSearch
{
    public class QueryResultDto
    {
        public string Query {  get; set; }
        public int ResponseCount { get; set; }
        public List<string> filters { get; set; }
        public List<object> Results { get; set; } = new List<object>();
    }
}
