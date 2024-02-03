using AutoMapper;
using SchoolManagement.Application.DTOs.BnaClassSchedule.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaClassSchedules.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassSchedules.Handlers.Commands
{
    public class UpdateBnaClassScheduleCommandHandler : IRequestHandler<UpdateBnaClassScheduleCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBnaClassScheduleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBnaClassScheduleCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBnaClassScheduleDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaClassScheduleDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BnaClassSchedules = await _unitOfWork.Repository<BnaClassSchedule>().Get(request.BnaClassScheduleDto.BnaClassScheduleId);

            if (BnaClassSchedules is null)
                throw new NotFoundException(nameof(BnaClassSchedule), request.BnaClassScheduleDto.BnaClassScheduleId);

            _mapper.Map(request.BnaClassScheduleDto, BnaClassSchedules);

            await _unitOfWork.Repository<BnaClassSchedule>().Update(BnaClassSchedules);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
