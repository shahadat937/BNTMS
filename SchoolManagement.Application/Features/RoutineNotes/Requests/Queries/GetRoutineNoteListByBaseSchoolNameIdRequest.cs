using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.RoutineNote;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.RoutineNotes.Requests.Queries
{
    public class GetRoutineNoteListByBaseSchoolNameIdRequest : IRequest<PagedResult<RoutineNoteDto>>
    {
        public int BaseSchoolNameId { get; set; }
        public QueryParams QueryParams { get; set; }
    }
}
 