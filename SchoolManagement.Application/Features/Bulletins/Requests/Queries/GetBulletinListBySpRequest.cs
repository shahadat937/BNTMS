using MediatR;

namespace SchoolManagement.Application.Features.Bulletins.Requests.Queries
{
    public class GetBulletinListBySpRequest : IRequest<object>
    {
        public int? BaseSchoolNameId { get; set; }
    }
}
