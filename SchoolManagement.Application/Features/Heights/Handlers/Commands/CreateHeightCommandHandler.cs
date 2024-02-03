using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Height.Validators;
using SchoolManagement.Application.Features.Heights.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Heights.Handler.Commands
{
    public class CreateHeightCommandHandler : IRequestHandler<CreateHeightsCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
          
        public CreateHeightCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
        }
        public async Task<BaseCommandResponse> Handle(CreateHeightsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateHeightDtoValidator();
            var validationResult = await validator.ValidateAsync(request.HeightDto); 

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var height = _mapper.Map<Height>(request.HeightDto); 

                height = await _unitOfWork.Repository<Height>().Add(height);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = height.HeightId;
            }

            return response;
        }
    }
}
