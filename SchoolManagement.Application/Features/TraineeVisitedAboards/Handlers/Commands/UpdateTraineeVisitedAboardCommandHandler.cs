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

namespace SchoolManagement.Application.Features.TraineeVisitedAboards.Handlers.Commands
{
    public class UpdateTraineeVisitedAboardCommandHandler : IRequestHandler<UpdateTraineeVisitedAboardCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTraineeVisitedAboardCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTraineeVisitedAboardCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTraineeVisitedAboardDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TraineeVisitedAboardDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var TraineeVisitedAboards = await _unitOfWork.Repository<TraineeVisitedAboard>().Get(request.TraineeVisitedAboardDto.TraineeVisitedAboardId);

            if (TraineeVisitedAboards is null)
                throw new NotFoundException(nameof(TraineeVisitedAboard), request.TraineeVisitedAboardDto.TraineeVisitedAboardId);

            _mapper.Map(request.TraineeVisitedAboardDto, TraineeVisitedAboards);

            await _unitOfWork.Repository<TraineeVisitedAboard>().Update(TraineeVisitedAboards);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
