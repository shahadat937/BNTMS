using AutoMapper;
using SchoolManagement.Application.DTOs.GrandFatherType.Validators;
using SchoolManagement.Application.Features.GrandFatherTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.GrandFatherTypes.Handlers.Commands
{
    public class CreateGrandFatherTypeCommandHandler : IRequestHandler<CreateGrandFatherTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateGrandFatherTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateGrandFatherTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateGrandFatherTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.GrandFatherTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var GrandFatherType = _mapper.Map<GrandFatherType>(request.GrandFatherTypeDto);

                GrandFatherType = await _unitOfWork.Repository<GrandFatherType>().Add(GrandFatherType);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = GrandFatherType.GrandfatherTypeId;
            }

            return response;
        }
    }
}
