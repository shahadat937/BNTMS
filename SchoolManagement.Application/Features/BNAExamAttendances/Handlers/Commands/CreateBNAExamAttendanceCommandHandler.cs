using AutoMapper;
using SchoolManagement.Application.DTOs.BnaExamAttendance.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaExamAttendances.Requests.Commands;
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

namespace SchoolManagement.Application.Features.BnaExamAttendances.Handlers.Commands
{
    public class CreateBnaExamAttendanceCommandHandler : IRequestHandler<CreateBnaExamAttendanceCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBnaExamAttendanceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBnaExamAttendanceCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBnaExamAttendanceDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaExamAttendanceDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BnaExamAttendances = _mapper.Map<BnaExamAttendance>(request.BnaExamAttendanceDto);

                BnaExamAttendances = await _unitOfWork.Repository<BnaExamAttendance>().Add(BnaExamAttendances);
                
                    await _unitOfWork.Save();
                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BnaExamAttendances.BnaExamAttendanceId;
            }

            return response;
        }
    }
}
