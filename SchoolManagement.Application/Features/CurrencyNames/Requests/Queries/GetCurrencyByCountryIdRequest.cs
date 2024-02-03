using MediatR;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text; 

namespace SchoolManagement.Application.Features.CurrencyNames.Requests.Queries
{
    public class GetCurrencyByCountryIdRequest : IRequest<List<SelectedModel>>
    {
        public int CountryId { get; set; }    
    }
} 
