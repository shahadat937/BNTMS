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
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.CourseSections.Handlers.Commands
{
    public class CreateCourseSectionCommandHandler : IRequestHandler<CreateCourseSectionCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCourseSectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCourseSectionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCourseSectionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CourseSectionDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var CourseSections = _mapper.Map<CourseSection>(request.CourseSectionDto);

                CourseSections = await _unitOfWork.Repository<CourseSection>().Add(CourseSections);
                
                
                    await _unitOfWork.Save();
                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CourseSections.CourseSectionId;
            }

            return response;
        }
    }
}
