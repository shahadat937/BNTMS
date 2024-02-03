using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaSemesterDurations;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.Features.BnaSemesterDurations.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaSemesterDurations.Handlers.Queries
{  
    public class GetBnaSemesterDurationDetailRequestHandler : IRequestHandler<GetBnaSemesterDurationDetailRequest, BnaSemesterDurationDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<BnaSemesterDuration> _BnaSemesterDurationRepository;       
        public GetBnaSemesterDurationDetailRequestHandler(ISchoolManagementRepository<BnaSemesterDuration> BnaSemesterDurationRepository, IMapper mapper)
        {
            _BnaSemesterDurationRepository = BnaSemesterDurationRepository;    
            _mapper = mapper; 
        } 
        public async Task<BnaSemesterDurationDto> Handle(GetBnaSemesterDurationDetailRequest request, CancellationToken cancellationToken)
        {
            var BnaSemesterDuration = _BnaSemesterDurationRepository.FinedOneInclude(x => x.BnaSemesterDurationId == request.Id, "BnaSemester");
            return _mapper.Map<BnaSemesterDurationDto>(BnaSemesterDuration);
            //var BnaSemesterDuration = await _BnaSemesterDurationRepository.Get(request.Id);    
            //return _mapper.Map<BnaSemesterDurationDto>(BnaSemesterDuration);    
        }
    }
}
