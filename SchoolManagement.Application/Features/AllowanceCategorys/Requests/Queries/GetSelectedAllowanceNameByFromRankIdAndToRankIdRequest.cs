using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.AllowanceCategorys.Requests.Queries
{
    public class GetSelectedAllowanceNameByFromRankIdAndToRankIdRequest : IRequest<List<SelectedModel>>
    {
        public int FromRankId { get; set; }
        public int ToRankId { get; set; }
    }
}

