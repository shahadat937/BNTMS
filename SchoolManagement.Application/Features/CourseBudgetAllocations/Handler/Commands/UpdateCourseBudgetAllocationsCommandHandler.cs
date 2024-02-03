using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseBudgetAllocation.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Handler.Commands
{
    public class UpdateCourseBudgetAllocationCommandHandler : IRequestHandler<UpdateCourseBudgetAllocationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCourseBudgetAllocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCourseBudgetAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCourseBudgetAllocationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CourseBudgetAllocationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var CourseBudgetAllocation = await _unitOfWork.Repository<CourseBudgetAllocation>().Get(request.CourseBudgetAllocationDto.CourseBudgetAllocationId);

            if (CourseBudgetAllocation is null)
                throw new NotFoundException(nameof(CourseBudgetAllocation), request.CourseBudgetAllocationDto.CourseBudgetAllocationId);

            _mapper.Map(request.CourseBudgetAllocationDto, CourseBudgetAllocation);

            await _unitOfWork.Repository<CourseBudgetAllocation>().Update(CourseBudgetAllocation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}