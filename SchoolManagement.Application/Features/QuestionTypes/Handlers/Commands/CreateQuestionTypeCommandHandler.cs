using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.QuestionType.Validators;
using SchoolManagement.Application.Features.QuestionTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.QuestionTypes.Handlers.Commands
{
    public class CreateQuestionTypeCommandHandler : IRequestHandler<CreateQuestionTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateQuestionTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateQuestionTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateQuestionTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.QuestionTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var QuestionType = _mapper.Map<QuestionType>(request.QuestionTypeDto);

                QuestionType = await _unitOfWork.Repository<QuestionType>().Add(QuestionType);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = QuestionType.QuestionTypeId;
            }

            return response;
        }
    }
}
