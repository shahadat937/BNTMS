using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseSection;
using SchoolManagement.Application.Features.CourseSections.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseSections.Handlers.Queries
{
    public class GetSelectedCourseSectionByCourseNameIdRequestHandler : IRequestHandler<GetSelectedCourseSectionByCourseNameIdRequest, List<CourseSectionDto>>
    {
        private readonly ISchoolManagementRepository<CourseSection> _CourseSectionRepository;
        private readonly IMapper _mapper;

        public GetSelectedCourseSectionByCourseNameIdRequestHandler(ISchoolManagementRepository<CourseSection> CourseSectionRepository, IMapper mapper)
        {
            _CourseSectionRepository = CourseSectionRepository;
            _mapper = mapper;
        }
         
        public async Task<List<CourseSectionDto>> Handle(GetSelectedCourseSectionByCourseNameIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<CourseSection> CourseSections = _CourseSectionRepository.FilterWithInclude(x=>x.CourseNameId == request.CourseNameId, "CourseName").ToList();
            
            var CourseSectionDtos = _mapper.Map<List<CourseSectionDto>>(CourseSections);
            return CourseSectionDtos; 
        }
    }
}
