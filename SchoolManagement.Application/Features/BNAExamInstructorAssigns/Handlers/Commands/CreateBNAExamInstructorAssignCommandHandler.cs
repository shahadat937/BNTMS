using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaExamInstructorAssign.Validators;
using SchoolManagement.Application.Features.BnaExamInstructorAssigns.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaExamInstructorAssigns.Handlers.Commands
{
    public class CreateBnaExamInstructorAssignCommandHandler : IRequestHandler<CreateBnaExamInstructorAssignCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBnaExamInstructorAssignCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBnaExamInstructorAssignCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBnaExamInstructorAssignDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaExamInstructorAssignDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BnaExamInstructorAssign = _mapper.Map<BnaExamInstructorAssign>(request.BnaExamInstructorAssignDto);

                BnaExamInstructorAssign = await _unitOfWork.Repository<BnaExamInstructorAssign>().Add(BnaExamInstructorAssign);

                await _unitOfWork.Save();
             
                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BnaExamInstructorAssign.BnaExamInstructorAssignId;
            }

            return response;
        }
    }
}
