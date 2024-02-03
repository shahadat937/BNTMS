using AutoMapper;
using SchoolManagement.Application.DTOs.PresentBillet.Validators;
using SchoolManagement.Application.Features.PresentBillets.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.PresentBillets.Handlers.Commands
{
    public class CreatePresentBilletCommandHandler : IRequestHandler<CreatePresentBilletCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePresentBilletCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreatePresentBilletCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreatePresentBilletDtoValidator();
            var validationResult = await validator.ValidateAsync(request.PresentBilletDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var PresentBillets = _mapper.Map<PresentBillet>(request.PresentBilletDto);

                PresentBillets = await _unitOfWork.Repository<PresentBillet>().Add(PresentBillets);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = PresentBillets.PresentBilletId;
            }

            return response;
        }
    }
}
