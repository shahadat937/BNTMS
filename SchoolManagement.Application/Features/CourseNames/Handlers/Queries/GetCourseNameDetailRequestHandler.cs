using AutoMapper;
using SchoolManagement.Application.DTOs.CourseName;
using SchoolManagement.Application.Features.CourseNames.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseNames.Handlers.Queries
{
    public class GetCourseNameDetailRequestHandler : IRequestHandler<GetCourseNameDetailRequest, CourseNameDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CourseName> _CourseNameRepository;
        public GetCourseNameDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CourseName> CourseNameRepository, IMapper mapper)
        {
            _CourseNameRepository = CourseNameRepository;
            _mapper = mapper;
        }
        public async Task<CourseNameDto> Handle(GetCourseNameDetailRequest request, CancellationToken cancellationToken)
        {
            var CourseName = await _CourseNameRepository.Get(request.CourseNameId);
            return _mapper.Map<CourseNameDto>(CourseName);
        }
    }
}
