using AutoMapper;
using SchoolManagement.Application.DTOs.Question.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Questions.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Questions.Handlers.Commands
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateQuestionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateQuestionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.QuestionDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Questions = await _unitOfWork.Repository<Question>().Get(request.QuestionDto.QuestionId);

            if (Questions is null)
                throw new NotFoundException(nameof(Question), request.QuestionDto.QuestionId);

            _mapper.Map(request.QuestionDto, Questions);

            await _unitOfWork.Repository<Question>().Update(Questions);
            try
            {
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
           

            return Unit.Value;
        }
    }
}
