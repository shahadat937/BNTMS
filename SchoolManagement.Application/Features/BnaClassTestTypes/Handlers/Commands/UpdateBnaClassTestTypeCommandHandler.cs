using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.BnaClassTestType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaClassTestTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.BnaClassTestTypes.Handlers.Commands
{
    public class UpdateBnaClassTestTypeCommandHandler: IRequestHandler<UpdateBnaClassTestTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBnaClassTestTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBnaClassTestTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBnaClassTestTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.BnaClassTestTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BnaClassTestType = await _unitOfWork.Repository<BnaClassTestType>().Get(request.BnaClassTestTypeDto.BnaClassTestTypeId);

            if (BnaClassTestType is null)
                throw new NotFoundException(nameof(BnaClassTestType), request.BnaClassTestTypeDto.BnaClassTestTypeId);

            _mapper.Map(request.BnaClassTestTypeDto, BnaClassTestType);

            await _unitOfWork.Repository<BnaClassTestType>().Update(BnaClassTestType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
