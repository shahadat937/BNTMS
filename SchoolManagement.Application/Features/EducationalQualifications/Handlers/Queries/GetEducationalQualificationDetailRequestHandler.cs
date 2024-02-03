using AutoMapper;
using SchoolManagement.Application.DTOs.EducationalQualification;
using SchoolManagement.Application.Features.EducationalQualifications.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.EducationalQualifications.Handlers.Queries
{
    public class GetEducationalQualificationDetailRequestHandler : IRequestHandler<GetEducationalQualificationDetailRequest, EducationalQualificationDto>
    {
       // private readonly IEducationalQualificationRepository _EducationalQualificationRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.EducationalQualification> _EducationalQualificationRepository;
        public GetEducationalQualificationDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.EducationalQualification>  EducationalQualificationRepository, IMapper mapper)
        {
            _EducationalQualificationRepository = EducationalQualificationRepository;
            _mapper = mapper;
        }
        public async Task<EducationalQualificationDto> Handle(GetEducationalQualificationDetailRequest request, CancellationToken cancellationToken)
        {
            var EducationalQualification = await _EducationalQualificationRepository.FindOneAsync(x =>x.EducationalQualificationId == request.EducationalQualificationId, "ExamType", "Board", "Group");
            return _mapper.Map<EducationalQualificationDto>(EducationalQualification);
        }
    }
}
