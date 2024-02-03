using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MarkType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MarkTypes.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MarkTypes.Handler.Queries
{
    public class UpdateMarkTypeCommandHandler : IRequestHandler<UpdateMarkTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMarkTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMarkTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMarkTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.MarkTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var MarkType = await _unitOfWork.Repository<MarkType>().Get(request.MarkTypeDto.MarkTypeId);

            if (MarkType is null)
                throw new NotFoundException(nameof(MarkType), request.MarkTypeDto.MarkTypeId);

            _mapper.Map(request.MarkTypeDto, MarkType);

            await _unitOfWork.Repository<MarkType>().Update(MarkType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}