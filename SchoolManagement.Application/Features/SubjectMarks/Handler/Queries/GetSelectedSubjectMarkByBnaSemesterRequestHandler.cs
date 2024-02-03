using AutoMapper;
using SchoolManagement.Application.DTOs.SubjectMark;
using SchoolManagement.Application.Features.SubjectMarks.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SubjectMarks.Handlers.Queries   
{
    public class GetSelectedSubjectMarkByBnaSemesterRequestHandler : IRequestHandler<GetSelectedSubjectMarkByBnaSemesterRequest, List<SubjectMarkDto>>
    {

        private readonly ISchoolManagementRepository<SubjectMark> _SubjectMarkRepository;

        private readonly IMapper _mapper;

        public GetSelectedSubjectMarkByBnaSemesterRequestHandler(ISchoolManagementRepository<SubjectMark> SubjectMarkRepository, IMapper mapper)
        {
            _SubjectMarkRepository = SubjectMarkRepository;
            _mapper = mapper;
        }

        public async Task<List<SubjectMarkDto>> Handle(GetSelectedSubjectMarkByBnaSemesterRequest request, CancellationToken cancellationToken)
        {
            IQueryable<SubjectMark> SubjectMarks = _SubjectMarkRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.BnaSemesterId == request.BnaSemesterId && x.BnaSubjectNameId == request.BnaSubjectNameId, "BaseSchoolName", "BnaSubjectName", "CourseModule", "CourseName", "MarkType", "BnaSubjectName.BnaSubjectCurriculum", "MarkCategory").OrderByDescending(x => x.SubjectMarkId);

            var SubjectMarkDtos = _mapper.Map<List<SubjectMarkDto>>(SubjectMarks);

            return SubjectMarkDtos;
        }
    }
}
