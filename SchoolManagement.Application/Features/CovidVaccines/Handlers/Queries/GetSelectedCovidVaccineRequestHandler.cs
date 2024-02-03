using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CovidVaccines.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CovidVaccines.Handlers.Queries
{
    public class GetSelectedCovidVaccineRequestHandler : IRequestHandler<GetSelectedCovidVaccineRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CovidVaccine> _CovidVaccineRepository;


        public GetSelectedCovidVaccineRequestHandler(ISchoolManagementRepository<CovidVaccine> CovidVaccineRepository)
        {
            _CovidVaccineRepository = CovidVaccineRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCovidVaccineRequest request, CancellationToken cancellationToken)
        {
            ICollection<CovidVaccine> codeValues = await _CovidVaccineRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.CovidVaccineId,
                Value = x.CovidVaccineId
            }).ToList();
            return selectModels;
        }
    }
}
