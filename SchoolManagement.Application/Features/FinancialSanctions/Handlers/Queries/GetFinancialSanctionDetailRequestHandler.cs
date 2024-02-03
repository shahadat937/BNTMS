using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.FinancialSanction;
using SchoolManagement.Application.Features.FinancialSanctions.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FinancialSanctions.Handlers.Queries
{
    public class GetFinancialSanctionDetailRequestHandler : IRequestHandler<GetFinancialSanctionDetailRequest, FinancialSanctionDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<FinancialSanction> _FinancialSanctionRepository;
        public GetFinancialSanctionDetailRequestHandler(ISchoolManagementRepository<FinancialSanction> FinancialSanctionRepository, IMapper mapper)
        {
            _FinancialSanctionRepository = FinancialSanctionRepository;
            _mapper = mapper;
        }
        public async Task<FinancialSanctionDto> Handle(GetFinancialSanctionDetailRequest request, CancellationToken cancellationToken)
        {
            var FinancialSanction = await _FinancialSanctionRepository.Get(request.FinancialSanctionId);
            return _mapper.Map<FinancialSanctionDto>(FinancialSanction);
        }
    }
}
