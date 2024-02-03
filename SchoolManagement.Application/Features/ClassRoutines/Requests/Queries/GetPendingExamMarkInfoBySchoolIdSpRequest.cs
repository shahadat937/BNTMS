using MediatR;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetPendingExamMarkInfoBySchoolIdSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
    }
}
