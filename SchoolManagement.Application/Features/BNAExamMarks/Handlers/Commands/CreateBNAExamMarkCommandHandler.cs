using AutoMapper;
using SchoolManagement.Application.DTOs.BnaExamMark.Validators;
using SchoolManagement.Application.Exceptions;
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
using SchoolManagement.Application.Features.BnaExamMarks.Requests.Commands;

namespace SchoolManagement.Application.Features.BnaExamMarks.Handlers.Commands
{
    public class CreateBnaExamMarkCommandHandler : IRequestHandler<CreateBnaExamMarkCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBnaExamMarkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBnaExamMarkCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBnaExamMarkDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaExamMarkDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BnaExamMarks = _mapper.Map<BnaExamMark>(request.BnaExamMarkDto);

                BnaExamMarks = await _unitOfWork.Repository<BnaExamMark>().Add(BnaExamMarks);
                BnaExamMarks.SubmissionStatus = 0;
                try
                {
                    await _unitOfWork.Save();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BnaExamMarks.BnaExamMarkId;
            }

            return response;
        }
    }
}
