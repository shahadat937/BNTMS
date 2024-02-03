using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseBudgetAllocation.Validators;
using SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Handler.Commands
{
    public class CreateCourseBudgetAllocationCommandHandler : IRequestHandler<CreateCourseBudgetAllocationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public CreateCourseBudgetAllocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateCourseBudgetAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCourseBudgetAllocationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CourseBudgetAllocationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var CourseBudgetAllocation = _mapper.Map<CourseBudgetAllocation>(request.CourseBudgetAllocationDto);

                //CourseBudgetAllocation = await _unitOfWork.Repository<CourseBudgetAllocation>().Add(CourseBudgetAllocation);
                //CourseBudgetAllocation.Status = 0;
                //await _unitOfWork.Save();

                //if (CourseBudgetAllocation.PaymentTypeId == 1)
                //{
                //    CourseBudgetAllocation = await _unitOfWork.Repository<CourseBudgetAllocation>().Add(CourseBudgetAllocation);
                //    CourseBudgetAllocation.Status = 1;
                //    CourseBudgetAllocation.PaymentDate = CourseBudgetAllocation.NextInstallmentDate;
                //    await _unitOfWork.Save();
                //}
                //else
                //{
                //    CourseBudgetAllocation = await _unitOfWork.Repository<CourseBudgetAllocation>().Add(CourseBudgetAllocation);
                //    CourseBudgetAllocation.Status = 0;
                //    await _unitOfWork.Save();
                //}


                if (CourseBudgetAllocation.PaymentTypeId == 2)
                {
                    CourseBudgetAllocation = await _unitOfWork.Repository<CourseBudgetAllocation>().Add(CourseBudgetAllocation);
                    CourseBudgetAllocation.Status = 0;
                    await _unitOfWork.Save();

                    var budgetCode = await _unitOfWork.Repository<BudgetCode>().Get(request.CourseBudgetAllocationDto.BudgetCodeId.Value);
                    budgetCode.TargetAmount += CourseBudgetAllocation.InstallmentAmount;

                    await _unitOfWork.Repository<BudgetCode>().Update(budgetCode);
                    await _unitOfWork.Save();
                }

                else if (CourseBudgetAllocation.PaymentTypeId == 1)
                {
                    CourseBudgetAllocation = await _unitOfWork.Repository<CourseBudgetAllocation>().Add(CourseBudgetAllocation);
                    CourseBudgetAllocation.Status = 1;
                    CourseBudgetAllocation.PaymentDate = CourseBudgetAllocation.NextInstallmentDate;
                    await _unitOfWork.Save();


                    var budgetCode = await _unitOfWork.Repository<BudgetCode>().Get(request.CourseBudgetAllocationDto.BudgetCodeId.Value);
                    budgetCode.AvailableAmount -= CourseBudgetAllocation.InstallmentAmount;

                    if (budgetCode.AvailableAmount >= 0)
                    {
                        await _unitOfWork.Repository<BudgetCode>().Update(budgetCode);
                        await _unitOfWork.Save();
                    }
                }


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CourseBudgetAllocation.CourseBudgetAllocationId;
            }

            return response;
        }
    }
}
