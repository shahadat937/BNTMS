using AutoMapper;
using SchoolManagement.Application.DTOs.CourseModule;
using SchoolManagement.Application.Features.CourseModules.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseModules.Handlers.Queries
{
    public class GetCourseModuleDetailRequestHandler : IRequestHandler<GetCourseModuleDetailRequest, CourseModuleDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CourseModule> _CourseModuleRepository;
        public GetCourseModuleDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CourseModule> CourseModuleRepository, IMapper mapper)
        {
            _CourseModuleRepository = CourseModuleRepository;
            _mapper = mapper;
        }
        public async Task<CourseModuleDto> Handle(GetCourseModuleDetailRequest request, CancellationToken cancellationToken)
        {
            var CourseModule =  _CourseModuleRepository.FinedOneInclude(x => x.CourseModuleId == request.CourseModuleId, "CourseName");
            return _mapper.Map<CourseModuleDto>(CourseModule);
        }
    }
}
