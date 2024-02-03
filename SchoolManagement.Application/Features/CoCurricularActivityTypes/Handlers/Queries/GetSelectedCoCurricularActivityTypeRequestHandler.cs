using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CoCurricularActivityTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CoCurricularActivityTypes.Handlers.Queries
{
    public class GetSelectedCoCurricularActivityTypeRequestHandler : IRequestHandler<GetSelectedCoCurricularActivityTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CoCurricularActivityType> _CoCurricularActivityTypeRepository;


        public GetSelectedCoCurricularActivityTypeRequestHandler(ISchoolManagementRepository<CoCurricularActivityType> CoCurricularActivityTypeRepository)
        {
            _CoCurricularActivityTypeRepository = CoCurricularActivityTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCoCurricularActivityTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<CoCurricularActivityType> codeValues = await _CoCurricularActivityTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.CoCurricularActivityName,
                Value = x.CoCurricularActivityTypeId
            }).ToList();
            return selectModels;
        }
    }
}
