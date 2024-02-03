using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ExamAttemptType.Validators;
using SchoolManagement.Application.Features.ExamAttemptTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamAttemptTypes.Handlers.Commands
{
    public class CreateExamAttemptTypeCommandHandler : IRequestHandler<CreateExamAttemptTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateExamAttemptTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateExamAttemptTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateExamAttemptTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ExamAttemptTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ExamAttemptType = _mapper.Map<ExamAttemptType>(request.ExamAttemptTypeDto);

                ExamAttemptType = await _unitOfWork.Repository<ExamAttemptType>().Add(ExamAttemptType);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ExamAttemptType.ExamAttemptTypeId;
            }

            return response;
        }
    }
}
