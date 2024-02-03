using AutoMapper;
using SchoolManagement.Application.DTOs.SubjectMark;
using SchoolManagement.Application.Features.SubjectMarks.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SubjectMarks.Handlers.Queries   
{
    public class GetSelectedSubjectMarkByCourseNameIdSubjectNameIdRequestHandler : IRequestHandler<GetSelectedSubjectMarkByCourseNameIdSubjectNameIdRequest, List<SubjectMarkDto>>
    {
        private readonly ISchoolManagementRepository<SubjectMark> _SubjectMarkRepository;

        private readonly IMapper _mapper;

        public GetSelectedSubjectMarkByCourseNameIdSubjectNameIdRequestHandler(ISchoolManagementRepository<SubjectMark> SubjectMarkRepository, IMapper mapper)
        {
            _SubjectMarkRepository = SubjectMarkRepository;
            _mapper = mapper;
        }

        public async Task<List<SubjectMarkDto>> Handle(GetSelectedSubjectMarkByCourseNameIdSubjectNameIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<SubjectMark> SubjectMarks = _SubjectMarkRepository.FilterWithInclude(x => x.CourseNameId == request.CourseNameId && x.BnaSubjectNameId == request.BnaSubjectNameId, "MarkType");
            //var SubjectMarks = _SubjectMarkRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.SubjectMarkId);

            var SubjectMarkDtos = _mapper.Map<List<SubjectMarkDto>>(SubjectMarks);

            return SubjectMarkDtos;
        }
    }
}
