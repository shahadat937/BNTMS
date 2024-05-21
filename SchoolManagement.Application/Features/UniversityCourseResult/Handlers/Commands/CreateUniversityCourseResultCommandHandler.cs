using AutoMapper;
using SchoolManagement.Application.DTOs.UniversityCourseResult.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.UniversityCourseResults.Requests.Commands;
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

namespace SchoolManagement.Application.Features.UniversityCourseResults.Handlers.Commands
{
    public class CreateUniversityCourseResultCommandHandler : IRequestHandler<CreateUniversityCourseResultCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUniversityCourseResultCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateUniversityCourseResultCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateUniversityCourseResultDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UniversityCourseResultDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var UniversityCourseResult = _mapper.Map<UniversityCourseResult>(request.UniversityCourseResultDto);

                UniversityCourseResult = await _unitOfWork.Repository<UniversityCourseResult>().Add(UniversityCourseResult);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = UniversityCourseResult.UniversityCourseResultId;
            }

            return response;
        }
    }
}
