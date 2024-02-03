using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Notices.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.Notices.Handlers.Queries
{
    public class GetNoticeBySchoolIdSpRequestHandler : IRequestHandler<GetNoticeBySchoolIdSpRequest, object>
    {

        private readonly ISchoolManagementRepository<Notice> _noticeRepository;

        private readonly IMapper _mapper;

        public GetNoticeBySchoolIdSpRequestHandler(ISchoolManagementRepository<Notice> NoticeRepository, IMapper mapper)
        {
            _noticeRepository = NoticeRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetNoticeBySchoolIdSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetNoticeForSchoolDashboard] '{0}',{1}", request.CurrentDate, request.BaseSchoolNameId);
            
            DataTable dataTable = _noticeRepository.ExecWithSqlQuery(spQuery);
            var countv = dataTable.Rows.Count;
            return dataTable;
         
        }
    }
}
