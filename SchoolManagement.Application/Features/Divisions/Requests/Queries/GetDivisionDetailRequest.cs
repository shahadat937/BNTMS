using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.Division;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Divisions.Requests.Queries
{
    public class GetDivisionDetailRequest : IRequest<DivisionDto>
    {
        public int DivisionId { get; set; }
    }
}
