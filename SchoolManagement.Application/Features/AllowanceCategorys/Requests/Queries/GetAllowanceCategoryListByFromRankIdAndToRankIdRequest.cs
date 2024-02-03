using MediatR;
using SchoolManagement.Application.DTOs.AllowanceCategory;

namespace SchoolManagement.Application.Features.AllowanceCategorys.Requests.Queries
{
    public class GetAllowanceCategoryListByFromRankIdAndToRankIdRequest : IRequest<List<AllowanceCategoryDto>>
    {
        public int FromRankId { get; set; }
        public int ToRankId { get; set; } 
    }
}

