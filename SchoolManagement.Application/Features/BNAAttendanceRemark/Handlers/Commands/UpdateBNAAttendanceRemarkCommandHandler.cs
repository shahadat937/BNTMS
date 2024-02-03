using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.BnaAttendanceRemark.Requests.Commands;
using SchoolManagement.Application.DTOs.BnaAttendanceRemarks.Validators;

namespace SchoolManagement.Application.Features.BnaAttendanceRemark.Handlers.Commands
{
    public class UpdateBnaAttendanceRemarkCommandHandler : IRequestHandler<UpdateBnaAttendanceRemarkCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBnaAttendanceRemarkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBnaAttendanceRemarkCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBnaAttendanceRemarkDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.BnaAttendanceRemarkDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BnaAttendanceRemark = await _unitOfWork.Repository<BnaAttendanceRemarks>().Get(request.BnaAttendanceRemarkDto.BnaAttendanceRemarksId);

            if (BnaAttendanceRemark is null)
                throw new NotFoundException(nameof(BnaAttendanceRemark), request.BnaAttendanceRemarkDto.BnaAttendanceRemarksId);

            _mapper.Map(request.BnaAttendanceRemarkDto, BnaAttendanceRemark);

            await _unitOfWork.Repository<BnaAttendanceRemarks>().Update(BnaAttendanceRemark);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
