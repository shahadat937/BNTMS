using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.BudgetType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BudgetTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.BudgetTypes.Handlers.Commands
{
    public class UpdateBudgetTypeCommandHandler : IRequestHandler<UpdateBudgetTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBudgetTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBudgetTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBudgetTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.BudgetTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BudgetType = await _unitOfWork.Repository<BudgetType>().Get(request.BudgetTypeDto.BudgetTypeId);

            if (BudgetType is null)
                throw new NotFoundException(nameof(BudgetType), request.BudgetTypeDto.BudgetTypeId);

            _mapper.Map(request.BudgetTypeDto, BudgetType);

            await _unitOfWork.Repository<BudgetType>().Update(BudgetType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
