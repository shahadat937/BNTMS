using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TraineeAssignmentSubmits.Requests.Commands;
using SchoolManagement.Application.DTOs.TraineeAssignmentSubmits.Validators;

namespace SchoolManagement.Application.Features.TraineeAssignmentSubmits.Handlers.Commands
{
    public class UpdateTraineeAssignmentSubmitCommandHandler : IRequestHandler<UpdateTraineeAssignmentSubmitCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTraineeAssignmentSubmitCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTraineeAssignmentSubmitCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTraineeAssignmentSubmitDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.TraineeAssignmentSubmitDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var TraineeAssignmentSubmit = await _unitOfWork.Repository<TraineeAssignmentSubmit>().Get(request.TraineeAssignmentSubmitDto.TraineeAssignmentSubmitId);

            if (TraineeAssignmentSubmit is null)
                throw new NotFoundException(nameof(TraineeAssignmentSubmit), request.TraineeAssignmentSubmitDto.TraineeAssignmentSubmitId);

            _mapper.Map(request.TraineeAssignmentSubmitDto, TraineeAssignmentSubmit);

            await _unitOfWork.Repository<TraineeAssignmentSubmit>().Update(TraineeAssignmentSubmit);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
