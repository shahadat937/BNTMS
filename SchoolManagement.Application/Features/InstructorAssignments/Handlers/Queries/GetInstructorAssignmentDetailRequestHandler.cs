using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.InstructorAssignments;
using SchoolManagement.Application.Features.InstructorAssignments.Requests.Queries;

namespace SchoolManagement.Application.Features.InstructorAssignments.Handlers.Queries
{
    public class GetInstructorAssignmentDetailRequestHandler : IRequestHandler<GetInstructorAssignmentDetailRequest, InstructorAssignmentDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.InstructorAssignment> _InstructorAssignmentRepository;
        public GetInstructorAssignmentDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.InstructorAssignment> InstructorAssignmentRepository, IMapper mapper)
        {
            _InstructorAssignmentRepository = InstructorAssignmentRepository;
            _mapper = mapper;
        }
        public async Task<InstructorAssignmentDto> Handle(GetInstructorAssignmentDetailRequest request, CancellationToken cancellationToken)
        {
            var InstructorAssignment = await _InstructorAssignmentRepository.Get(request.InstructorAssignmentId);
            return _mapper.Map<InstructorAssignmentDto>(InstructorAssignment);
        }
    }
}
