using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Complexions.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Complexions.Handlers.Queries
{ 
    public class GetSelectedComplexionRequestHandler : IRequestHandler<GetSelectedComplexionRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Complexion> _ComplexionRepository;


        public GetSelectedComplexionRequestHandler(ISchoolManagementRepository<Complexion> ComplexionRepository)
        {
            _ComplexionRepository = ComplexionRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedComplexionRequest request, CancellationToken cancellationToken)
        {
            ICollection<Complexion> Complexions = await _ComplexionRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = Complexions.Select(x => new SelectedModel 
            {
                Text = x.ComplexionName,
                Value = x.ComplexionId
            }).ToList();
            return selectModels;
        }
    }
}
