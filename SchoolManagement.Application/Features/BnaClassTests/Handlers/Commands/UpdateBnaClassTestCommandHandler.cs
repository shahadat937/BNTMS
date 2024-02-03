using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.BnaClassTest.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaClassTests.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.BnaClassTests.Handlers.Commands
{
    public class UpdateBnaClassTestCommandHandler: IRequestHandler<UpdateBnaClassTestCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBnaClassTestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBnaClassTestCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBnaClassTestDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.BnaClassTestDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BnaClassTest = await _unitOfWork.Repository<BnaClassTest>().Get(request.BnaClassTestDto.BnaClassTestId);

            if (BnaClassTest is null)
                throw new NotFoundException(nameof(BnaClassTest), request.BnaClassTestDto.BnaClassTestId);

            _mapper.Map(request.BnaClassTestDto, BnaClassTest);

            await _unitOfWork.Repository<BnaClassTest>().Update(BnaClassTest);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
