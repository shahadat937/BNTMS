using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ExamCenterSelection;
using SchoolManagement.Application.Features.ExamCenterSelections.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamCenterSelections.Handlers.Queries
{
    public class GetExamCenterSelectionDetailRequestHandler : IRequestHandler<GetExamCenterSelectionDetailRequest, ExamCenterSelectionDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<ExamCenterSelection> _ExamCenterSelectionRepository;
        public GetExamCenterSelectionDetailRequestHandler(ISchoolManagementRepository<ExamCenterSelection> ExamCenterSelectionRepository, IMapper mapper)
        {
            _ExamCenterSelectionRepository = ExamCenterSelectionRepository;
            _mapper = mapper;
        }
        public async Task<ExamCenterSelectionDto> Handle(GetExamCenterSelectionDetailRequest request, CancellationToken cancellationToken)
        {
            var ExamCenterSelection = await _ExamCenterSelectionRepository.Get(request.ExamCenterSelectionId);
            return _mapper.Map<ExamCenterSelectionDto>(ExamCenterSelection);
        }
    }
}
