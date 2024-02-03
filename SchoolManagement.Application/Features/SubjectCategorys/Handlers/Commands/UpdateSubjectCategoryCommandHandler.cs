using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.SubjectCategorys.Requests.Commands;
using SchoolManagement.Application.DTOs.SubjectCategorys.Validators;

namespace SchoolManagement.Application.Features.SubjectCategorys.Handlers.Commands
{
    public class UpdateSubjectCategoryCommandHandler : IRequestHandler<UpdateSubjectCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSubjectCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSubjectCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSubjectCategoryDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.SubjectCategoryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var SubjectCategory = await _unitOfWork.Repository<SubjectCategory>().Get(request.SubjectCategoryDto.SubjectCategoryId);

            if (SubjectCategory is null)
                throw new NotFoundException(nameof(SubjectCategory), request.SubjectCategoryDto.SubjectCategoryId);

            _mapper.Map(request.SubjectCategoryDto, SubjectCategory);

            await _unitOfWork.Repository<SubjectCategory>().Update(SubjectCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
