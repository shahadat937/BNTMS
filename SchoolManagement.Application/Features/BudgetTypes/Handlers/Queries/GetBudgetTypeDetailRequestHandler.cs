using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BudgetType;
using SchoolManagement.Application.Features.BudgetTypes.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BudgetTypes.Handlers.Queries
{
    public class GetBudgetTypeDetailRequestHandler : IRequestHandler<GetBudgetTypeDetailRequest, BudgetTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BudgetType> _BudgetTypeRepository;
        public GetBudgetTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BudgetType> BudgetTypeRepository, IMapper mapper)
        {
            _BudgetTypeRepository = BudgetTypeRepository;
            _mapper = mapper;
        }
        public async Task<BudgetTypeDto> Handle(GetBudgetTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var BudgetType = await _BudgetTypeRepository.Get(request.BudgetTypeId);
            return _mapper.Map<BudgetTypeDto>(BudgetType);
        }
    }
}
