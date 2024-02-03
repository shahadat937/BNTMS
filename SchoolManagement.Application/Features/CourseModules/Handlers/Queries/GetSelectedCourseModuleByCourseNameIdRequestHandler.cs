using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseModule;
using SchoolManagement.Application.Features.CourseModules.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseModules.Handlers.Queries
{
    public class GetSelectedCourseModuleByCourseNameIdRequestHandler : IRequestHandler<GetSelectedCourseModuleByCourseNameIdRequest, List<CourseModuleDto>>
    {
        private readonly ISchoolManagementRepository<CourseModule> _CourseModuleRepository;
        private readonly IMapper _mapper;

        public GetSelectedCourseModuleByCourseNameIdRequestHandler(ISchoolManagementRepository<CourseModule> CourseModuleRepository, IMapper mapper)
        {
            _CourseModuleRepository = CourseModuleRepository;
            _mapper = mapper;
        }
         
        public async Task<List<CourseModuleDto>> Handle(GetSelectedCourseModuleByCourseNameIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<CourseModule> courseModules = _CourseModuleRepository.FilterWithInclude(x=>x.CourseNameId == request.CourseNameId, "BaseSchoolName", "CourseName").ToList();
            
            var CourseModuleDtos = _mapper.Map<List<CourseModuleDto>>(courseModules);
            return CourseModuleDtos; 
        }
    }
}
