using AutoMapper;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Domain; 
using SchoolManagement.Application.Features.SubjectClassifications.Requests.Queries;
using SchoolManagement.Application.DTOs.SubjectClassifications;

namespace SchoolManagement.Application.Features.SubjectClassifications.Handlers.Queries
{
    public class GetSubjectClassificationDetailRequestHandler : IRequestHandler<GetSubjectClassificationDetailRequest, SubjectClassificationDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SubjectClassification> _SubjectClassificationRepository;
        public GetSubjectClassificationDetailRequestHandler(ISchoolManagementRepository<SubjectClassification> SubjectClassificationRepository, IMapper mapper)
        {
            _SubjectClassificationRepository = SubjectClassificationRepository;
            _mapper = mapper;
        }
        public async Task<SubjectClassificationDto> Handle(GetSubjectClassificationDetailRequest request, CancellationToken cancellationToken)
        {
            var SubjectClassification = await _SubjectClassificationRepository.Get(request.SubjectClassificationId);
            return _mapper.Map<SubjectClassificationDto>(SubjectClassification);
        }
    }
}
