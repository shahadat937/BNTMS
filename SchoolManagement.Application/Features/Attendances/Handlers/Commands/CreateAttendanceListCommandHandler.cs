using AutoMapper;
using SchoolManagement.Application.Features.Attendances.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.Constants;

namespace SchoolManagement.Application.Features.Attendances.Handlers.Commands
{
    public class CreateAttendanceListCommandHandler : IRequestHandler<CreateAttendanceListCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAttendanceListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateAttendanceListCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var attendances = _mapper.Map<List<Attendance>>(request.AttendanceListDto);

            foreach (var item in attendances)
            {
                if(item.AttendanceStatus == null)
                {
                    item.AttendanceStatus = false;
                    item.AbsentForExamStatus = true;

                    await _unitOfWork.Repository<Attendance>().Add(item);
                    await _unitOfWork.Save();
                }

                else 
                {
                    await _unitOfWork.Repository<Attendance>().Add(item);
                    await _unitOfWork.Save();
                }
            }

            var routines = await _unitOfWork.Repository<ClassRoutine>().Get(request.AttendanceListDto.Select(x=>x.ClassRoutineId.Value).FirstOrDefault());
            
            routines.AttendanceComplete = CompleteStatus.Completed; 

            await _unitOfWork.Repository<ClassRoutine>().Update(routines); 
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Creation Successful";

            return response;
        }
    }
}
