using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseTypes;
using SchoolManagement.Application.Features.CourseTypes.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseTypes.Handlers.Queries
{
    public class GetCourseTypeDetailRequestHandler : IRequestHandler<GetCourseTypeDetailRequest, CourseTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<CourseType> _CourseTypeRepository;
        public GetCourseTypeDetailRequestHandler(ISchoolManagementRepository<CourseType> CourseTypeRepository, IMapper mapper)
        {
            _CourseTypeRepository = CourseTypeRepository;
            _mapper = mapper;
        }
        public async Task<CourseTypeDto> Handle(GetCourseTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var CourseType = await _CourseTypeRepository.Get(request.CourseTypeId);
            return _mapper.Map<CourseTypeDto>(CourseType);
        }
    }
}
