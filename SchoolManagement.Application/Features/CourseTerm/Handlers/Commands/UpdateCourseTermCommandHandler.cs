using AutoMapper;
using SchoolManagement.Application.DTOs.CourseTerm.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseTerms.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseTerms.Handlers.Commands
{
    public class UpdateCourseTermCommandHandler : IRequestHandler<UpdateCourseTermCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCourseTermCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCourseTermCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCourseTermDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CourseTermDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var CourseTerm = await _unitOfWork.Repository<CourseTerm>().Get(request.CourseTermDto.CourseTermId);

            if (CourseTerm is null)
                throw new NotFoundException(nameof(CourseTerm), request.CourseTermDto.CourseTermId);

            _mapper.Map(request.CourseTermDto, CourseTerm);

            await _unitOfWork.Repository<CourseTerm>().Update(CourseTerm);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
