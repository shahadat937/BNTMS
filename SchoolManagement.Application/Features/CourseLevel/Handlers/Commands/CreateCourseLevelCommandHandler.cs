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
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.CourseLevels.Handlers.Commands
{
    public class CreateCourseLevelCommandHandler : IRequestHandler<CreateCourseLevelCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCourseLevelCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCourseLevelCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCourseLevelDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CourseLevelDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var CourseLevel = _mapper.Map<CourseLevel>(request.CourseLevelDto);

                CourseLevel = await _unitOfWork.Repository<CourseLevel>().Add(CourseLevel);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CourseLevel.CourseLevelId;
            }

            return response;
        }
    }
}
