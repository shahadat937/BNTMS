using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

        public async Task<BaseCommandResponse> Handle(CreateBudgetTransactionCommandHandler request, CancellationToken cancellationToken)
            {
            var response = new BaseCommandResponse();
            var validator = new CreateBudgetTransactionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BudgetTransactionDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var budgetTransaction = _mapper.Map<BudgetTransaction>(request.BudgetTransactionDto);
                budgetTransaction.Status = 0;

                budgetTransaction = await _unitOfWork.Repository<BudgetTransaction>().Add(budgetTransaction);

            
                    await _unitOfWork.Save();
               
                

                var budgetCode = await _unitOfWork.Repository<BudgetCode>().Get(request.BudgetTransactionDto.BudgetCodeId);

                if (budgetCode != null)
                {
                    if (budgetTransaction.BudgetTypeId == 3)
                    {
                        budgetCode.TotalBudget += budgetTransaction.Amount;
                    }
                    else if (budgetTransaction.BudgetTypeId == 2)
                    {
                        budgetCode.TotalBudget -= budgetTransaction.Amount;

                        if (budgetCode.TotalBudget < 0)
                        {
                            
                            response.Success = false;
                            response.Message = "Insufficient Budget. Transaction cannot be created.";
                            return response;
                        }
                    }

                    await _unitOfWork.Repository<BudgetCode>().Update(budgetCode);
                    await _unitOfWork.Save(); 
                }

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = budgetTransaction.BudgetTransactionId;
            }
            return response;
        }
    }

}
