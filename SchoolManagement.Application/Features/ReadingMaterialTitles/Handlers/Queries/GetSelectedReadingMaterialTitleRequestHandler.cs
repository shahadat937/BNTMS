using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ReadingMaterialTitles.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ReadingMaterialTitles.Handlers.Queries
{
    public class GetSelectedReadingMaterialTitleRequestHandler : IRequestHandler<GetSelectedReadingMaterialTitleRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ReadingMaterialTitle> _ReadingMaterialTitleRepository;


        public GetSelectedReadingMaterialTitleRequestHandler(ISchoolManagementRepository<ReadingMaterialTitle> ReadingMaterialTitleRepository)
        {
            _ReadingMaterialTitleRepository = ReadingMaterialTitleRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedReadingMaterialTitleRequest request, CancellationToken cancellationToken)
        {
            ICollection<ReadingMaterialTitle> codeValues = await _ReadingMaterialTitleRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Title,
                Value = x.ReadingMaterialTitleId
            }).ToList();
            return selectModels;
        }
    }
}
