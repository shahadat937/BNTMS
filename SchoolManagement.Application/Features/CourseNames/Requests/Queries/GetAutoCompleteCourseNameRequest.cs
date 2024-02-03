using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries
{
    public class GetAutoCompleteCourseNameRequest : IRequest<List<SelectedModel>>
    {
        public string CourseName { get; set; }
    }
}
 