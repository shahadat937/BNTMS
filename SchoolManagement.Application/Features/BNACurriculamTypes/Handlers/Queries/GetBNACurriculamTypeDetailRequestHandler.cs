using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaCurriculamType;
using SchoolManagement.Application.Features.BnaCurriculamTypes.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaCurriculamTypes.Handlers.Queries
{
    public class GetBnaCurriculamTypeDetailRequestHandler : IRequestHandler<GetBnaCurriculamTypeDetailRequest, BnaCurriculamTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<BnaCurriculumType> _BnaCurriculamTypeRepository;
        public GetBnaCurriculamTypeDetailRequestHandler(ISchoolManagementRepository<BnaCurriculumType> BnaCurriculamTypeRepository, IMapper mapper)
        {
            _BnaCurriculamTypeRepository = BnaCurriculamTypeRepository;
            _mapper = mapper;
        }
        public async Task<BnaCurriculamTypeDto> Handle(GetBnaCurriculamTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var BnaCurriculamType = await _BnaCurriculamTypeRepository.Get(request.BnaCurriculamTypeId);
            return _mapper.Map<BnaCurriculamTypeDto>(BnaCurriculamType);
        }
    }
}
