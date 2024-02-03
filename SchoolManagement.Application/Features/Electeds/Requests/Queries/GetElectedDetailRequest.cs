using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.Electeds;
using SchoolManagement.Application.DTOs.Height;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.Features.Electeds.Requests.Queries
{
    public class GetElectedDetailRequest : IRequest<ElectedDto> 
    {
        public int Id { get; set; } 
    }
}
