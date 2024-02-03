using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ExamPeriodTypes;
using SchoolManagement.Application.Features.ExamPeriodTypes.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamPeriodTypes.Handlers.Queries
{
    public class GetExamPeriodTypeDetailRequestHandler : IRequestHandler<GetExamPeriodTypeDetailRequest, ExamPeriodTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<ExamPeriodType> _ExamPeriodTypeRepository;
        public GetExamPeriodTypeDetailRequestHandler(ISchoolManagementRepository<ExamPeriodType> ExamPeriodTypeRepository, IMapper mapper)
        {
            _ExamPeriodTypeRepository = ExamPeriodTypeRepository;
            _mapper = mapper;
        }
        public async Task<ExamPeriodTypeDto> Handle(GetExamPeriodTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var ExamPeriodType = await _ExamPeriodTypeRepository.Get(request.ExamPeriodTypeId);
            return _mapper.Map<ExamPeriodTypeDto>(ExamPeriodType);
        }
    }
}
