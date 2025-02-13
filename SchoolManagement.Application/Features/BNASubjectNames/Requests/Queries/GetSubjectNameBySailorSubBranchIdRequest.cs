﻿using MediatR;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text; 

namespace SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries
{
    public class GetSubjectNameByBranchIdRequest : IRequest<List<SelectedModel>>
    {
        public int BranchId { get; set; }    
    }
} 
