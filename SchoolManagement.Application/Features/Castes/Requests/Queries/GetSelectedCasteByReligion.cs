using MediatR;
using SchoolManagement.Application.DTOs.Caste;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Castes.Requests.Queries
{
    public class GetSelectedCasteByReligion : IRequest<List<SelectedModel>>
    {
        public int ReligionId { get; set; } 
    }
}
