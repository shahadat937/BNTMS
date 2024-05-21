using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.UniversityCourseResult;
using SchoolManagement.Application.Features.UniversityCourseResults.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.UniversityCourseResults.Handlers.Queries
{
    public class GetUniversityCourseResultByTraineeIdRequestHandler : IRequestHandler<GetUniversityCourseResultByTraineeIdRequest, UniversityCourseResultDto>
    {
        
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.UniversityCourseResult> _UniversityCourseResultRepository;
        public GetUniversityCourseResultByTraineeIdRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.UniversityCourseResult> UniversityCourseResultRepository, IMapper mapper)
        {
            _UniversityCourseResultRepository = UniversityCourseResultRepository;
            _mapper = mapper;
        }
        public async Task<UniversityCourseResultDto> Handle(GetUniversityCourseResultByTraineeIdRequest request, CancellationToken cancellationToken)
        {
            var UniversityCourseResult = await _UniversityCourseResultRepository.Get(request.TraineeId);
            return _mapper.Map<UniversityCourseResultDto>(UniversityCourseResult);
        }
    }
}
