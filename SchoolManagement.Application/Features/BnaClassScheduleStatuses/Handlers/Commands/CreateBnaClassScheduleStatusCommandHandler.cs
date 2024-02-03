using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaClassScheduleStatuses.Validators;
using SchoolManagement.Application.Features.BnaClassScheduleStatuss.Requests.Commands;
using SchoolManagement.Application.Responses;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaClassScheduleStatues.Handlers.Commands
{
    public class CreateBnaClassScheduleStatusCommandHandler : IRequestHandler<CreateBnaClassScheduleStatusCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBnaClassScheduleStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBnaClassScheduleStatusCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBnaClassScheduleStatusDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaClassScheduleStatusDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BnaClassScheduleStatus = _mapper.Map<BnaClassScheduleStatus>(request.BnaClassScheduleStatusDto);

                BnaClassScheduleStatus = await _unitOfWork.Repository<BnaClassScheduleStatus>().Add(BnaClassScheduleStatus);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BnaClassScheduleStatus.BnaClassScheduleStatusId;
            }

            return response;
        }
    }
}
