using AutoMapper;
using SchoolManagement.Application.DTOs.BnaExamSchedule.Validators;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;
using System;
using SchoolManagement.Application.Features.BnaExamSchedules.Requests.Commands;

namespace SchoolManagement.Application.Features.BnaExamSchedules.Handlers.Commands
{
    public class CreateBnaExamScheduleCommandHandler : IRequestHandler<CreateBnaExamScheduleCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBnaExamScheduleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBnaExamScheduleCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBnaExamScheduleDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaExamScheduleDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BnaExamSchedule = _mapper.Map<BnaExamSchedule>(request.BnaExamScheduleDto);

                BnaExamSchedule = await _unitOfWork.Repository<BnaExamSchedule>().Add(BnaExamSchedule);

                try
                {
                    await _unitOfWork.Save();
                } 
                catch (Exception ex) 
                {
                    System.Console.WriteLine(ex);
                }

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BnaExamSchedule.BnaExamScheduleId;
            }

            return response;
        }
    }
}
