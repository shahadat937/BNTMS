using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SubjectMark;
using SchoolManagement.Application.Features.SubjectMarks.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SubjectMarks.Handler.Queries
{
    public class GetSubjectMarkDetailRequestHandler : IRequestHandler<GetSubjectMarkDetailRequest, SubjectMarkDto>
    {
        private readonly IMapper _mapper; 
        private readonly ISchoolManagementRepository<SubjectMark> _SubjectMarkRepository; 
        public GetSubjectMarkDetailRequestHandler(ISchoolManagementRepository<SubjectMark> SubjectMarkRepository, IMapper mapper)
        {
            _SubjectMarkRepository = SubjectMarkRepository; 
            _mapper = mapper;
        }
        public async Task<SubjectMarkDto> Handle(GetSubjectMarkDetailRequest request, CancellationToken cancellationToken)
        {
            //var SubjectMark = await _SubjectMarkRepository.Get(request.Id);
            var SubjectMark = _SubjectMarkRepository.FinedOneInclude(x => x.SubjectMarkId == request.Id, "CourseName", "CourseModule", "BnaSubjectName");
            return _mapper.Map<SubjectMarkDto>(SubjectMark);
        }
    }
}
