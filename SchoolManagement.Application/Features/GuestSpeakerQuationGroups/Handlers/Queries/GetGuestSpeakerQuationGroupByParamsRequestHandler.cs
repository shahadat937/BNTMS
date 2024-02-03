using AutoMapper;
using SchoolManagement.Application.DTOs.GuestSpeakerQuationGroup;
using SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Handlers.Queries
{
    public class GetGuestSpeakerQuationGroupByParamsRequestHandler : IRequestHandler<GetGuestSpeakerQuationGroupByParamsRequest, List<GuestSpeakerQuationGroupDto>>
    {
         
        private readonly ISchoolManagementRepository<GuestSpeakerQuationGroup> _GuestSpeakerQuationGroupRepository;

        private readonly IMapper _mapper;

        public GetGuestSpeakerQuationGroupByParamsRequestHandler(ISchoolManagementRepository<GuestSpeakerQuationGroup> GuestSpeakerQuationGroupRepository, IMapper mapper)
        {
            _GuestSpeakerQuationGroupRepository = GuestSpeakerQuationGroupRepository; 
            _mapper = mapper;
        }

        public async Task<List<GuestSpeakerQuationGroupDto>> Handle(GetGuestSpeakerQuationGroupByParamsRequest request, CancellationToken cancellationToken)
        {
            var  GuestSpeakerQuationGroups = _GuestSpeakerQuationGroupRepository.FilterWithInclude(x=> x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseDurationId == request.CourseDurationId && x.BnaSubjectNameId == request.BnaSubjectNameId, "BaseSchoolName", "CourseName", "CourseDuration", "BnaSubjectName", "Trainee.Rank", "GuestSpeakerQuestionName").OrderByDescending(x => x.GuestSpeakerQuationGroupId);

            var GuestSpeakerQuationGroupDtos = _mapper.Map<List<GuestSpeakerQuationGroupDto>>(GuestSpeakerQuationGroups);

            return GuestSpeakerQuationGroupDtos; 
        }
    }
}
