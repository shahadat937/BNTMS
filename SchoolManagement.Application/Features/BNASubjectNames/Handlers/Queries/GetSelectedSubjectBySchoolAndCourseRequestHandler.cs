using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Handlers.Queries
{
    public class GetSelectedSubjectBySchoolAndCourseRequestHandler : IRequestHandler<GetSelectedSubjectBySchoolAndCourseRequest, List<BnaSubjectNameDto>>
    {
        private readonly ISchoolManagementRepository<BnaSubjectName> _BnaSubjectNameRepository;
        private readonly IMapper _mapper;


        public GetSelectedSubjectBySchoolAndCourseRequestHandler(ISchoolManagementRepository<BnaSubjectName> BnaSubjectNameRepository, IMapper mapper)
        {
            _BnaSubjectNameRepository = BnaSubjectNameRepository;
            _mapper = mapper;
        }

        public async Task<List<BnaSubjectNameDto>> Handle(GetSelectedSubjectBySchoolAndCourseRequest request, CancellationToken cancellationToken)
        {
            
            IQueryable<BnaSubjectName> BnaSubjectNames = _BnaSubjectNameRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.SubjectActiveStatus != 0 && x.SubjectGreading !=1 , "CourseModule", "SubjectCategory", "BnaSubjectCurriculum", "SubjectType", "KindOfSubject", "SubjectClassification").OrderBy(x => x.CourseModule.MenuPosition);
            //var BnaSubjectNames = _BnaSubjectNameRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.BnaSubjectNameId);

            var BnaSubjectNameDtos = _mapper.Map<List<BnaSubjectNameDto>>(BnaSubjectNames);

            return BnaSubjectNameDtos;
        }
    }
}
