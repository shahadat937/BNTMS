using MediatR;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries
{
    public class GetJstiTraineeBasicInfoDetailsSpRequest : IRequest<object>
    {
        //public QueryParams QueryParams { get; set; }
        public int TraineeId { get; set; }
        
    }
}
