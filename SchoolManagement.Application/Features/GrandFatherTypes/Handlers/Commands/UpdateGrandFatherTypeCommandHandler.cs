using AutoMapper;
using SchoolManagement.Application.DTOs.GrandFatherType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.GrandFatherTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GrandFatherTypes.Handlers.Commands
{
    public class UpdateGrandFatherTypeCommandHandler : IRequestHandler<UpdateGrandFatherTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGrandFatherTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateGrandFatherTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateGrandFatherTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.GrandFatherTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var GrandFatherType = await _unitOfWork.Repository<GrandFatherType>().Get(request.GrandFatherTypeDto.GrandfatherTypeId);

            if (GrandFatherType is null)
                throw new NotFoundException(nameof(GrandFatherType), request.GrandFatherTypeDto.GrandfatherTypeId);

            _mapper.Map(request.GrandFatherTypeDto, GrandFatherType);

            await _unitOfWork.Repository<GrandFatherType>().Update(GrandFatherType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
