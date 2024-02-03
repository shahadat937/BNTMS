using AutoMapper;
using SchoolManagement.Application.DTOs.Attendance.Validators;
using SchoolManagement.Application.Features.Attendances.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.Attendances.Handlers.Commands
{
    public class CreateAttendanceCommandHandler : IRequestHandler<CreateAttendanceCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAttendanceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateAttendanceDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AttendanceDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Attendances = _mapper.Map<Attendance>(request.AttendanceDto);

                Attendances = await _unitOfWork.Repository<Attendance>().Add(Attendances);
                
                
                    await _unitOfWork.Save();


                //var routines = await _unitOfWork.Repository<ClassRoutine>().Get(request.AttendanceDto.ClassRoutineId.Value);

                //if (Attendances is null)
                //    throw new NotFoundException(nameof(Attendance), request.AttendanceDto.AttendanceId);

                //_mapper.Map(request.AttendanceDto, Attendances);

                //await _unitOfWork.Repository<Attendance>().Update(Attendances);
                //await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Attendances.AttendanceId;
            }

            return response;
        }
    }
}
