using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseWeekAll.Validators;
using SchoolManagement.Application.DTOs.CourseWeeks.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseWeekAll.Requests.Commands;
using SchoolManagement.Application.Features.CourseWeeks.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement.Domain;
using FluentValidation;

namespace SchoolManagement.Application.Features.CourseWeekAll.Handlers.Commands
{
    public class UpdateCourseWeekAllCommandHandler : IRequestHandler<UpdateCourseWeekAllCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateCourseWeekAllCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCourseWeekAllCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCourseWeekAllDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CourseWeekAllDto);

          //  if (validationResult.IsValid == false)
             //   throw new ValidationException(validationResult);

            var CourseWeek = await _unitOfWork.Repository<SchoolManagement.Domain.CourseWeekAll>().Get(request.CourseWeekAllDto.WeekID);

            if (CourseWeek is null)
                throw new NotFoundException(nameof(CourseWeek), request.CourseWeekAllDto.WeekID);

            _mapper.Map(request.CourseWeekAllDto, CourseWeek);

            await _unitOfWork.Repository<SchoolManagement.Domain.CourseWeekAll>().Update(CourseWeek);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
