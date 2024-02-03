using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.TdecGroupResult.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TdecGroupResults.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.TdecGroupResults.Handlers.Commands
{
    public class UpdateTdecGroupResultCommandHandler : IRequestHandler<UpdateTdecGroupResultCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTdecGroupResultCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTdecGroupResultCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTdecGroupResultDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.TdecGroupResultDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var TdecGroupResult = await _unitOfWork.Repository<TdecGroupResult>().Get(request.TdecGroupResultDto.TdecGroupResultId);

            if (TdecGroupResult is null)
                throw new NotFoundException(nameof(TdecGroupResult), request.TdecGroupResultDto.TdecGroupResultId);

            _mapper.Map(request.TdecGroupResultDto, TdecGroupResult);

            await _unitOfWork.Repository<TdecGroupResult>().Update(TdecGroupResult);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
