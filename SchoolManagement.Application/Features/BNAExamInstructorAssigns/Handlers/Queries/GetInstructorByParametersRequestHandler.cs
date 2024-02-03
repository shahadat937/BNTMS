using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaExamInstructorAssigns.Requests.Queries;
using SchoolManagement.Domain;
using System.Data;
using SchoolManagement.Application.DTOs.BnaExamInstructorAssign;

namespace SchoolManagement.Application.Features.BnaExamInstructorAssigns.Handlers.Queries
{
    public class GetInstructorByParametersRequestHandler : IRequestHandler<GetInstructorByParametersRequest, List<BnaExamInstructorAssignDto>>
    {
        private readonly ISchoolManagementRepository<BnaExamInstructorAssign> _BnaExamInstructorAssignRepository;

        private readonly IMapper _mapper;
        public GetInstructorByParametersRequestHandler(ISchoolManagementRepository<BnaExamInstructorAssign> BnaExamInstructorAssignRepository, IMapper mapper)
        {
            _BnaExamInstructorAssignRepository = BnaExamInstructorAssignRepository;
            _mapper = mapper;
        }

        public async Task<List<BnaExamInstructorAssignDto>> Handle(GetInstructorByParametersRequest request, CancellationToken cancellationToken)
        {
            IQueryable<BnaExamInstructorAssign> BnaExamInstructorAssigns = _BnaExamInstructorAssignRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.BnaSubjectNameId == request.BnaSubjectNameId && x.ClassRoutine.Date >= DateTime.Now, "BaseSchoolName", "BnaInstructorType", "BnaSubjectName", "ClassRoutine", "CourseDuration", "CourseModule", "CourseName", "Trainee.Rank").OrderByDescending(x => x.BnaExamInstructorAssignId);
            //var BnaExamInstructorAssigns = _BnaExamInstructorAssignRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.BnaExamInstructorAssignId);

            var BnaExamInstructorAssignDtos = _mapper.Map<List<BnaExamInstructorAssignDto>>(BnaExamInstructorAssigns);

            return BnaExamInstructorAssignDtos;
        }

    }
}
