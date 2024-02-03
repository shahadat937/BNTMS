using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.BnaAttendancePeriod.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaAttendancePeriods.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.BnaAttendancePeriods.Handlers.Commands
{
    public class UpdateBnaAttendancePeriodCommandHandler: IRequestHandler<UpdateBnaAttendancePeriodCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBnaAttendancePeriodCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBnaAttendancePeriodCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBnaAttendancePeriodDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.BnaAttendancePeriodDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BnaAttendancePeriod = await _unitOfWork.Repository<BnaAttendancePeriod>().Get(request.BnaAttendancePeriodDto.BnaAttendancePeriodId);

            if (BnaAttendancePeriod is null)
                throw new NotFoundException(nameof(BnaAttendancePeriod), request.BnaAttendancePeriodDto.BnaAttendancePeriodId);

            _mapper.Map(request.BnaAttendancePeriodDto, BnaAttendancePeriod);

            await _unitOfWork.Repository<BnaAttendancePeriod>().Update(BnaAttendancePeriod);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
