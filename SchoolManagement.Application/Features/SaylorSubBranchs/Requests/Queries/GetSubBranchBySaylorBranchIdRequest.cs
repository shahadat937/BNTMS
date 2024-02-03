using MediatR;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text; 

namespace SchoolManagement.Application.Features.SaylorSubBranchs.Requests.Queries
{
    public class GetSubBranchBySaylorBranchIdRequest : IRequest<List<SelectedModel>>
    {
        public int SaylorBranchId { get; set; }    
    }
} 
