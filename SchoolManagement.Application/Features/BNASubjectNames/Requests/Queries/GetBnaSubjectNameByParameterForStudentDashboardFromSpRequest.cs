using MediatR;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries
{
    public class GetBnaSubjectNameByParameterForStudentDashboardFromSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
        public int CourseModuleId { get; set; }
    }
}
 