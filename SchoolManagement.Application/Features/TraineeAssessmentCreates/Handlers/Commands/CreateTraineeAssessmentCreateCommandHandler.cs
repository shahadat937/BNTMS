using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeAssessmentCreate.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeAssessmentCreates.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.TraineeAssessmentCreates.Handlers.Commands
{
    public class CreateTraineeAssessmentCreateCommandHandler : IRequestHandler<CreateTraineeAssessmentCreateCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTraineeAssessmentCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTraineeAssessmentCreateCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTraineeAssessmentCreateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TraineeAssessmentCreateDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var TraineeAssessmentCreates = _mapper.Map<TraineeAssessmentCreate>(request.TraineeAssessmentCreateDto);

                TraineeAssessmentCreates = await _unitOfWork.Repository<TraineeAssessmentCreate>().Add(TraineeAssessmentCreates);
                TraineeAssessmentCreates.StartDate = TraineeAssessmentCreates.StartDate.Value.AddDays(1.0);
                TraineeAssessmentCreates.EndDate = TraineeAssessmentCreates.EndDate.Value.AddDays(1.0);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = TraineeAssessmentCreates.TraineeAssessmentCreateId;
            }

            return response;
        }
    }
}
