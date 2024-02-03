using MediatR;
using SchoolManagement.Application.DTOs.InterServiceMark;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InterServiceMarks.Requests.Queries
{
    public class GetInterServiceMarkListByPnoRequest : IRequest<List<InterServiceMarkDto>>
    {
        public int TraineeId { get; set; }
    }
}

