using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaAttendanceRemarks.Validators;
using SchoolManagement.Application.Features.BnaAttendanceRemark.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaAttendanceRemark.Handlers.Commands
{
    public class CreateBnaAttendanceRemarkCommandHandler : IRequestHandler<CreateBnaAttendanceRemarkCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBnaAttendanceRemarkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBnaAttendanceRemarkCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateBnaAttendanceRemarkDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaAttendanceRemarkDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BnaAttendanceRemark = _mapper.Map<BnaAttendanceRemarks>(request.BnaAttendanceRemarkDto);

                BnaAttendanceRemark = await _unitOfWork.Repository<BnaAttendanceRemarks>().Add(BnaAttendanceRemark);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BnaAttendanceRemark.BnaAttendanceRemarksId;
            } 

            return response;
        }
    }
}
