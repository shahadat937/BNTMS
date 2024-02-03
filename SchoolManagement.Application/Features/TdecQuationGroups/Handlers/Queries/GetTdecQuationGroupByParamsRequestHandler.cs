using AutoMapper;
using SchoolManagement.Application.DTOs.TdecQuationGroup;
using SchoolManagement.Application.Features.TdecQuationGroups.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TdecQuationGroups.Handlers.Queries
{
    public class GetTdecQuationGroupByParamsRequestHandler : IRequestHandler<GetTdecQuationGroupByParamsRequest, List<TdecQuationGroupDto>>
    {
         
        private readonly ISchoolManagementRepository<TdecQuationGroup> _TdecQuationGroupRepository;

        private readonly IMapper _mapper;

        public GetTdecQuationGroupByParamsRequestHandler(ISchoolManagementRepository<TdecQuationGroup> TdecQuationGroupRepository, IMapper mapper)
        {
            _TdecQuationGroupRepository = TdecQuationGroupRepository; 
            _mapper = mapper;
        }

        public async Task<List<TdecQuationGroupDto>> Handle(GetTdecQuationGroupByParamsRequest request, CancellationToken cancellationToken)
        {
            var  TdecQuationGroups = _TdecQuationGroupRepository.FilterWithInclude(x=> x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseDurationId == request.CourseDurationId && x.BnaSubjectNameId == request.BnaSubjectNameId, "BaseSchoolName", "CourseName", "CourseDuration", "BnaSubjectName", "Trainee.Rank", "TdecQuestionName").OrderByDescending(x => x.TdecQuationGroupId);

            var TdecQuationGroupDtos = _mapper.Map<List<TdecQuationGroupDto>>(TdecQuationGroups);

            return TdecQuationGroupDtos; 
        }
    }
}
