using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BudgetTransaction;
using SchoolManagement.Application.DTOs.BudgetTransaction.Validators;
using SchoolManagement.Application.Features.AccountTypes.Handlers.Commands;
using SchoolManagement.Application.Features.AccountTypes.Requests.Commands;
using SchoolManagement.Application.Features.BudgetTransactionType.Request.Command;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BudgetTransactionType.Handler.Command
{
    public class CreateBudgetTransactionCommand : IRequestHandler<CreateBudgetTransactionCommandHandler, BaseCommandResponse>
    {
         private readonly IUnitOfWork _unitOfWork;
         private readonly IMapper _mapper;

        public CreateBudgetTransactionCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<BaseCommandResponse> Handle(CreateBudgetTransactionCommandHandler request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseCommandResponse> Handler(CreateBudgetTransactionCommandHandler request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBudgetTransactionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BudgetTransactionDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
           else
            {
                var BudgetTransaction = _mapper.Map<BudgetTransaction>(request.BudgetTransactionDto);
                BudgetTransaction.Status = 0;

                BudgetTransaction = await _unitOfWork.Repository<BudgetTransaction>().Add(BudgetTransaction);
                await _unitOfWork.Save();

                if (BudgetTransaction.BudgetTypeId == 3)
                {
                    var budgetCode = await _unitOfWork.Repository<BudgetCode>().Get(request.BudgetTransactionDto.BudgetCodeId);
                    budgetCode.TotalBudget += BudgetTransaction.Amount;
                }
                else if (BudgetTransaction.BudgetTypeId == 2)
                {
                    var budgetCode = await _unitOfWork.Repository<BudgetCode>().Get(request.BudgetTransactionDto.BudgetCodeId);
                    budgetCode.TotalBudget += BudgetTransaction.Amount;

                    if (budgetCode.TotalBudget >= 0)
                    {
                        await _unitOfWork.Repository<BudgetCode>().Update(budgetCode);
                        await _unitOfWork.Save();
                    }
                }
                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BudgetTransaction.BudgetTransactionId;

            }
            return response;
            
        }

        //Task<BaseCommandResponse> IRequestHandler<CreateBudgetTransactionCommandHandler, BaseCommandResponse>.Handle(CreateBudgetTransactionCommandHandler request, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
