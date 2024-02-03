using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaSemesterDurations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaSemesterDurations.Handlers.Queries

{ 
    
    public class GetSelectedBnaSemesterDurationRequestHandler : IRequestHandler<GetSelectedBnaSemesterDurationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BnaSemesterDuration> _BnaSemesterDurationRepository;


        public GetSelectedBnaSemesterDurationRequestHandler(ISchoolManagementRepository<BnaSemesterDuration> BnaSemesterDurationRepository)
        {
            _BnaSemesterDurationRepository = BnaSemesterDurationRepository;

        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBnaSemesterDurationRequest request, CancellationToken cancellationToken)
        {

            ICollection<BnaSemesterDuration> BnaSemesterDurations = await _BnaSemesterDurationRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = BnaSemesterDurations.Select(x => new SelectedModel 
            {
                Text = x.StartDate,
                Value = x.BnaSemesterDurationId
            }).ToList();
            return selectModels;
        }
    }
}
