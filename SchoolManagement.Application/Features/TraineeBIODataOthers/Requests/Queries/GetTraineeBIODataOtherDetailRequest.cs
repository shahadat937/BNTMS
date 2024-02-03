using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.TraineeBioDataOther;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeBioDataOthers.Requests.Queries
{
    public class GetTraineeBioDataOtherDetailRequest : IRequest<TraineeBioDataOtherDto>
    {
        public int TraineeBioDataOtherId { get; set; }
    }
}
