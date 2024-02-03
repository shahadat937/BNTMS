using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SaylorBranch.Validators;
using SchoolManagement.Application.Features.SaylorBranchs.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SaylorBranchs.Handlers.Commands
{
    public class CreateSaylorBranchCommandHandler : IRequestHandler<CreateSaylorBranchCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSaylorBranchCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSaylorBranchCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSaylorBranchDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SaylorBranchDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var SaylorBranch = _mapper.Map<SaylorBranch>(request.SaylorBranchDto);

                SaylorBranch = await _unitOfWork.Repository<SaylorBranch>().Add(SaylorBranch);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = SaylorBranch.SaylorBranchId;
            }

            return response;
        }
    }
}
