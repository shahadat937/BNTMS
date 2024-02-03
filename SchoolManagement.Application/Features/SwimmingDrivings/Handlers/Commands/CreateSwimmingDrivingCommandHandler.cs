using AutoMapper;
using SchoolManagement.Application.DTOs.SwimmingDriving.Validators;
using SchoolManagement.Application.Features.SwimmingDrivings.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.SwimmingDrivings.Handlers.Commands
{
    public class CreateSwimmingDrivingCommandHandler : IRequestHandler<CreateSwimmingDrivingCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSwimmingDrivingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSwimmingDrivingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSwimmingDrivingDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SwimmingDrivingDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {


                var SwimmingDrivings = _mapper.Map<SwimmingDriving>(request.SwimmingDrivingDto);

                SwimmingDrivings = await _unitOfWork.Repository<SwimmingDriving>().Add(SwimmingDrivings);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = SwimmingDrivings.SwimmingDrivingId;
            }

            return response;
        }
    }
}
