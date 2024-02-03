using AutoMapper;
using SchoolManagement.Application.DTOs.GuestSpeakerQuestionName;
using SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;

namespace SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Handlers.Queries
{
    public class GetGuestSpeakerQuestionListRequestHandler : IRequestHandler<GetGuestSpeakerQuestionListRequest, List<GuestSpeakerQuestionNameDto>>
    {

        private readonly ISchoolManagementRepository<GuestSpeakerQuestionName> _GuestSpeakerQuestionNameRepository;

        private readonly IMapper _mapper;

        public GetGuestSpeakerQuestionListRequestHandler(ISchoolManagementRepository<GuestSpeakerQuestionName> GuestSpeakerQuestionNameRepository, IMapper mapper)
        {
            _GuestSpeakerQuestionNameRepository = GuestSpeakerQuestionNameRepository;
            _mapper = mapper;
        }

        public async Task<List<GuestSpeakerQuestionNameDto>> Handle(GetGuestSpeakerQuestionListRequest request, CancellationToken cancellationToken)
        {
            var GuestSpeakerQuestionNameDtos = new List<GuestSpeakerQuestionNameDto>();
            if (request.BaseSchoolNameId == 0)
            {
                var GuestSpeakerQuestionNames = _GuestSpeakerQuestionNameRepository.FilterWithInclude(x => x.IsActive && x.BaseSchoolNameId == null);
                //var GuestSpeakerQuestionNames = _GuestSpeakerQuestionNameRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.GuestSpeakerQuestionNameId);

                GuestSpeakerQuestionNameDtos = _mapper.Map<List<GuestSpeakerQuestionNameDto>>(GuestSpeakerQuestionNames);
            }
            else
            {
                var GuestSpeakerQuestionNames = _GuestSpeakerQuestionNameRepository.FilterWithInclude(x => x.IsActive && x.BaseSchoolNameId == request.BaseSchoolNameId);
                //var GuestSpeakerQuestionNames = _GuestSpeakerQuestionNameRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.GuestSpeakerQuestionNameId);

                GuestSpeakerQuestionNameDtos = _mapper.Map<List<GuestSpeakerQuestionNameDto>>(GuestSpeakerQuestionNames);
            }


            return GuestSpeakerQuestionNameDtos;
        }
    }
}
