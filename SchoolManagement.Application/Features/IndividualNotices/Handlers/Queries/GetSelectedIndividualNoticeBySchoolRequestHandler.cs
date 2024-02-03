using AutoMapper;
using SchoolManagement.Application.DTOs.IndividualNotice;
using SchoolManagement.Application.Features.IndividualNotices.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.IndividualNotices.Handlers.Queries   
{
    public class GetSelectedIndividualNoticeBySchoolRequestHandler : IRequestHandler<GetSelectedIndividualNoticeBySchoolRequest, List<IndividualNoticeDto>>
    {

        private readonly ISchoolManagementRepository<IndividualNotice> _IndividualNoticeRepository;

        private readonly IMapper _mapper;

        public GetSelectedIndividualNoticeBySchoolRequestHandler(ISchoolManagementRepository<IndividualNotice> IndividualNoticeRepository, IMapper mapper)
        {
            _IndividualNoticeRepository = IndividualNoticeRepository;
            _mapper = mapper;
        }

        public async Task<List<IndividualNoticeDto>> Handle(GetSelectedIndividualNoticeBySchoolRequest request, CancellationToken cancellationToken)
        {
            IQueryable<IndividualNotice> IndividualNotices = _IndividualNoticeRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId, "CourseName", "CourseDuration").OrderBy(x => x.Status);

            var IndividualNoticeDtos = _mapper.Map<List<IndividualNoticeDto>>(IndividualNotices);

            return IndividualNoticeDtos;
        }
    }
}
