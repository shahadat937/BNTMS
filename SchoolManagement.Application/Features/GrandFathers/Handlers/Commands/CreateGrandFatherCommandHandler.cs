using AutoMapper;
using SchoolManagement.Application.DTOs.GrandFather.Validators;
using SchoolManagement.Application.Features.GrandFathers.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.GrandFathers.Handlers.Commands
{
    public class CreateGrandFatherCommandHandler : IRequestHandler<CreateGrandFatherCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateGrandFatherCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateGrandFatherCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateGrandFatherDtoValidator();
            var validationResult = await validator.ValidateAsync(request.GrandFatherDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var GrandFather = _mapper.Map<GrandFather>(request.GrandFatherDto);

                GrandFather = await _unitOfWork.Repository<GrandFather>().Add(GrandFather);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = GrandFather.GrandFatherId;
            }

            return response;
        }
    }
}
