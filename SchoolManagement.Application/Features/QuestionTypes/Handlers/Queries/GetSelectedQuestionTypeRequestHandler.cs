using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.QuestionTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.QuestionTypes.Handlers.Queries
{
    public class GetSelectedQuestionTypeRequestHandler : IRequestHandler<GetSelectedQuestionTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<QuestionType> _QuestionTypeRepository;


        public GetSelectedQuestionTypeRequestHandler(ISchoolManagementRepository<QuestionType> QuestionTypeRepository)
        {
            _QuestionTypeRepository = QuestionTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedQuestionTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<QuestionType> codeValues = await _QuestionTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Question,
                Value = x.QuestionTypeId
            }).ToList();
            return selectModels;
        }
    }
}
