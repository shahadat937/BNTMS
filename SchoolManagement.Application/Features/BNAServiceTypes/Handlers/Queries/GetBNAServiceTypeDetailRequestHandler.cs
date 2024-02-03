using AutoMapper;
using SchoolManagement.Application.DTOs.BnaServiceType;
using SchoolManagement.Application.Features.BnaServiceTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading; 
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaServiceTypes.Handlers.Queries
{
    public class GetBnaServiceTypeDetailRequestHandler : IRequestHandler<GetBnaServiceTypeDetailRequest, BnaServiceTypeDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BnaServiceType> _BnaServiceTypeRepository;
        public GetBnaServiceTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BnaServiceType> BnaServiceTypeRepository, IMapper mapper)
        {
            _BnaServiceTypeRepository = BnaServiceTypeRepository;
            _mapper = mapper;
        }
        public async Task<BnaServiceTypeDto> Handle(GetBnaServiceTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var BnaServiceType = await _BnaServiceTypeRepository.Get(request.BnaServiceTypeId);
            return _mapper.Map<BnaServiceTypeDto>(BnaServiceType);
        }
    }
}
