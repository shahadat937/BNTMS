using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseSection;
using SchoolManagement.Application.Features.CourseSections.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseSections.Handlers.Queries
{
    public class GetCourseSectionListByBaseNameIdAndCourseNameIdRequestHandler : IRequestHandler<GetCourseSectionListByBaseNameIdAndCourseNameIdRequest, List<CourseSectionDto>>
    {
        private readonly ISchoolManagementRepository<CourseSection> _CourseSectionRepository;
        private readonly IMapper _mapper;

        public GetCourseSectionListByBaseNameIdAndCourseNameIdRequestHandler(ISchoolManagementRepository<CourseSection> CourseSectionRepository, IMapper mapper)
        {
            _CourseSectionRepository = CourseSectionRepository;
            _mapper = mapper;
        }
         
        public async Task<List<CourseSectionDto>> Handle(GetCourseSectionListByBaseNameIdAndCourseNameIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<CourseSection> CourseSections = _CourseSectionRepository.FilterWithInclude(x=>x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId, "BaseSchoolName", "CourseName").ToList();
            //List<SelectedModel> selectModels = CourseSections.Select(x => new SelectedModel
            //{
            //    Text = x.ModuleName,
            //    Value = x.CourseSectionId 
            //}).ToList();
            var CourseSectionDtos = _mapper.Map<List<CourseSectionDto>>(CourseSections);
            return CourseSectionDtos; 
        }
    }
}
