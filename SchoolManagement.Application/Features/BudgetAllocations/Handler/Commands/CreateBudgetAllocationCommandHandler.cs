using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BudgetAllocation.Validators;
using SchoolManagement.Application.Features.BudgetAllocations.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BudgetAllocations.Handler.Commands
{
    public class CreateBudgetAllocationCommandHandler : IRequestHandler<CreateBudgetAllocationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public CreateBudgetAllocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateBudgetAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBudgetAllocationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BudgetAllocationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BudgetAllocation = _mapper.Map<BudgetAllocation>(request.BudgetAllocationDto);
                BudgetAllocation.Status = 0;

                BudgetAllocation = await _unitOfWork.Repository<BudgetAllocation>().Add(BudgetAllocation);
                await _unitOfWork.Save();

                if(BudgetAllocation.BudgetTypeId == 3)
                {
                    var budgetCode = await _unitOfWork.Repository<BudgetCode>().Get(request.BudgetAllocationDto.BudgetCodeId.Value);
                    budgetCode.TotalBudget += BudgetAllocation.Amount;

                    await _unitOfWork.Repository<BudgetCode>().Update(budgetCode);
                    await _unitOfWork.Save();
                }

                else if (BudgetAllocation.BudgetTypeId == 2)
                {
                    var budgetCode = await _unitOfWork.Repository<BudgetCode>().Get(request.BudgetAllocationDto.BudgetCodeId.Value);
                    budgetCode.TotalBudget -= BudgetAllocation.Amount;

                    if(budgetCode.TotalBudget >= 0)
                    {
                        await _unitOfWork.Repository<BudgetCode>().Update(budgetCode);
                        await _unitOfWork.Save();
                    }               
                }

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BudgetAllocation.BudgetAllocationId;
            }

            return response;
        }
    }
}
