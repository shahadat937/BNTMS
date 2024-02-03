using AutoMapper;
using SchoolManagement.Application.DTOs.Election;
using SchoolManagement.Application.Features.Elections.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Elections.Handlers.Queries
{
    //public class GetElectionListByTraineeRequestHandler : IRequestHandler<GetElectionListByTraineeRequest, Unit>


    public class GetElectionListByTraineeRequestHandler : IRequestHandler<GetElectionListByTraineeRequest, List<ElectionDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Election> _ElectionRepository;
        public GetElectionListByTraineeRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Election> ElectionRepository, IMapper mapper)
        {
            _ElectionRepository = ElectionRepository;
            _mapper = mapper;
        }
        public async Task<List<ElectionDto>> Handle(GetElectionListByTraineeRequest request, CancellationToken cancellationToken)
        {
            var Election = _ElectionRepository.FilterWithInclude(x =>(x.TraineeId == request.Traineeid), "Elected");
            return _mapper.Map<List<ElectionDto>>(Election);
        }
    }
}
