using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CovidVaccine;
using SchoolManagement.Application.Features.CovidVaccines.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CovidVaccines.Handlers.Queries
{
    public class GetCovidVaccineListByPnoRequestHandler : IRequestHandler<GetCovidVaccineListByPnoRequest, List<CovidVaccineDto>>
    {
        private readonly ISchoolManagementRepository<CovidVaccine> _CovidVaccineRepository;
        private readonly IMapper _mapper;

        public GetCovidVaccineListByPnoRequestHandler(ISchoolManagementRepository<CovidVaccine> CovidVaccineRepository, IMapper mapper)
        {
            _CovidVaccineRepository = CovidVaccineRepository;
            _mapper = mapper;
        }
         
        public async Task<List<CovidVaccineDto>> Handle(GetCovidVaccineListByPnoRequest request, CancellationToken cancellationToken)
        {
            ICollection<CovidVaccine> CovidVaccines = _CovidVaccineRepository.FilterWithInclude(x=>x.TraineeId == request.TraineeId, "Trainee", "Trainee.Rank").ToList();
            
            var CovidVaccineDtos = _mapper.Map<List<CovidVaccineDto>>(CovidVaccines);
            return CovidVaccineDtos; 
        }
    }
}
