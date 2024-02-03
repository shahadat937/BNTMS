using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TdecGroupResults.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.TdecGroupResults.Handlers.Queries
{
    public class GetSelectedTdecGroupResultRequestHandler : IRequestHandler<GetSelectedTdecGroupResultRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<TdecGroupResult> _TdecGroupResultRepository;


        public GetSelectedTdecGroupResultRequestHandler(ISchoolManagementRepository<TdecGroupResult> TdecGroupResultRepository)
        {
            _TdecGroupResultRepository = TdecGroupResultRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedTdecGroupResultRequest request, CancellationToken cancellationToken)
        {
            ICollection<TdecGroupResult> codeValues = await _TdecGroupResultRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.CourseNameId,
                Value = x.TdecGroupResultId
            }).ToList();
            return selectModels;
        }
    }
}
