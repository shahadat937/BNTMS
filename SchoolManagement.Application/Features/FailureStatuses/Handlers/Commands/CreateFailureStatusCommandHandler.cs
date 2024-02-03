using AutoMapper;
using SchoolManagement.Application.DTOs.FailureStatus.Validators;
using SchoolManagement.Application.Features.FailureStatuses.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.FailureStatuses.Handlers.Commands
{
    public class CreateFailureStatusCommandHandler : IRequestHandler<CreateFailureStatusCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFailureStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateFailureStatusCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateFailureStatusDtoValidator();
            var validationResult = await validator.ValidateAsync(request.FailureStatusDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var FailureStatus = _mapper.Map<FailureStatus>(request.FailureStatusDto);

                FailureStatus = await _unitOfWork.Repository<FailureStatus>().Add(FailureStatus);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = FailureStatus.FailureStatusId;
            }

            return response;
        }
    }
}
