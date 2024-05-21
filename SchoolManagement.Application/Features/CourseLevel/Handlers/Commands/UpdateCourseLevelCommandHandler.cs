using AutoMapper;
using SchoolManagement.Application.DTOs.CourseLevel.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseLevels.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseLevels.Handlers.Commands
{
    public class UpdateCourseLevelCommandHandler : IRequestHandler<UpdateCourseLevelCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCourseLevelCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCourseLevelCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCourseLevelDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CourseLevelDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var CourseLevel = await _unitOfWork.Repository<CourseLevel>().Get(request.CourseLevelDto.CourseLevelId);

            if (CourseLevel is null)
                throw new NotFoundException(nameof(CourseLevel), request.CourseLevelDto.CourseLevelId);

            _mapper.Map(request.CourseLevelDto, CourseLevel);

            await _unitOfWork.Repository<CourseLevel>().Update(CourseLevel);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
