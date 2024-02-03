using AutoMapper;
using SchoolManagement.Application.DTOs.BnaInstructorType;
using SchoolManagement.Application.Features.BnaInstructorTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaInstructorTypes.Handlers.Queries
{
    public class GetBnaInstructorTypeDetailRequestHandler : IRequestHandler<GetBnaInstructorTypeDetailRequest, BnaInstructorTypeDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BnaInstructorType> _BnaInstructorTypeRepository;
        public GetBnaInstructorTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BnaInstructorType> BnaInstructorTypeRepository, IMapper mapper)
        {
            _BnaInstructorTypeRepository = BnaInstructorTypeRepository;
            _mapper = mapper;
        }
        public async Task<BnaInstructorTypeDto> Handle(GetBnaInstructorTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var BnaInstructorType = await _BnaInstructorTypeRepository.Get(request.BnaInstructorTypeId);
            return _mapper.Map<BnaInstructorTypeDto>(BnaInstructorType);
        }
    }
}
