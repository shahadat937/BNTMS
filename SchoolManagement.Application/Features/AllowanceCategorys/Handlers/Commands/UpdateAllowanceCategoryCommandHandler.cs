using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.AllowanceCategory.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.AllowanceCategorys.Requests.Commands;

namespace SchoolManagement.Application.Features.AllowanceCategorys.Handlers.Commands
{
    public class UpdateAllowanceCategoryCommandHandler : IRequestHandler<UpdateAllowanceCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAllowanceCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAllowanceCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAllowanceCategoryDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.AllowanceCategoryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var AllowanceCategory = await _unitOfWork.Repository<AllowanceCategory>().Get(request.AllowanceCategoryDto.AllowanceCategoryId);

            if (AllowanceCategory is null)
                throw new NotFoundException(nameof(AllowanceCategory), request.AllowanceCategoryDto.AllowanceCategoryId);

            _mapper.Map(request.AllowanceCategoryDto, AllowanceCategory);

            await _unitOfWork.Repository<AllowanceCategory>().Update(AllowanceCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
