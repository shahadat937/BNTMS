using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.BudgetCode.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BudgetCodess.Requests.Commands;

namespace SchoolManagement.Application.Features.BudgetCodess.Handlers.Commands
{
    public class UpdateBudgetCodeCommandHandler : IRequestHandler<UpdateBudgetCodeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBudgetCodeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBudgetCodeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBudgetCodeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.BudgetCodeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BudgetCode = await _unitOfWork.Repository<BudgetCode>().Get(request.BudgetCodeDto.BudgetCodeId);

            if (BudgetCode is null)
                throw new NotFoundException(nameof(BudgetCode), request.BudgetCodeDto.BudgetCodeId);

            _mapper.Map(request.BudgetCodeDto, BudgetCode);

            await _unitOfWork.Repository<BudgetCode>().Update(BudgetCode);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
