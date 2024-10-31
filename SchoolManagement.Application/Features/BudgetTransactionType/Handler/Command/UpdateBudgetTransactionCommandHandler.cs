using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BudgetTransaction.Validators;
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
    public class UpdateBudgetTransactionCommandHandler : IRequestHandler<UpdateBudgetTransactionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBudgetTransactionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBudgetTransactionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBudgetTransactionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BudgetTransactionDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var budgetTransaction = await _unitOfWork.Repository<BudgetTransaction>().Get(request.BudgetTransactionDto.BudgetTransactionId);

            if (budgetTransaction == null)
                throw new NotFoundException(nameof(BudgetTransaction), request.BudgetTransactionDto.BudgetTransactionId);

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

 
                if (request.BudgetTransactionDto.BudgetTypeId == 3)
                {
                    budgetCode.TotalBudget += request.BudgetTransactionDto.Amount;
                }
                else if (request.BudgetTransactionDto.BudgetTypeId == 2)
                {
                    budgetCode.TotalBudget -= request.BudgetTransactionDto.Amount;


                    if (budgetCode.TotalBudget < 0)
                        throw new InvalidOperationException("Insufficient budget. Update cannot be completed.");
                }

                await _unitOfWork.Repository<BudgetCode>().Update(budgetCode);
            }

         
            _mapper.Map(request.BudgetTransactionDto, budgetTransaction);
            budgetTransaction.DateCreated = request.BudgetTransactionDto.DateCreated;



            await _unitOfWork.Repository<BudgetTransaction>().Update(budgetTransaction);
            await _unitOfWork.Save();

            return Unit.Value;
        }


        //public async Task<Unit> Handler(UpdateBudgetTransactionCommand request, CancellationToken cancellationToken)
        //{

        //}


    }
}
