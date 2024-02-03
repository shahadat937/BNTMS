using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ExamMarkRemarks.Validators;
using SchoolManagement.Application.Features.ExamMarkRemark.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamMarkRemark.Handlers.Commands
{
    public class CreateExamMarkRemarkCommandHandler : IRequestHandler<CreateExamMarkRemarkCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateExamMarkRemarkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateExamMarkRemarkCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateExamMarkRemarkDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ExamMarkRemarkDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ExamMarkRemark = _mapper.Map<ExamMarkRemarks>(request.ExamMarkRemarkDto);

                ExamMarkRemark = await _unitOfWork.Repository<ExamMarkRemarks>().Add(ExamMarkRemark);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ExamMarkRemark.ExamMarkRemarksId;
            }

            return response;
        }
    }
}
