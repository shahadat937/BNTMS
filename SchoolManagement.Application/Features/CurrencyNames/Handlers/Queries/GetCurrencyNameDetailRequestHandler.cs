using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CurrencyName;
using SchoolManagement.Application.Features.CurrencyNames.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CurrencyNames.Handlers.Queries
{
    public class GetCurrencyNameDetailRequestHandler : IRequestHandler<GetCurrencyNameDetailRequest, CurrencyNameDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<CurrencyName> _CurrencyNameRepository;
        public GetCurrencyNameDetailRequestHandler(ISchoolManagementRepository<CurrencyName> CurrencyNameRepository, IMapper mapper)
        {
            _CurrencyNameRepository = CurrencyNameRepository;
            _mapper = mapper;
        }
        public async Task<CurrencyNameDto> Handle(GetCurrencyNameDetailRequest request, CancellationToken cancellationToken)
        {
            var CurrencyName = await _CurrencyNameRepository.Get(request.CurrencyNameId);
            return _mapper.Map<CurrencyNameDto>(CurrencyName);
        }
    }
}
