using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AllowancePercentage;
using SchoolManagement.Application.Features.AllowancePercentages.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AllowancePercentages.Handlers.Queries
{
    public class GetAllowancePercentageDetailRequestHandler : IRequestHandler<GetAllowancePercentageDetailRequest, AllowancePercentageDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<AllowancePercentage> _AllowancePercentageRepository;
        public GetAllowancePercentageDetailRequestHandler(ISchoolManagementRepository<AllowancePercentage> AllowancePercentageRepository, IMapper mapper)
        {
            _AllowancePercentageRepository = AllowancePercentageRepository;
            _mapper = mapper;
        }
        public async Task<AllowancePercentageDto> Handle(GetAllowancePercentageDetailRequest request, CancellationToken cancellationToken)
        {
            var AllowancePercentage = await _AllowancePercentageRepository.Get(request.AllowancePercentageId);
            return _mapper.Map<AllowancePercentageDto>(AllowancePercentage);
        }
    }
}
