using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ForceType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ForceTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForceTypes.Handlers.Commands
{
    public class UpdateForceTypeCommandHandler : IRequestHandler<UpdateForceTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateForceTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateForceTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateForceTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ForceTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ForceType = await _unitOfWork.Repository<ForceType>().Get(request.ForceTypeDto.ForceTypeId);

            if (ForceType is null)
                throw new NotFoundException(nameof(ForceType), request.ForceTypeDto.ForceTypeId);

            _mapper.Map(request.ForceTypeDto, ForceType);

            await _unitOfWork.Repository<ForceType>().Update(ForceType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
