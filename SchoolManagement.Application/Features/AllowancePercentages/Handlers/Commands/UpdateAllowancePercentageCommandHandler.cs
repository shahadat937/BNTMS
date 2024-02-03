using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.AllowancePercentage.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.AllowancePercentages.Requests.Commands;

namespace SchoolManagement.Application.Features.AllowancePercentages.Handlers.Commands
{
    public class UpdateAllowancePercentageCommandHandler : IRequestHandler<UpdateAllowancePercentageCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAllowancePercentageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAllowancePercentageCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAllowancePercentageDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.AllowancePercentageDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var AllowancePercentage = await _unitOfWork.Repository<AllowancePercentage>().Get(request.AllowancePercentageDto.AllowancePercentageId);

            if (AllowancePercentage is null)
                throw new NotFoundException(nameof(AllowancePercentage), request.AllowancePercentageDto.AllowancePercentageId);

            _mapper.Map(request.AllowancePercentageDto, AllowancePercentage);

            await _unitOfWork.Repository<AllowancePercentage>().Update(AllowancePercentage);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
