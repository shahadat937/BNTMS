using MediatR;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text; 

namespace SchoolManagement.Application.Features.Countrys.Requests.Queries
{
    public class GetCountryByCountryGroupIdRequest : IRequest<List<SelectedModel>>
    {
        public int CountryGroupId { get; set; }    
    }
} 
