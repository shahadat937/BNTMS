using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BudgetAllocation.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BudgetAllocations.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BudgetAllocations.Handler.Commands
{
    public class UpdateBudgetAllocationCommandHandler : IRequestHandler<UpdateBudgetAllocationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBudgetAllocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBudgetAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBudgetAllocationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BudgetAllocationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BudgetAllocation = await _unitOfWork.Repository<BudgetAllocation>().Get(request.BudgetAllocationDto.BudgetAllocationId);

            if (BudgetAllocation is null)
                throw new NotFoundException(nameof(BudgetAllocation), request.BudgetAllocationDto.BudgetAllocationId);

            _mapper.Map(request.BudgetAllocationDto, BudgetAllocation);

            await _unitOfWork.Repository<BudgetAllocation>().Update(BudgetAllocation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}