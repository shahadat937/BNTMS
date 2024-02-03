using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaClassTestType;
using SchoolManagement.Application.Features.BnaClassTestTypes.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaClassTestTypes.Handlers.Queries
{
    public class GetBnaClassTestTypeDetailRequestHandler: IRequestHandler<GetBnaClassTestTypeDetailRequest, BnaClassTestTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<BnaClassTestType> _BnaClassTestTypeRepository;
        public GetBnaClassTestTypeDetailRequestHandler(ISchoolManagementRepository<BnaClassTestType> BnaClassTestTypeRepository, IMapper mapper)
        {
            _BnaClassTestTypeRepository = BnaClassTestTypeRepository;
            _mapper = mapper;
        }
        public async Task<BnaClassTestTypeDto> Handle(GetBnaClassTestTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var BnaClassTestType = await _BnaClassTestTypeRepository.Get(request.BnaClassTestTypeId);
            return _mapper.Map<BnaClassTestTypeDto>(BnaClassTestType);
        }
    }
}
