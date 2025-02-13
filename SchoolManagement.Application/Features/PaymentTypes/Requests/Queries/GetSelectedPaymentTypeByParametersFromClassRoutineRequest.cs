﻿using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ClassPeriods.Requests.Queries
{
    public class GetSelectedPaymentTypeByParametersFromClassRoutineRequest : IRequest<List<SelectedModel>>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; } 
    }
}

  