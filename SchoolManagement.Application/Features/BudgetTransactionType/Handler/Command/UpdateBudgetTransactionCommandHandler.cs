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
            //throw new NotImplementedException();
            var validator = new UpdateBudgetTransactionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BudgetTransactionDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BudgetTransaction = await _unitOfWork.Repository<BudgetTransaction>().Get(request.BudgetTransactionDto.BudgetTransactionId);

            if (BudgetTransaction is null)
                throw new NotFoundException(nameof(BudgetTransaction), request.BudgetTransactionDto.BudgetTransactionId);

            _mapper.Map(request.BudgetTransactionDto, BudgetTransaction);

            await _unitOfWork.Repository<BudgetTransaction>().Update(BudgetTransaction);
            await _unitOfWork.Save();

            return Unit.Value;
        }

        //public async Task<Unit> Handler(UpdateBudgetTransactionCommand request, CancellationToken cancellationToken)
        //{
            
        //}


    }
}
