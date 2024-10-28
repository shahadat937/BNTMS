using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BudgetAllocation;
using SchoolManagement.Application.DTOs.BudgetTransaction;
using SchoolManagement.Application.Features.AccountTypes.Handlers.Queries;
using SchoolManagement.Application.Features.BudgetTransactionType.Request.Queries;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BudgetTransactionType.Handler.Queries
{
    public class GetBudgetTransactionDetailsRequestHandler : IRequestHandler<GetBudgetTransactionDetailRequest, BudgetTransactionDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<BudgetTransaction> _BudgetTransactionRepository;

        public GetBudgetTransactionDetailsRequestHandler(ISchoolManagementRepository<BudgetTransaction> BudgetTransactionRepository, IMapper mapper)
        {
            _mapper = mapper;
            _BudgetTransactionRepository = BudgetTransactionRepository;
        }
        public async Task<BudgetTransactionDto> Handle(GetBudgetTransactionDetailRequest request, CancellationToken cancellationToken)
        {
            var BudgetTransaction = await _BudgetTransactionRepository.Get(request.BudgetTransactionId);
            return _mapper.Map<BudgetTransactionDto>(BudgetTransaction);
        }


    }
}
