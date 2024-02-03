using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MaritalStatus;
using SchoolManagement.Application.Features.MaritalStatuss.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MaritalStatuss.Handler.Queries
{
    public class GetMaritalStatusDetailRequestHandler : IRequestHandler<GetMaritalStatusDetailRequest, MaritalStatusDto>
    {
        private readonly IMapper _mapper; 
        private readonly ISchoolManagementRepository<MaritalStatus> _maritalStatusRepository; 
        public GetMaritalStatusDetailRequestHandler(ISchoolManagementRepository<MaritalStatus> maritalStatusRepository, IMapper mapper)
        {
            _maritalStatusRepository = maritalStatusRepository; 
            _mapper = mapper;
        }
        public async Task<MaritalStatusDto> Handle(GetMaritalStatusDetailRequest request, CancellationToken cancellationToken)
        {
            var MaritalStatus = await _maritalStatusRepository.Get(request.Id);
            return _mapper.Map<MaritalStatusDto>(MaritalStatus);
        }
    }
}
