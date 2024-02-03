using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MarkCategory.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MarkCategorys.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MarkCategorys.Handler.Queries
{
    public class UpdateMarkCategoryCommandHandler : IRequestHandler<UpdateMarkCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMarkCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMarkCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMarkCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.MarkCategoryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var MarkCategory = await _unitOfWork.Repository<MarkCategory>().Get(request.MarkCategoryDto.MarkCategoryId);

            if (MarkCategory is null)
                throw new NotFoundException(nameof(MarkCategory), request.MarkCategoryDto.MarkCategoryId);

            _mapper.Map(request.MarkCategoryDto, MarkCategory);

            await _unitOfWork.Repository<MarkCategory>().Update(MarkCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}