using AutoMapper;
using SchoolManagement.Application.DTOs.EmploymentBeforeJoinBna;
using SchoolManagement.Application.Features.EmploymentBeforeJoinBnas.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.EmploymentBeforeJoinBnas.Handlers.Queries
{
    public class GetEmploymentBeforeJoinBnaListByTraineeRequestHandler : IRequestHandler<GetEmploymentBeforeJoinBnaListByTraineeRequest, List<EmploymentBeforeJoinBnaDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.EmploymentBeforeJoinBna> _EmploymentBeforeJoinBnaRepository;
        public GetEmploymentBeforeJoinBnaListByTraineeRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.EmploymentBeforeJoinBna> EmploymentBeforeJoinBnaRepository, IMapper mapper)
        {
            _EmploymentBeforeJoinBnaRepository = EmploymentBeforeJoinBnaRepository;
            _mapper = mapper;
        }
        public async Task<List<EmploymentBeforeJoinBnaDto>> Handle(GetEmploymentBeforeJoinBnaListByTraineeRequest request, CancellationToken cancellationToken)
        {
            var EmploymentBeforeJoinBna = _EmploymentBeforeJoinBnaRepository.FilterWithInclude(x => (x.TraineeId == request.Traineeid));
            return _mapper.Map<List<EmploymentBeforeJoinBnaDto>>(EmploymentBeforeJoinBna);
        }
    }
    
}
