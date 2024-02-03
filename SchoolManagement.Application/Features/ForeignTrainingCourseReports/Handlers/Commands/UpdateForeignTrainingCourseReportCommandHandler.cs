using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ForeignTrainingCourseReport.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ForeignTrainingCourseReports.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignTrainingCourseReports.Handlers.Commands
{
    public class UpdateForeignTrainingCourseReportCommandHandler : IRequestHandler<UpdateForeignTrainingCourseReportCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateForeignTrainingCourseReportCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateForeignTrainingCourseReportCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateForeignTrainingCourseReportDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ForeignTrainingCourseReportDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ForeignTrainingCourseReport = await _unitOfWork.Repository<ForeignTrainingCourseReport>().Get(request.ForeignTrainingCourseReportDto.ForeignTrainingCourseReportid);

            if (ForeignTrainingCourseReport is null)
                throw new NotFoundException(nameof(ForeignTrainingCourseReport), request.ForeignTrainingCourseReportDto.ForeignTrainingCourseReportid);

            _mapper.Map(request.ForeignTrainingCourseReportDto, ForeignTrainingCourseReport);

            await _unitOfWork.Repository<ForeignTrainingCourseReport>().Update(ForeignTrainingCourseReport);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
