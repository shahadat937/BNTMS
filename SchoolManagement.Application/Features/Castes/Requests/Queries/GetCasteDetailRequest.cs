using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.Caste;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Castes.Requests.Queries
{
    public class GetCasteDetailRequest : IRequest<CasteDto>
    {
        public int CasteId { get; set; }
    }
}
