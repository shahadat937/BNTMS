using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.AllowanceCategorys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.AllowanceCategorys.Handlers.Queries
{
    public class GetSelectedAllowanceNameByFromRankIdAndToRankIdRequestHandler : IRequestHandler<GetSelectedAllowanceNameByFromRankIdAndToRankIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<AllowanceCategory> _AllowanceCategoryRepository;


        public GetSelectedAllowanceNameByFromRankIdAndToRankIdRequestHandler(ISchoolManagementRepository<AllowanceCategory> AllowanceCategoryRepository)
        {
            _AllowanceCategoryRepository = AllowanceCategoryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedAllowanceNameByFromRankIdAndToRankIdRequest request, CancellationToken cancellationToken)
        {

            //ICollection<AllowanceCategory> allowanceCategorys = _AllowanceCategoryRepository.Where(x=>x.FromRankId == request.FromRankId && x.ToRankId == request.ToRankId).ToList();
            IQueryable<AllowanceCategory> AllowanceCategorys = _AllowanceCategoryRepository.FilterWithInclude(x => x.FromRankId == request.FromRankId && x.ToRankId == request.ToRankId, "FromRank", "ToRank");
            //IQueryable<AllowanceCategory> AllowanceCategorys = _AllowanceCategoryRepository.FilterWithInclude(x => x.FromRankId, "AllowancePercentage");
            List<SelectedModel> selectModels = AllowanceCategorys.Select(x => new SelectedModel
            {
                Text = x.AllowancePercentage.AllowanceName,
                Value = x.AllowanceCategoryId 
            }).ToList();
            return selectModels;
        }
    }
}
