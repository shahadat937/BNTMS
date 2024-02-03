using AutoMapper;
using SchoolManagement.Application.DTOs.CourseSection;
using SchoolManagement.Application.Features.CourseSections.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseSections.Handlers.Queries
{
    public class GetCourseSectionDetailRequestHandler : IRequestHandler<GetCourseSectionDetailRequest, CourseSectionDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<CourseSection> _CourseSectionRepository;
        public GetCourseSectionDetailRequestHandler(ISchoolManagementRepository<CourseSection> CourseSectionRepository, IMapper mapper)
        {
            _CourseSectionRepository = CourseSectionRepository;
            _mapper = mapper;
        }
        public async Task<CourseSectionDto> Handle(GetCourseSectionDetailRequest request, CancellationToken cancellationToken)
        {
            var CourseSection =  _CourseSectionRepository.FinedOneInclude(x => x.CourseSectionId == request.CourseSectionId, "CourseName");
            return _mapper.Map<CourseSectionDto>(CourseSection);
        }
    }
}
