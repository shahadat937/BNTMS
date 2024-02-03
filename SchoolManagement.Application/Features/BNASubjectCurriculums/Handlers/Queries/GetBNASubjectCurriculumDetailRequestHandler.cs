using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaSubjectCurriculums;
using SchoolManagement.Application.Features.BnaSubjectCurriculums.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading; 
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaSubjectCurriculums.Handlers.Queries
{
    public class GetBnaSubjectCurriculumDetailRequestHandler : IRequestHandler<GetBnaSubjectCurriculumDetailRequest, BnaSubjectCurriculumDto>
    {
        private readonly IMapper _mapper; 
        private readonly ISchoolManagementRepository<BnaSubjectCurriculum> _BnaSubjectCurriculumRepository;
        public GetBnaSubjectCurriculumDetailRequestHandler(ISchoolManagementRepository<BnaSubjectCurriculum> BnaSubjectCurriculumRepository, IMapper mapper)
        {
            _BnaSubjectCurriculumRepository = BnaSubjectCurriculumRepository;
            _mapper = mapper;
        }
        public async Task<BnaSubjectCurriculumDto> Handle(GetBnaSubjectCurriculumDetailRequest request, CancellationToken cancellationToken)
        {
            var BnaSubjectCurriculum = await _BnaSubjectCurriculumRepository.Get(request.BnaSubjectCurriculumId);
            return _mapper.Map<BnaSubjectCurriculumDto>(BnaSubjectCurriculum);
        }
    }
}
