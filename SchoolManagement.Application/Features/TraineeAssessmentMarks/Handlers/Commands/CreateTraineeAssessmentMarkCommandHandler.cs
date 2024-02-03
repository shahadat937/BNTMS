using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeAssessmentMark.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeAssessmentMarks.Requests.Commands;
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

namespace SchoolManagement.Application.Features.TraineeAssessmentMarks.Handlers.Commands
{
    public class CreateTraineeAssessmentMarkCommandHandler : IRequestHandler<CreateTraineeAssessmentMarkCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTraineeAssessmentMarkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTraineeAssessmentMarkCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTraineeAssessmentMarkDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TraineeAssessmentMarkDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var TraineeAssessmentMarks = _mapper.Map<TraineeAssessmentMark>(request.TraineeAssessmentMarkDto);
                try
                {

                    TraineeAssessmentMarks = await _unitOfWork.Repository<TraineeAssessmentMark>().Add(TraineeAssessmentMarks);
                    await _unitOfWork.Save();
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = TraineeAssessmentMarks.TraineeAssessmentMarkId;
            }

            return response;
        }
    }
}
