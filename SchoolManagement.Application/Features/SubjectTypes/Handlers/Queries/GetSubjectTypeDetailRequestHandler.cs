using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SubjectTypes;
using SchoolManagement.Application.Features.SubjectTypes.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SubjectTypes.Handlers.Queries
{
    public class GetSubjectTypeDetailRequestHandler : IRequestHandler<GetSubjectTypeDetailRequest, SubjectTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SubjectType> _SubjectTypeRepository;
        public GetSubjectTypeDetailRequestHandler(ISchoolManagementRepository<SubjectType> SubjectTypeRepository, IMapper mapper)
        {
            _SubjectTypeRepository = SubjectTypeRepository;
            _mapper = mapper;
        }
        public async Task<SubjectTypeDto> Handle(GetSubjectTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var SubjectType = await _SubjectTypeRepository.Get(request.SubjectTypeId);
            return _mapper.Map<SubjectTypeDto>(SubjectType);
        }
    }
}
