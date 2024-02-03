using AutoMapper;
using SchoolManagement.Application.DTOs.UtofficerType;
using SchoolManagement.Application.Features.UtofficerTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.UtofficerTypes.Handlers.Queries
{
    public class GetUtofficerTypeDetailRequestHandler : IRequestHandler<GetUtofficerTypeDetailRequest, UtofficerTypeDto>
    {
       // private readonly IUtofficerTypeRepository _UtofficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.UtofficerType> _UtofficerTypeRepository;
        public GetUtofficerTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.UtofficerType>  UtofficerTypeRepository, IMapper mapper)
        {
            _UtofficerTypeRepository = UtofficerTypeRepository;
            _mapper = mapper;
        }
        public async Task<UtofficerTypeDto> Handle(GetUtofficerTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var UtofficerType = await _UtofficerTypeRepository.Get(request.UtofficerTypeId);
            return _mapper.Map<UtofficerTypeDto>(UtofficerType);
        }
    }
}
