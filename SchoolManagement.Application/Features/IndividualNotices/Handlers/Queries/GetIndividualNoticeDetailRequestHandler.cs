using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.IndividualNotice;
using SchoolManagement.Application.Features.IndividualNotices.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.IndividualNotices.Handlers.Queries
{
    public class GetIndividualNoticeDetailRequestHandler : IRequestHandler<GetIndividualNoticeDetailRequest, IndividualNoticeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<IndividualNotice> _IndividualNoticeRepository;
        public GetIndividualNoticeDetailRequestHandler(ISchoolManagementRepository<IndividualNotice> IndividualNoticeRepository, IMapper mapper)
        {
            _IndividualNoticeRepository = IndividualNoticeRepository;
            _mapper = mapper;
        }
        public async Task<IndividualNoticeDto> Handle(GetIndividualNoticeDetailRequest request, CancellationToken cancellationToken)
        {
            var IndividualNotice = await _IndividualNoticeRepository.Get(request.IndividualNoticeId);
            return _mapper.Map<IndividualNoticeDto>(IndividualNotice);
        }
    }
}
