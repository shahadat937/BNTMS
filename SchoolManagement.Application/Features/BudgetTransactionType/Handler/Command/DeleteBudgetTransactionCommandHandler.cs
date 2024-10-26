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
            var BudgetTransaction = await _unitOfWork.Repository<BudgetTransaction>().Get(request.BudgetTransactionId);

            if (BudgetTransaction == null)
                throw new NotFoundException(nameof(BudgetAllocation), request.BudgetTransactionId);

            await _unitOfWork.Repository<BudgetTransaction>().Delete(BudgetTransaction);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
