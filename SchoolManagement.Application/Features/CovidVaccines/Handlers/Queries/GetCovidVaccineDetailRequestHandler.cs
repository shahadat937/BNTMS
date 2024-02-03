using AutoMapper;
using SchoolManagement.Application.DTOs.CovidVaccine;
using SchoolManagement.Application.Features.CovidVaccines.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CovidVaccines.Handlers.Queries
{
    public class GetCovidVaccineDetailRequestHandler : IRequestHandler<GetCovidVaccineDetailRequest, CovidVaccineDto>
    {
       // private readonly ICovidVaccineRepository _CovidVaccineRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CovidVaccine> _CovidVaccineRepository;
        public GetCovidVaccineDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CovidVaccine>  CovidVaccineRepository, IMapper mapper)
        {
            _CovidVaccineRepository = CovidVaccineRepository;
            _mapper = mapper;
        }
        public async Task<CovidVaccineDto> Handle(GetCovidVaccineDetailRequest request, CancellationToken cancellationToken)
        {
            var CovidVaccine = await _CovidVaccineRepository.Get(request.CovidVaccineId);
            return _mapper.Map<CovidVaccineDto>(CovidVaccine);
        }
    }
}
