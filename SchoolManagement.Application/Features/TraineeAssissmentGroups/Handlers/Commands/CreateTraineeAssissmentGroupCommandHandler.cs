using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeAssissmentGroup.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeAssissmentGroups.Requests.Commands;
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

namespace SchoolManagement.Application.Features.TraineeAssissmentGroups.Handlers.Commands
{
    public class CreateTraineeAssissmentGroupCommandHandler : IRequestHandler<CreateTraineeAssissmentGroupCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTraineeAssissmentGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTraineeAssissmentGroupCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTraineeAssissmentGroupDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TraineeAssissmentGroupDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var TraineeAssissmentGroups = _mapper.Map<TraineeAssissmentGroup>(request.TraineeAssissmentGroupDto);

                TraineeAssissmentGroups = await _unitOfWork.Repository<TraineeAssissmentGroup>().Add(TraineeAssissmentGroups);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = TraineeAssissmentGroups.TraineeAssissmentGroupId;
            }

            return response;
        }
    }
}
