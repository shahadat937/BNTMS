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
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.CourseTerms.Handlers.Commands
{
    public class CreateCourseTermCommandHandler : IRequestHandler<CreateCourseTermCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCourseTermCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCourseTermCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCourseTermDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CourseTermDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var CourseTerm = _mapper.Map<CourseTerm>(request.CourseTermDto);

                CourseTerm = await _unitOfWork.Repository<CourseTerm>().Add(CourseTerm);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CourseTerm.CourseTermId;
            }

            return response;
        }
    }
}
