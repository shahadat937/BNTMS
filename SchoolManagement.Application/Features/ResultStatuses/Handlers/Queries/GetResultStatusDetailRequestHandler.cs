using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ResultStatus;
using SchoolManagement.Application.Features.ResultStatuses.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ResultStatuses.Handlers.Queries
{
    public class GetResultStatusDetailRequestHandler : IRequestHandler<GetResultStatusDetailRequest, ResultStatusDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ResultStatus> _ResultStatusRepository;
        public GetResultStatusDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ResultStatus> ResultStatusRepository, IMapper mapper)
        {
            _ResultStatusRepository = ResultStatusRepository;
            _mapper = mapper;
        }
        public async Task<ResultStatusDto> Handle(GetResultStatusDetailRequest request, CancellationToken cancellationToken)
        {
            var ResultStatus = await _ResultStatusRepository.Get(request.ResultStatusId);
            return _mapper.Map<ResultStatusDto>(ResultStatus);
        }
    }
}
