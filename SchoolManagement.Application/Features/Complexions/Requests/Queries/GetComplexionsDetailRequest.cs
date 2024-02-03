using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Complexions.Requests.Queries
{
    public class GetComplexionsDetailRequest : IRequest<ComplexionDto>
    {
        public int Id { get; set; }
    }
}
