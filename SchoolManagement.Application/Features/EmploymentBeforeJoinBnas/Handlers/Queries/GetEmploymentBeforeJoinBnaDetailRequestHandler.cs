using AutoMapper;
using SchoolManagement.Application.DTOs.EmploymentBeforeJoinBna;
using SchoolManagement.Application.Features.EmploymentBeforeJoinBnas.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.EmploymentBeforeJoinBnas.Handlers.Queries
{
    public class GetEmploymentBeforeJoinBnaDetailRequestHandler : IRequestHandler<GetEmploymentBeforeJoinBnaDetailRequest, EmploymentBeforeJoinBnaDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.EmploymentBeforeJoinBna> _EmploymentBeforeJoinBnaRepository;
        public GetEmploymentBeforeJoinBnaDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.EmploymentBeforeJoinBna> EmploymentBeforeJoinBnaRepository, IMapper mapper)
        {
            _EmploymentBeforeJoinBnaRepository = EmploymentBeforeJoinBnaRepository;
            _mapper = mapper;
        }
        public async Task<EmploymentBeforeJoinBnaDto> Handle(GetEmploymentBeforeJoinBnaDetailRequest request, CancellationToken cancellationToken)
        {
            var EmploymentBeforeJoinBna = await _EmploymentBeforeJoinBnaRepository.FindOneAsync(x => x.EmploymentBeforeJoinBnaId == request.EmploymentBeforeJoinBnaId);
            return _mapper.Map<EmploymentBeforeJoinBnaDto>(EmploymentBeforeJoinBna);
        }
    }
}
