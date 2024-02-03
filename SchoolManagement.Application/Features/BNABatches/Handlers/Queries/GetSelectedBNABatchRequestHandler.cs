using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaSemesters.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaBatches.Handlers.Queries
{ 
    public class GetSelectedBnaBatchRequestHandler : IRequestHandler<GetSelectedBnaBatchRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BnaBatch> _BnaBatchRepository;


        public GetSelectedBnaBatchRequestHandler(ISchoolManagementRepository<BnaBatch> BnaBatchRepository)
        {
            _BnaBatchRepository = BnaBatchRepository;
        }
         
        public async Task<List<SelectedModel>> Handle(GetSelectedBnaBatchRequest request, CancellationToken cancellationToken)
        {
            ICollection<BnaBatch> bnaBatchs = await _BnaBatchRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = bnaBatchs.Select(x => new SelectedModel 
            {
                Text = x.BatchName,
                Value = x.BnaBatchId
            }).ToList();
            return selectModels;
        }
    }
}
