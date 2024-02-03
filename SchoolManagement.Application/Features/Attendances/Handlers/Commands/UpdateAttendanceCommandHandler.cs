using AutoMapper;
using SchoolManagement.Application.DTOs.Attendance.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Attendances.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Attendances.Handlers.Commands
{
    public class UpdateAttendanceCommandHandler : IRequestHandler<UpdateAttendanceCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAttendanceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAttendanceCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAttendanceDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AttendanceDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Attendances = await _unitOfWork.Repository<Attendance>().Get(request.AttendanceDto.AttendanceId);

            if (Attendances is null)
                throw new NotFoundException(nameof(Attendance), request.AttendanceDto.AttendanceId);

            _mapper.Map(request.AttendanceDto, Attendances);

            await _unitOfWork.Repository<Attendance>().Update(Attendances);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
