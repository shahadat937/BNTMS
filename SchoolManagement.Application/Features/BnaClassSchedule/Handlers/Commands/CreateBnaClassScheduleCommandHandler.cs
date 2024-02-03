using AutoMapper;
using SchoolManagement.Application.DTOs.BnaClassSchedule.Validators;
using SchoolManagement.Application.Features.BnaClassSchedules.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.BnaClassSchedules.Handlers.Commands
{
    public class CreateBnaClassScheduleCommandHandler : IRequestHandler<CreateBnaClassScheduleCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBnaClassScheduleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBnaClassScheduleCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBnaClassScheduleDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaClassScheduleDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BnaClassSchedules = _mapper.Map<BnaClassSchedule>(request.BnaClassScheduleDto);

                BnaClassSchedules.Date = BnaClassSchedules.Date.Value.AddDays(1.0);

                BnaClassSchedules = await _unitOfWork.Repository<BnaClassSchedule>().Add(BnaClassSchedules);
                
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BnaClassSchedules.BnaClassScheduleId;
            }

            return response;
        }
    }
}
