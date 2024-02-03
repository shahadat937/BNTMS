using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ReasonTypeTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ReasonTypes.Handlers.Queries
{
    public class GetSelectedReasonTypeRequestHandler : IRequestHandler<GetSelectedReasonTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ReasonType> _ReasonTypeRepository;


        public GetSelectedReasonTypeRequestHandler(ISchoolManagementRepository<ReasonType> ReasonTypeRepository)
        {
            _ReasonTypeRepository = ReasonTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedReasonTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<ReasonType> reasonTypes = await _ReasonTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = reasonTypes.Select(x => new SelectedModel
            {
                Text = x.ReasonTypeName, 
                Value = x.ReasonTypeId
            }).ToList();
            return selectModels;
        }
    }
}
