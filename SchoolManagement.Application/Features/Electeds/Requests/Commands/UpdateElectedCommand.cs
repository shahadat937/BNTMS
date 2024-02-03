using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.Height;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Electeds;

namespace SchoolManagement.Application.Features.Electeds.Requests.Commands
{
    public class UpdateElectedCommand : IRequest<Unit>  
    { 
        public ElectedDto ElectedDto { get; set; }     
    }
}
