using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Notices.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.Notices.Handlers.Queries
{
    public class GetNoticeForTraineeDashboardSpRequestHandler : IRequestHandler<GetNoticeForTraineeDashboardSpRequest, object>
    {

        private readonly ISchoolManagementRepository<Notice> _noticeRepository;

        private readonly IMapper _mapper;

        public GetNoticeForTraineeDashboardSpRequestHandler(ISchoolManagementRepository<Notice> NoticeRepository, IMapper mapper)
        {
            _noticeRepository = NoticeRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetNoticeForTraineeDashboardSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetNoticeForTrainee] '{0}',{1},{2},{3}", request.CurrentDate, request.BaseSchoolNameId, request.CourseDurationId, request.TraineeId);
            
            DataTable dataTable = _noticeRepository.ExecWithSqlQuery(spQuery);
            var countv = dataTable.Rows.Count;
            return dataTable;
         
        }
    }
}
