using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeVisitedAboard.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeVisitedAboards.Requests.Commands;
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

namespace SchoolManagement.Application.Features.TraineeVisitedAboards.Handlers.Commands
{
    public class CreateTraineeVisitedAboardCommandHandler : IRequestHandler<CreateTraineeVisitedAboardCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTraineeVisitedAboardCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTraineeVisitedAboardCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTraineeVisitedAboardDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TraineeVisitedAboardDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var TraineeVisitedAboards = _mapper.Map<TraineeVisitedAboard>(request.TraineeVisitedAboardDto);

                TraineeVisitedAboards = await _unitOfWork.Repository<TraineeVisitedAboard>().Add(TraineeVisitedAboards);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = TraineeVisitedAboards.TraineeVisitedAboardId;
            }

            return response;
        }
    }
}
