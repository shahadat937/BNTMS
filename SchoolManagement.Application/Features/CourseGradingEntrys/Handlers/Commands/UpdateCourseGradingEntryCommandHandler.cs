using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.CourseGradingEntry.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseGradingEntrys.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseGradingEntrys.Handlers.Commands
{
    public class UpdateCourseGradingEntryCommandHandler : IRequestHandler<UpdateCourseGradingEntryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCourseGradingEntryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCourseGradingEntryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCourseGradingEntryDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.CourseGradingEntryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var CourseGradingEntry = await _unitOfWork.Repository<CourseGradingEntry>().Get(request.CourseGradingEntryDto.CourseGradingEntryId);

            if (CourseGradingEntry is null)
                throw new NotFoundException(nameof(CourseGradingEntry), request.CourseGradingEntryDto.CourseGradingEntryId);

            _mapper.Map(request.CourseGradingEntryDto, CourseGradingEntry);

            await _unitOfWork.Repository<CourseGradingEntry>().Update(CourseGradingEntry);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
