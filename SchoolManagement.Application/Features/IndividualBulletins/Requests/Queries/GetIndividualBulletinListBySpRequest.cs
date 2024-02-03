using MediatR;

namespace SchoolManagement.Application.Features.IndividualBulletins.Requests.Queries
{
    public class GetIndividualBulletinListBySpRequest : IRequest<object>
    {
        public int? BaseSchoolNameId { get; set; }
        public int? TraineeId { get; set; }
    }
}
