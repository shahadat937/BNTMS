using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Handlers.Queries
{
    public class GetBNASubjectNameListByCourseNameIdRequestHandler : IRequestHandler<GetBNASubjectNameListByCourseNameIdRequest, List<BnaSubjectNameDto>>
    {
        private readonly ISchoolManagementRepository<BnaSubjectName> _BnaSubjectNameRepository;

        private readonly IMapper _mapper;
        public GetBNASubjectNameListByCourseNameIdRequestHandler(ISchoolManagementRepository<BnaSubjectName> BnaSubjectNameRepository, IMapper mapper)
        {
            _BnaSubjectNameRepository = BnaSubjectNameRepository;
            _mapper = mapper;
        }
         
        public async Task<List<BnaSubjectNameDto>> Handle(GetBNASubjectNameListByCourseNameIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<BnaSubjectName> BnaSubjectNames = _BnaSubjectNameRepository.FilterWithInclude(x => x.CourseNameId== 1251, "SubjectType", "CourseName").OrderBy(x=>x.MenuPosition);

            var BnaSubjectNameDtos = _mapper.Map<List<BnaSubjectNameDto>>(BnaSubjectNames);

            return BnaSubjectNameDtos;
        }

    }
}
