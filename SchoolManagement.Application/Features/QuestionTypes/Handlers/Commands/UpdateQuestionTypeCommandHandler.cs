using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.QuestionType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.QuestionTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.QuestionTypes.Handlers.Commands
{
    public class UpdateQuestionTypeCommandHandler : IRequestHandler<UpdateQuestionTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateQuestionTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateQuestionTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateQuestionTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.QuestionTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var QuestionType = await _unitOfWork.Repository<QuestionType>().Get(request.QuestionTypeDto.QuestionTypeId);

            if (QuestionType is null)
                throw new NotFoundException(nameof(QuestionType), request.QuestionTypeDto.QuestionTypeId);

            _mapper.Map(request.QuestionTypeDto, QuestionType);

            await _unitOfWork.Repository<QuestionType>().Update(QuestionType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
