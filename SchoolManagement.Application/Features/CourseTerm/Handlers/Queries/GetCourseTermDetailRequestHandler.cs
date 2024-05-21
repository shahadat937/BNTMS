using AutoMapper;
using SchoolManagement.Application.DTOs.CourseTerm;
using SchoolManagement.Application.Features.CourseTerms.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseTerms.Handlers.Queries
{
    public class GetCourseTermDetailRequestHandler : IRequestHandler<GetCourseTermDetailRequest, CourseTermDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<CourseTerm> _CourseTermRepository;
        public GetCourseTermDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CourseTerm> CourseTermRepository, IMapper mapper)
        {
            _CourseTermRepository = CourseTermRepository;
            _mapper = mapper;
        }
        public async Task<CourseTermDto> Handle(GetCourseTermDetailRequest request, CancellationToken cancellationToken)
        {
            var CourseTerm = await _CourseTermRepository.Get(request.CourseTermId);
            return _mapper.Map<CourseTermDto>(CourseTerm);
        }
    }
}
