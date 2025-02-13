﻿using MediatR;

namespace SchoolManagement.Application.Features.Attendances.Requests.Queries
{
    public class GetTraineeAttendanceListForSchoolIdSpRequest : IRequest<object>
    {
        public DateTime? CurrentDate { get; set; }
        public int? BaseSchoolNameId { get; set; }
    }
}
