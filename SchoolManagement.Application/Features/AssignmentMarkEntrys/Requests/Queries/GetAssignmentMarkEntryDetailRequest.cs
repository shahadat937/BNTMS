using MediatR;
using SchoolManagement.Application.DTOs.AssignmentMarkEntry;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.AssignmentMarkEntrys.Requests.Queries
{
    public class GetAssignmentMarkEntryDetailRequest : IRequest<AssignmentMarkEntryDto>
    {
        public int AssignmentMarkEntryId { get; set; }
    }
}
