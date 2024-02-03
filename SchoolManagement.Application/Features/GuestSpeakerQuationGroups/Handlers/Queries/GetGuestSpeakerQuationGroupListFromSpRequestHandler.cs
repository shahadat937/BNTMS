using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Handlers.Queries
{
    public class GetGuestSpeakerQuationGroupListFromSpRequestHandler : IRequestHandler<GetGuestSpeakerQuationGroupListFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<GuestSpeakerQuationGroup> _GuestSpeakerQuationGroupRepository;

        private readonly IMapper _mapper;

        public GetGuestSpeakerQuationGroupListFromSpRequestHandler(ISchoolManagementRepository<GuestSpeakerQuationGroup> GuestSpeakerQuationGroupRepository, IMapper mapper)
        {
            _GuestSpeakerQuationGroupRepository = GuestSpeakerQuationGroupRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetGuestSpeakerQuationGroupListFromSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetGuestSpeakerQuestionGroupList] {0},{1},{2},{3}", request.BaseSchoolNameId, request.CourseNameId, request.CourseDurationId, request.BnaSubjectNameId);
            
            DataTable dataTable = _GuestSpeakerQuationGroupRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
         
        }
    }
}
