using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseGradingEntry.Validators;
using SchoolManagement.Application.Features.CourseGradingEntrys.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseGradingEntrys.Handlers.Commands
{
    public class CreateCourseGradingEntryCommandHandler : IRequestHandler<CreateCourseGradingEntryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCourseGradingEntryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCourseGradingEntryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCourseGradingEntryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CourseGradingEntryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var CourseGradingEntry = _mapper.Map<CourseGradingEntry>(request.CourseGradingEntryDto);

                CourseGradingEntry = await _unitOfWork.Repository<CourseGradingEntry>().Add(CourseGradingEntry);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CourseGradingEntry.CourseGradingEntryId;
            }

            return response;
        }
    }
}
