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

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return response;
            }

            var courseBudgetAllocation = _mapper.Map<CourseBudgetAllocation>(request.CourseBudgetAllocationDto);
            courseBudgetAllocation = await _unitOfWork.Repository<CourseBudgetAllocation>().Add(courseBudgetAllocation);

            var budgetCode = await _unitOfWork.Repository<BudgetCode>().Get(request.CourseBudgetAllocationDto.BudgetCodeId.Value);

            if (courseBudgetAllocation.PaymentTypeId == 2)
            {
                courseBudgetAllocation.Status = 0;
                budgetCode.TargetAmount += courseBudgetAllocation.InstallmentAmount;
            }
            else if (courseBudgetAllocation.PaymentTypeId == 1)
            {
                courseBudgetAllocation.Status = 1;
                courseBudgetAllocation.PaymentDate = courseBudgetAllocation.NextInstallmentDate;
                budgetCode.TargetAmount -= courseBudgetAllocation.InstallmentAmount;
                budgetCode.AvailableAmount -= courseBudgetAllocation.InstallmentAmount;
            }

            // Save updated CourseBudgetAllocation and BudgetCode
            await _unitOfWork.Save();
            await _unitOfWork.Repository<BudgetCode>().Update(budgetCode);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = courseBudgetAllocation.CourseBudgetAllocationId;

            return response;
        }

    }
}
