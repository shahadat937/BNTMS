using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TdecGroupResult;
using SchoolManagement.Application.Features.TdecGroupResults.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TdecGroupResults.Handlers.Queries
{
    public class GetTdecGroupResultDetailRequestHandler : IRequestHandler<GetTdecGroupResultDetailRequest, TdecGroupResultDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<TdecGroupResult> _TdecGroupResultRepository;
        public GetTdecGroupResultDetailRequestHandler(ISchoolManagementRepository<TdecGroupResult> TdecGroupResultRepository, IMapper mapper)
        {
            _TdecGroupResultRepository = TdecGroupResultRepository;
            _mapper = mapper;
        }
        public async Task<TdecGroupResultDto> Handle(GetTdecGroupResultDetailRequest request, CancellationToken cancellationToken)
        {
            var TdecGroupResult = await _TdecGroupResultRepository.Get(request.TdecGroupResultId);
            return _mapper.Map<TdecGroupResultDto>(TdecGroupResult);
        }
    }
}
