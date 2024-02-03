using AutoMapper;
using SchoolManagement.Application.DTOs.BnaExamAttendance.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaExamAttendances.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaExamAttendances.Handlers.Commands
{
    public class UpdateBnaExamAttendanceCommandHandler : IRequestHandler<UpdateBnaExamAttendanceCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBnaExamAttendanceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBnaExamAttendanceCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBnaExamAttendanceDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaExamAttendanceDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BnaExamAttendances = await _unitOfWork.Repository<BnaExamAttendance>().Get(request.BnaExamAttendanceDto.BnaExamAttendanceId);

            if (BnaExamAttendances is null)
                throw new NotFoundException(nameof(BnaExamAttendance), request.BnaExamAttendanceDto.BnaExamAttendanceId);

            _mapper.Map(request.BnaExamAttendanceDto, BnaExamAttendances);

            await _unitOfWork.Repository<BnaExamAttendance>().Update(BnaExamAttendances);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
