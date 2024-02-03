using MediatR;
using SchoolManagement.Application.DTOs.District;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Districts.Requests.Queries
{
    public class GetSelectedDistrictByDivisionRequest : IRequest<List<SelectedModel>>
    {
        public int DivisionId { get; set; } 
    }
}
