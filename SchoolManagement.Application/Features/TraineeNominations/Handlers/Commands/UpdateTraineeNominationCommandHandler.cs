using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeNomination.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Commands
{
    public class UpdateTraineeNominationCommandHandler : IRequestHandler<UpdateTraineeNominationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTraineeNominationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTraineeNominationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTraineeNominationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TraineeNominationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var TraineeNominations = await _unitOfWork.Repository<TraineeNomination>().Get(request.TraineeNominationDto.TraineeNominationId);

            if (TraineeNominations is null)
                throw new NotFoundException(nameof(TraineeNomination), request.TraineeNominationDto.TraineeNominationId);

            //_mapper.Map(request.TraineeNominationDto, TraineeNominations);

            TraineeNominations.CourseAttendState = request.TraineeNominationDto.CourseAttendState;
            TraineeNominations.CourseAttendStateRemark = request.TraineeNominationDto.CourseAttendStateRemark;



            await _unitOfWork.Repository<TraineeNomination>().Update(TraineeNominations);
            try
            {
               await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return Unit.Value;
        }
    }
}
