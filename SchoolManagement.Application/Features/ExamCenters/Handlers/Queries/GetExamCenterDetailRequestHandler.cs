using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ExamCenter;
using SchoolManagement.Application.Features.ExamCenters.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamCenters.Handlers.Queries
{
    public class GetExamCenterDetailRequestHandler : IRequestHandler<GetExamCenterDetailRequest, ExamCenterDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<ExamCenter> _ExamCenterRepository;
        public GetExamCenterDetailRequestHandler(ISchoolManagementRepository<ExamCenter> ExamCenterRepository, IMapper mapper)
        {
            _ExamCenterRepository = ExamCenterRepository;
            _mapper = mapper;
        }
        public async Task<ExamCenterDto> Handle(GetExamCenterDetailRequest request, CancellationToken cancellationToken)
        {
            var ExamCenter = await _ExamCenterRepository.Get(request.ExamCenterId);
            return _mapper.Map<ExamCenterDto>(ExamCenter);
        }
    }
}
