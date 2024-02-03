using AutoMapper;
using SchoolManagement.Application.DTOs.ClassRoutine.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Commands;
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
using SchoolManagement.Application.Constants;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Commands
{
    public class CreateClassRoutineCommandHandler : IRequestHandler<CreateClassRoutineCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateClassRoutineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateClassRoutineCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateClassRoutineDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ClassRoutineDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {

               var ClassRoutines = _mapper.Map<ClassRoutine>(request.ClassRoutineDto);
              
               ClassRoutines.Date = ClassRoutines.Date.Value.AddDays(1.0);

               ClassRoutines.AttendanceComplete = CompleteStatus.NotCompleted;
               ClassRoutines.ResultSubmissionStatus = 0;
               ClassRoutines.FinalApproveStatus = 0;
                
               ClassRoutines = await _unitOfWork.Repository<ClassRoutine>().Add(ClassRoutines);

                try
                {
                    await _unitOfWork.Save();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ClassRoutines.ClassRoutineId;
            }

            return response;
        }
    }
}
