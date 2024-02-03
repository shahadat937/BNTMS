using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaClassSectionSelections.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassSectionSelections.Handlers.Queries
{
    public class GetSelectedBnaClassSectionSelectionRequestHandler : IRequestHandler<GetSelectedBnaClassSectionSelectionRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BnaClassSectionSelection> _BnaClassSectionSelectionRepository;


        public GetSelectedBnaClassSectionSelectionRequestHandler(ISchoolManagementRepository<BnaClassSectionSelection> BnaClassSectionSelectionRepository)
        {
            _BnaClassSectionSelectionRepository = BnaClassSectionSelectionRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBnaClassSectionSelectionRequest request, CancellationToken cancellationToken)
        {
            ICollection<BnaClassSectionSelection> codeValues = await _BnaClassSectionSelectionRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.SectionName,
                Value = x.BnaClassSectionSelectionId 
            }).ToList();
            return selectModels;
        }
    }
}
