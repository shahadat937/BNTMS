using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DownloadRight;
using SchoolManagement.Application.Features.DownloadRights.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.DownloadRights.Handlers.Queries
{
    public class GetDownloadRightDetailRequestHandler : IRequestHandler<GetDownloadRightDetailRequest, DownloadRightDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DownloadRight> _DownloadRightRepository;
        public GetDownloadRightDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DownloadRight> DownloadRightRepository, IMapper mapper)
        {
            _DownloadRightRepository = DownloadRightRepository;
            _mapper = mapper;
        }
        public async Task<DownloadRightDto> Handle(GetDownloadRightDetailRequest request, CancellationToken cancellationToken)
        {
            var DownloadRight = await _DownloadRightRepository.Get(request.DownloadRightId);
            return _mapper.Map<DownloadRightDto>(DownloadRight);
        }
    }
}
