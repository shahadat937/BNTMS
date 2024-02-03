using AutoMapper;
using SchoolManagement.Application.DTOs.EmploymentBeforeJoinBna.Validators;
using SchoolManagement.Application.Features.EmploymentBeforeJoinBnas.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.EmploymentBeforeJoinBnas.Handlers.Commands
{
    public class CreateEmploymentBeforeJoinBnaCommandHandler : IRequestHandler<CreateEmploymentBeforeJoinBnaCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateEmploymentBeforeJoinBnaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateEmploymentBeforeJoinBnaCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateEmploymentBeforeJoinBnaDtoValidator();
            var validationResult = await validator.ValidateAsync(request.EmploymentBeforeJoinBnaDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var EmploymentBeforeJoinBnas = _mapper.Map<EmploymentBeforeJoinBna>(request.EmploymentBeforeJoinBnaDto);

                EmploymentBeforeJoinBnas = await _unitOfWork.Repository<EmploymentBeforeJoinBna>().Add(EmploymentBeforeJoinBnas);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = EmploymentBeforeJoinBnas.EmploymentBeforeJoinBnaId;
            }

            return response;
        }
    }
}
