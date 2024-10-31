using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BudgetTransactionType.Request.Command;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BudgetTransactionType.Handler.Command
{
    public class DeleteBudgetTransactionCommandHandler : IRequestHandler<DeleteBudgetTransactionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBudgetTransactionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBudgetTransactionCommand request, CancellationToken cancellationToken)
        {
            var budgetTransaction = await _unitOfWork.Repository<BudgetTransaction>().Get(request.BudgetTransactionId);

            if (budgetTransaction == null)
                throw new NotFoundException(nameof(BudgetTransaction), request.BudgetTransactionId);

            var budgetCode = await _unitOfWork.Repository<BudgetCode>().Get(budgetTransaction.BudgetCodeId);

            if (budgetCode != null)
            {
                if (budgetTransaction.BudgetTypeId == 3)
                {
                    budgetCode.TotalBudget -= budgetTransaction.Amount;
                }
                else if (budgetTransaction.BudgetTypeId == 2)
                {
                    budgetCode.TotalBudget += budgetTransaction.Amount;
                }

                if (budgetCode.TotalBudget < 0)
                    throw new InvalidOperationException("Budget would go negative.");

                await _unitOfWork.Repository<BudgetCode>().Update(budgetCode);
            }

            await _unitOfWork.Repository<BudgetTransaction>().Delete(budgetTransaction);
            await _unitOfWork.Save();

            return Unit.Value;
        }

    }
}
