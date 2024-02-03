
using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries
{
    public class GetSelectedSubjectByBnaSemesterIdRequest : IRequest<List<SelectedModel>>
    {
        public int BnaSemesterId { get; set; }
        public int BnaSubjectCurriculumId { get; set; }
    }
}

