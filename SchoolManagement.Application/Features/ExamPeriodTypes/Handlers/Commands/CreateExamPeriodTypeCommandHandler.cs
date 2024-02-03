using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ExamPeriodTypes.Validators;
using SchoolManagement.Application.Features.ExamPeriodTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamPeriodTypes.Handlers.Commands
{
    public class CreateExamPeriodTypeCommandHandler : IRequestHandler<CreateExamPeriodTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateExamPeriodTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateExamPeriodTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateExamPeriodTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ExamPeriodTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ExamPeriodType = _mapper.Map<ExamPeriodType>(request.ExamPeriodTypeDto);

                ExamPeriodType = await _unitOfWork.Repository<ExamPeriodType>().Add(ExamPeriodType);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ExamPeriodType.ExamPeriodTypeId;
            }

            return response;
        }
    }
}
