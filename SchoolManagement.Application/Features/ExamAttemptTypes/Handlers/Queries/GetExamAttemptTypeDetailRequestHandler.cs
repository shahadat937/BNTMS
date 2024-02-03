using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ExamAttemptType;
using SchoolManagement.Application.Features.ExamAttemptTypes.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamAttemptTypes.Handlers.Queries
{
    public class GetExamAttemptTypeDetailRequestHandler : IRequestHandler<GetExamAttemptTypeDetailRequest, ExamAttemptTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<ExamAttemptType> _ExamAttemptTypeRepository;
        public GetExamAttemptTypeDetailRequestHandler(ISchoolManagementRepository<ExamAttemptType> ExamAttemptTypeRepository, IMapper mapper)
        {
            _ExamAttemptTypeRepository = ExamAttemptTypeRepository;
            _mapper = mapper;
        }
        public async Task<ExamAttemptTypeDto> Handle(GetExamAttemptTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var ExamAttemptType = await _ExamAttemptTypeRepository.Get(request.ExamAttemptTypeId);
            return _mapper.Map<ExamAttemptTypeDto>(ExamAttemptType);
        }
    }
}
