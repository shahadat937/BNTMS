using AutoMapper;
using SchoolManagement.Application.DTOs.CourseSection.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseSections.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseSections.Handlers.Commands
{
    public class UpdateCourseSectionCommandHandler : IRequestHandler<UpdateCourseSectionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCourseSectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCourseSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCourseSectionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CourseSectionDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var CourseSections = await _unitOfWork.Repository<CourseSection>().Get(request.CourseSectionDto.CourseSectionId);

            if (CourseSections is null)
                throw new NotFoundException(nameof(CourseSection), request.CourseSectionDto.CourseSectionId);

            _mapper.Map(request.CourseSectionDto, CourseSections);

            await _unitOfWork.Repository<CourseSection>().Update(CourseSections);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
