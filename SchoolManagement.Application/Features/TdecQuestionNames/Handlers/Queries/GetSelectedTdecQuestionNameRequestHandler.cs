using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TdecQuestionNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TdecQuestionNames.Handlers.Queries
{
    public class GetSelectedTdecQuestionNameRequestHandler : IRequestHandler<GetSelectedTdecQuestionNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<TdecQuestionName> _TdecQuestionNameRepository;


        public GetSelectedTdecQuestionNameRequestHandler(ISchoolManagementRepository<TdecQuestionName> TdecQuestionNameRepository)
        {
            _TdecQuestionNameRepository = TdecQuestionNameRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedTdecQuestionNameRequest request, CancellationToken cancellationToken)
        {
            ICollection<TdecQuestionName> codeValues = await _TdecQuestionNameRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.TdecQuestionNameId
            }).ToList();
            return selectModels;
        }
    }
}
