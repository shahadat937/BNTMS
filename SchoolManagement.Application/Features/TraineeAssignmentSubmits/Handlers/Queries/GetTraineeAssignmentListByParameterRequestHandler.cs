using AutoMapper;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.TraineeAssignmentSubmits.Requests.Queries;
using SchoolManagement.Application.DTOs.TraineeAssignmentSubmits;

namespace SchoolManagement.Application.Features.TraineeAssignmentSubmits.Handlers.Queries
{
    public class GetTraineeAssignmentListByParameterRequestHandler : IRequestHandler<GetTraineeAssignmentListByParameterRequest, List<TraineeAssignmentSubmitDto>>
    {

        private readonly ISchoolManagementRepository<TraineeAssignmentSubmit> _TraineeAssignmentSubmitRepository;

        private readonly IMapper _mapper;

        public GetTraineeAssignmentListByParameterRequestHandler(ISchoolManagementRepository<TraineeAssignmentSubmit> TraineeAssignmentSubmitRepository, IMapper mapper)
        {
            _TraineeAssignmentSubmitRepository = TraineeAssignmentSubmitRepository;
            _mapper = mapper;
        }

        public async Task<List<TraineeAssignmentSubmitDto>> Handle(GetTraineeAssignmentListByParameterRequest request, CancellationToken cancellationToken)
        {
            IQueryable<TraineeAssignmentSubmit> TraineeAssignmentSubmits = _TraineeAssignmentSubmitRepository.FilterWithInclude(x => x.TraineeId == request.TraineeId && x.InstructorId == request.InstructorId && x.BnaSubjectNameId == request.BnaSubjectNameId && x.BaseSchoolNameId==request.BaseSchoolNameId && x.CourseNameId==request.CourseNameId && x.CourseDurationId== request.CourseDurationId && x.CourseInstructorId==request.CourseInstructorId && x.InstructorAssignmentId ==request.InstructorAssignmentId);
            //var TraineeAssignmentSubmits = _TraineeAssignmentSubmitRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.TraineeAssignmentSubmitId);

            var TraineeAssignmentSubmitDtos = _mapper.Map<List<TraineeAssignmentSubmitDto>>(TraineeAssignmentSubmits);

            return TraineeAssignmentSubmitDtos;
        }
    }
}
