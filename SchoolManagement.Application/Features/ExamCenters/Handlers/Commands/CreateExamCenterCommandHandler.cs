using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ExamCenter.Validators;
using SchoolManagement.Application.Features.ExamCenters.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamCenters.Handlers.Commands
{
    public class CreateExamCenterCommandHandler : IRequestHandler<CreateExamCenterCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateExamCenterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateExamCenterCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateExamCenterDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ExamCenterDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ExamCenter = _mapper.Map<ExamCenter>(request.ExamCenterDto);

                ExamCenter = await _unitOfWork.Repository<ExamCenter>().Add(ExamCenter);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ExamCenter.ExamCenterId;
            }

            return response;
        }
    }
}
