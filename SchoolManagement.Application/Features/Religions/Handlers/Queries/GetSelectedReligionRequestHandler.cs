using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Religions.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Religions.Handlers.Queries
{
    public class GetSelectedReligionRequestHandler : IRequestHandler<GetSelectedReligionRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Religion> _ReligionRepository;


        public GetSelectedReligionRequestHandler(ISchoolManagementRepository<Religion> ReligionRepository)
        {
            _ReligionRepository = ReligionRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedReligionRequest request, CancellationToken cancellationToken)
        {
            ICollection<Religion> codeValues = await _ReligionRepository.FilterAsync(x => x.IsActive && x.ReligionId != 12);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ReligionName,
                Value = x.ReligionId
            }).ToList();
            return selectModels;
        }
    }
}
