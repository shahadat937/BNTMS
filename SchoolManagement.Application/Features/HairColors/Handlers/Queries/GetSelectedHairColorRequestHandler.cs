using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.HairColors.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.HairColors.Handlers.Queries
{
    public class GetSelectedHairColorRequestHandler : IRequestHandler<GetSelectedHairColorRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<HairColor> _HairColorRepository;


        public GetSelectedHairColorRequestHandler(ISchoolManagementRepository<HairColor> HairColorRepository)
        {
            _HairColorRepository = HairColorRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedHairColorRequest request, CancellationToken cancellationToken)
        {
            ICollection<HairColor> codeValues = await _HairColorRepository.FilterAsync(x => x.IsActive && x.HairColorId != 1006);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.HairColorName,
                Value = x.HairColorId
            }).ToList();
            return selectModels;
        }
    }
}
