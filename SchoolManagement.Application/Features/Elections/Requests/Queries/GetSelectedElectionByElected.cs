using MediatR;
using SchoolManagement.Application.DTOs.Election;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Elections.Requests.Queries
{
    public class GetSelectedElectionByElected : IRequest<List<SelectedModel>>
    {
        public string Elected { get; set; } 
    }
}
