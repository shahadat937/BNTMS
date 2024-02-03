using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ClassType;
using SchoolManagement.Application.Features.ClassTypes.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassTypes.Handlers.Queries
{
    public class GetClassTypeDetailRequestHandler : IRequestHandler<GetClassTypeDetailRequest, ClassTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ClassType> _ClassTypeRepository;
        public GetClassTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ClassType> ClassTypeRepository, IMapper mapper)
        {
            _ClassTypeRepository = ClassTypeRepository;
            _mapper = mapper;
        }
        public async Task<ClassTypeDto> Handle(GetClassTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var ClassType = await _ClassTypeRepository.Get(request.ClassTypeId);
            return _mapper.Map<ClassTypeDto>(ClassType);
        }
    }
}
