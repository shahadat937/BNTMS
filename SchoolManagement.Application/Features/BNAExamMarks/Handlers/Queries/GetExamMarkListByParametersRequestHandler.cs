using AutoMapper;
using SchoolManagement.Application.DTOs.BnaExamMark;
using SchoolManagement.Application.Features.BnaExamMarks.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaExamMarks.Handlers.Queries   
{
    public class GetExamMarkListByParametersRequestHandler : IRequestHandler<GetExamMarkListByParametersRequest, List<BnaExamMarkDto>>
    {

        private readonly ISchoolManagementRepository<BnaExamMark> _BnaExamMarkRepository;

        private readonly IMapper _mapper;

        public GetExamMarkListByParametersRequestHandler(ISchoolManagementRepository<BnaExamMark> BnaExamMarkRepository, IMapper mapper)
        {
            _BnaExamMarkRepository = BnaExamMarkRepository;
            _mapper = mapper;
        }

        public async Task<List<BnaExamMarkDto>> Handle(GetExamMarkListByParametersRequest request, CancellationToken cancellationToken)
        {
            IQueryable<BnaExamMark> BnaExamMarks = _BnaExamMarkRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseDurationId == request.CourseDurationId && x.BnaSubjectNameId == request.BnaSubjectNameId && x.SubjectMarkId == request.SubjectMarkId && x.IsApproved == request.ApproveStatus, "Trainee.Rank").OrderBy(x => x.BnaExamMarkId);
            //var BnaExamMarks = _BnaExamMarkRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.BnaExamMarkId);

            var BnaExamMarkDtos = _mapper.Map<List<BnaExamMarkDto>>(BnaExamMarks);

            return BnaExamMarkDtos;
        }
    }
}
