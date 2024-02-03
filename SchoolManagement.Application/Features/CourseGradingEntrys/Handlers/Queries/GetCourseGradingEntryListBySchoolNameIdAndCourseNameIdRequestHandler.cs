using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseGradingEntry;
using SchoolManagement.Application.Features.CourseGradingEntrys.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseGradingEntrys.Handlers.Queries
{
    public class GetCourseGradingEntryListBySchoolNameIdAndCourseNameIdRequestHandler : IRequestHandler<GetCourseGradingEntryListBySchoolNameIdAndCourseNameIdRequest, List<CourseGradingEntryDto>>
    {
        private readonly ISchoolManagementRepository<CourseGradingEntry> _CourseGradingEntryRepository;
        private readonly IMapper _mapper;

        public GetCourseGradingEntryListBySchoolNameIdAndCourseNameIdRequestHandler(ISchoolManagementRepository<CourseGradingEntry> CourseGradingEntryRepository, IMapper mapper)
        {
            _CourseGradingEntryRepository = CourseGradingEntryRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseGradingEntryDto>> Handle(GetCourseGradingEntryListBySchoolNameIdAndCourseNameIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<CourseGradingEntry> CourseGradingEntrys = _CourseGradingEntryRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId, "BaseSchoolName", "CourseName", "Assessment").ToList();
            
            var CourseGradingEntryDtos = _mapper.Map<List<CourseGradingEntryDto>>(CourseGradingEntrys);
            return CourseGradingEntryDtos;
        }
    }
}
