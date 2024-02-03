using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.JoiningReasons.Validators;
using SchoolManagement.Application.Features.JoiningReasons.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.JoiningReasons.Handlers.Commands
{
    public class CreateJoiningReasonCommandHandler : IRequestHandler<CreateJoiningReasonCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public CreateJoiningReasonCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateJoiningReasonCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateJoiningReasonDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.JoiningReasonDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var JoiningReason = _mapper.Map<JoiningReason>(request.JoiningReasonDto); 

                JoiningReason = await _unitOfWork.Repository<JoiningReason>().Add(JoiningReason);
                await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Creation Successful"; 
                response.Id = JoiningReason.JoiningReasonId;
            }

            return response;
        }
    }
}
