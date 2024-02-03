using AutoMapper;
using SchoolManagement.Application.DTOs.CourseModule.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseModules.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseModules.Handlers.Commands
{
    public class UpdateCourseModuleCommandHandler : IRequestHandler<UpdateCourseModuleCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCourseModuleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCourseModuleCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCourseModuleDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CourseModuleDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var CourseModules = await _unitOfWork.Repository<CourseModule>().Get(request.CourseModuleDto.CourseModuleId);

            if (CourseModules is null)
                throw new NotFoundException(nameof(CourseModule), request.CourseModuleDto.CourseModuleId);

            _mapper.Map(request.CourseModuleDto, CourseModules);

            await _unitOfWork.Repository<CourseModule>().Update(CourseModules);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
