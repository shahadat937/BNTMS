using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TrainingObjective.Validators;
using SchoolManagement.Application.Features.TrainingObjectives.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TrainingObjectives.Handlers.Commands
{
    public class CreateTrainingObjectiveCommandHandler : IRequestHandler<CreateTrainingObjectiveCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTrainingObjectiveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTrainingObjectiveCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTrainingObjectiveDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TrainingObjectiveDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var TrainingObjective = _mapper.Map<TrainingObjective>(request.TrainingObjectiveDto);
                TrainingObjective.Status = 0;
                TrainingObjective = await _unitOfWork.Repository<TrainingObjective>().Add(TrainingObjective);
               
                    await _unitOfWork.Save();
                
                    


                //var courseTasks = await _unitOfWork.Repository<CourseTask>().Get((int)request.TrainingObjectiveDto.CourseTaskId);

                //courseTasks.Status = 1;

                //await _unitOfWork.Repository<CourseTask>().Update(courseTasks);
              
                //    await _unitOfWork.Save();
                
                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = TrainingObjective.TrainingObjectiveId;
            }

            return response;
        }
    }
}
