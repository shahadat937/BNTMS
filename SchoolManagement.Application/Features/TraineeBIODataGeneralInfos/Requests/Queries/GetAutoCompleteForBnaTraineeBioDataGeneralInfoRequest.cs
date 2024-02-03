using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries
{
    public class GetAutoCompleteForBnaTraineeBioDataGeneralInfoRequest : IRequest<List<SelectedModel>>
    {
        public string PNo { get; set; }
        public int BnaSemesterDurationId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
    }
}
 