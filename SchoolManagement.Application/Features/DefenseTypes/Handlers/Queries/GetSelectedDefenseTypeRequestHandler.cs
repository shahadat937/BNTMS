using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.DefenseTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.DefenseTypes.Handlers.Queries
{
    public class GetSDefenseTypeDefenseTypeRequestHandler : IRequestHandler<GetSelectedDefenseTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<DefenseType> _DefenseTypeRepository;


        public GetSDefenseTypeDefenseTypeRequestHandler(ISchoolManagementRepository<DefenseType> DefenseTypeRepository)
        {
            _DefenseTypeRepository = DefenseTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedDefenseTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<DefenseType> codeValues = await _DefenseTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.DefenseTypeName,
                Value = x.DefenseTypeId
            }).ToList();
            return selectModels;
        }
    }
}
