using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SaylorSubBranch.Validators;
using SchoolManagement.Application.Features.SaylorSubBranchs.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SaylorSubBranchs.Handlers.Commands
{
    public class CreateSaylorSubBranchCommandHandler : IRequestHandler<CreateSaylorSubBranchCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSaylorSubBranchCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSaylorSubBranchCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSaylorSubBranchDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SaylorSubBranchDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var SaylorSubBranch = _mapper.Map<SaylorSubBranch>(request.SaylorSubBranchDto);

                SaylorSubBranch = await _unitOfWork.Repository<SaylorSubBranch>().Add(SaylorSubBranch);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = SaylorSubBranch.SaylorSubBranchId;
            }

            return response;
        }
    }
}
