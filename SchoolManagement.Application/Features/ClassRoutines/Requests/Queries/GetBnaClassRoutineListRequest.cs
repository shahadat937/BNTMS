using MediatR;
using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetBnaClassRoutineListRequest : IRequest<PagedResult<ClassRoutineDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int BaseSchoolNameId { get; set; }
        public int BnaSemesterId { get; set; }
        public int WeekID { get; set; }
    }
}
