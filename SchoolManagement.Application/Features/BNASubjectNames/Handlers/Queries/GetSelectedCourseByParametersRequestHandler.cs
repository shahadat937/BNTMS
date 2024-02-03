using AutoMapper;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Handlers.Queries   
{
    public class GetSelectedCourseByParametersRequestHandler : IRequestHandler<GetSelectedCourseByParametersRequest, List<BnaSubjectNameDto>>
    {

        private readonly ISchoolManagementRepository<BnaSubjectName> _BnaSubjectNameRepository;

        private readonly IMapper _mapper;

        public GetSelectedCourseByParametersRequestHandler(ISchoolManagementRepository<BnaSubjectName> BnaSubjectNameRepository, IMapper mapper)
        {
            _BnaSubjectNameRepository = BnaSubjectNameRepository;
            _mapper = mapper;
        }

        public async Task<List<BnaSubjectNameDto>> Handle(GetSelectedCourseByParametersRequest request, CancellationToken cancellationToken)
        {
            IQueryable<BnaSubjectName> BnaSubjectNames = _BnaSubjectNameRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status, "SubjectCategory", "BnaSubjectCurriculum", "SubjectType", "KindOfSubject", "SubjectClassification").OrderBy(x => x.MenuPosition);
            //var BnaSubjectNames = _BnaSubjectNameRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.BnaSubjectNameId);

            var BnaSubjectNameDtos = _mapper.Map<List<BnaSubjectNameDto>>(BnaSubjectNames);

            return BnaSubjectNameDtos;
        }
    }
}
