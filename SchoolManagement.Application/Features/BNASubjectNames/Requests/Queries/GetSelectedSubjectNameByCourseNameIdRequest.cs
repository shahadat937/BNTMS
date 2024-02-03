using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries
{
    public class GetSelectedSubjectNameByCourseNameIdRequest : IRequest<List<SelectedModel>>
    {
        public int CourseNameId { get; set; }
    }
}

