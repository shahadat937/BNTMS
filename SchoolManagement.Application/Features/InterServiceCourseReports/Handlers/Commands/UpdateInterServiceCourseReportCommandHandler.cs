using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.InterServiceCourseReport.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.InterServiceCourseReports.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InterServiceCourseReports.Handlers.Commands
{
    public class UpdateInterServiceCourseReportCommandHandler : IRequestHandler<UpdateInterServiceCourseReportCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateInterServiceCourseReportCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateInterServiceCourseReportCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateInterServiceCourseReportDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.InterServiceCourseReportDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var InterServiceCourseReport = await _unitOfWork.Repository<InterServiceCourseReport>().Get(request.InterServiceCourseReportDto.InterServiceCourseReportid);

            if (InterServiceCourseReport is null)
                throw new NotFoundException(nameof(InterServiceCourseReport), request.InterServiceCourseReportDto.InterServiceCourseReportid);

            _mapper.Map(request.InterServiceCourseReportDto, InterServiceCourseReport);

            await _unitOfWork.Repository<InterServiceCourseReport>().Update(InterServiceCourseReport);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
