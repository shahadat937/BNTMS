using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using SchoolManagement.Domain;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.BnaClassScheduleStatuss.Requests.Commands;
using SchoolManagement.Application.DTOs.BnaClassScheduleStatuses.Validators;

namespace SchoolManagement.Application.Features.BnaClassScheduleStatuss.Handlers.Commands
{
    public class UpdateBnaClassScheduleStatusCommandHandler : IRequestHandler<UpdateBnaClassScheduleStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBnaClassScheduleStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBnaClassScheduleStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBnaClassScheduleStatusDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.BnaClassScheduleStatusDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BnaClassScheduleStatus = await _unitOfWork.Repository<BnaClassScheduleStatus>().Get(request.BnaClassScheduleStatusDto.BnaClassScheduleStatusId);

            if (BnaClassScheduleStatus is null)
                throw new NotFoundException(nameof(BnaClassScheduleStatus), request.BnaClassScheduleStatusDto.BnaClassScheduleStatusId);

            _mapper.Map(request.BnaClassScheduleStatusDto, BnaClassScheduleStatus);

            await _unitOfWork.Repository<BnaClassScheduleStatus>().Update(BnaClassScheduleStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
