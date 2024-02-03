using MediatR;
using SchoolManagement.Application.DTOs.ClassPeriod;
using SchoolManagement.Application.DTOs.Notice;

namespace SchoolManagement.Application.Features.Notices.Requests.Queries
{
    public class GetSelectedNoticeBySchoolRequest : IRequest<List<NoticeDto>>
    {
        public int BaseSchoolNameId { get; set; }
    }
}

  