using AutoMapper;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.InstructorAssignments.Requests.Queries;
using SchoolManagement.Application.DTOs.InstructorAssignments;

namespace SchoolManagement.Application.Features.InstructorAssignments.Handlers.Queries
{
    public class GetInstructorAssignmentListByInstructorIdRequestHandler : IRequestHandler<GetInstructorAssignmentListByInstructorIdRequest, List<InstructorAssignmentDto>>
    {

        private readonly ISchoolManagementRepository<InstructorAssignment> _InstructorAssignmentRepository;

        private readonly IMapper _mapper;

        public GetInstructorAssignmentListByInstructorIdRequestHandler(ISchoolManagementRepository<InstructorAssignment> InstructorAssignmentRepository, IMapper mapper)
        {
            _InstructorAssignmentRepository = InstructorAssignmentRepository;
            _mapper = mapper;
        }

        public async Task<List<InstructorAssignmentDto>> Handle(GetInstructorAssignmentListByInstructorIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<InstructorAssignment> InstructorAssignments = _InstructorAssignmentRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseDurationId == request.CourseDurationId && x.BnaSubjectNameId == request.BnaSubjectNameId && x.InstructorId==request.InstructorId);
            //var InstructorAssignments = _InstructorAssignmentRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.InstructorAssignmentId);

            var InstructorAssignmentDtos = _mapper.Map<List<InstructorAssignmentDto>>(InstructorAssignments);

            return InstructorAssignmentDtos;
        }
    }
}
