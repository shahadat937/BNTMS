using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Handlers.Queries
{
    public class GetBNASubjectNameListByBranchIdRequestHandler : IRequestHandler<GetBNASubjectNameListByBranchIdRequest, List<BnaSubjectNameDto>>
    {
        private readonly ISchoolManagementRepository<BnaSubjectName> _BnaSubjectNameRepository;

        private readonly IMapper _mapper;
        public GetBNASubjectNameListByBranchIdRequestHandler(ISchoolManagementRepository<BnaSubjectName> BnaSubjectNameRepository, IMapper mapper)
        {
            _BnaSubjectNameRepository = BnaSubjectNameRepository;
            _mapper = mapper;
        }
         
        public async Task<List<BnaSubjectNameDto>> Handle(GetBNASubjectNameListByBranchIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<BnaSubjectName> BnaSubjectNames = _BnaSubjectNameRepository.FilterWithInclude(x => x.BranchId == request.BranchId && x.CourseNameId== request.CourseNameId, "SubjectType", "CourseName").OrderBy(x => x.MenuPosition);

            var BnaSubjectNameDtos = _mapper.Map<List<BnaSubjectNameDto>>(BnaSubjectNames);

            return BnaSubjectNameDtos;
        }

    }
}
