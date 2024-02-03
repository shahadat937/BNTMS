using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Assessment;
using SchoolManagement.Application.Features.Assessments.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Assessments.Handlers.Queries
{
    public class GetAssessmentDetailRequestHandler : IRequestHandler<GetAssessmentDetailRequest, AssessmentDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Assessment> _AssessmentRepository;
        public GetAssessmentDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Assessment> AssessmentRepository, IMapper mapper)
        {
            _AssessmentRepository = AssessmentRepository;
            _mapper = mapper;
        }
        public async Task<AssessmentDto> Handle(GetAssessmentDetailRequest request, CancellationToken cancellationToken)
        {
            var Assessment = await _AssessmentRepository.Get(request.AssessmentId);
            return _mapper.Map<AssessmentDto>(Assessment);
        }
    }
}
