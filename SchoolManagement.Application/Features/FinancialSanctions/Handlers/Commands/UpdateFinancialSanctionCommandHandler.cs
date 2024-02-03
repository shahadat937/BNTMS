using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.FinancialSanctions.Requests.Commands;
using SchoolManagement.Application.DTOs.FinancialSanction.Validators;

namespace SchoolManagement.Application.Features.FinancialSanctions.Handlers.Commands
{
    public class UpdateFinancialSanctionCommandHandler : IRequestHandler<UpdateFinancialSanctionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateFinancialSanctionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateFinancialSanctionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFinancialSanctionDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.FinancialSanctionDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var FinancialSanction = await _unitOfWork.Repository<FinancialSanction>().Get(request.FinancialSanctionDto.FinancialSanctionId);

            if (FinancialSanction is null)
                throw new NotFoundException(nameof(FinancialSanction), request.FinancialSanctionDto.FinancialSanctionId);

            _mapper.Map(request.FinancialSanctionDto, FinancialSanction);

            await _unitOfWork.Repository<FinancialSanction>().Update(FinancialSanction);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
