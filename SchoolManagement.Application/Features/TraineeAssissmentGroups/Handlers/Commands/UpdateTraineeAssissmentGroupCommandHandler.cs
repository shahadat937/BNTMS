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

namespace SchoolManagement.Application.Features.TraineeAssissmentGroups.Handlers.Commands
{
    public class UpdateTraineeAssissmentGroupCommandHandler : IRequestHandler<UpdateTraineeAssissmentGroupCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTraineeAssissmentGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTraineeAssissmentGroupCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTraineeAssissmentGroupDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TraineeAssissmentGroupDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var TraineeAssissmentGroups = await _unitOfWork.Repository<TraineeAssissmentGroup>().Get(request.TraineeAssissmentGroupDto.TraineeAssissmentGroupId);

            if (TraineeAssissmentGroups is null)
                throw new NotFoundException(nameof(TraineeAssissmentGroup), request.TraineeAssissmentGroupDto.TraineeAssissmentGroupId);

            _mapper.Map(request.TraineeAssissmentGroupDto, TraineeAssissmentGroups);

            await _unitOfWork.Repository<TraineeAssissmentGroup>().Update(TraineeAssissmentGroups);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
