using SchoolManagement.Application.DTOs.TdecQuationGroup;
using MediatR;

namespace SchoolManagement.Application.Features.TdecQuationGroups.Requests.Queries
{
    public class GetTdecQuationGroupByParamsRequest : IRequest<List<TdecQuationGroupDto>>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
        public int CourseDurationId { get; set; }
        public int BnaSubjectNameId { get; set; }
    }
}
