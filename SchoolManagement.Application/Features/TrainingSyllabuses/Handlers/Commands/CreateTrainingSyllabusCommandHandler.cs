using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TrainingSyllabus.Validators;
using SchoolManagement.Application.Features.TrainingSyllabuss.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TrainingSyllabuss.Handlers.Commands
{
    public class CreateTrainingSyllabusCommandHandler : IRequestHandler<CreateTrainingSyllabusCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTrainingSyllabusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTrainingSyllabusCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTrainingSyllabusDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TrainingSyllabusDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var TrainingSyllabus = _mapper.Map<TrainingSyllabus>(request.TrainingSyllabusDto);

                TrainingSyllabus = await _unitOfWork.Repository<TrainingSyllabus>().Add(TrainingSyllabus);
                
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = TrainingSyllabus.TrainingSyllabusId;
            }

            return response;
        }
    }
}
