using AutoMapper;
using SchoolManagement.Application.DTOs.BnaPromotionStatus;
using SchoolManagement.Application.Features.BnaPromotionStatuses.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaPromotionStatuses.Handlers.Queries
{
    public class GetBnaPromotionStatusDetailRequestHandler : IRequestHandler<GetBnaPromotionStatusDetailRequest, BnaPromotionStatusDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BnaPromotionStatus> _BnaPromotionStatusRepository;
        public GetBnaPromotionStatusDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BnaPromotionStatus> BnaPromotionStatusRepository, IMapper mapper)
        {
            _BnaPromotionStatusRepository = BnaPromotionStatusRepository;
            _mapper = mapper;
        }
        public async Task<BnaPromotionStatusDto> Handle(GetBnaPromotionStatusDetailRequest request, CancellationToken cancellationToken)
        {
            var BnaPromotionStatus = await _BnaPromotionStatusRepository.Get(request.BnaPromotionStatusId);
            return _mapper.Map<BnaPromotionStatusDto>(BnaPromotionStatus);
        }
    }
}
