using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.FinancialSanction.Validators;
using SchoolManagement.Application.Features.FinancialSanctions.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FinancialSanctions.Handlers.Commands
{
    public class CreateFinancialSanctionCommandHandler : IRequestHandler<CreateFinancialSanctionCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFinancialSanctionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateFinancialSanctionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateFinancialSanctionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.FinancialSanctionDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var FinancialSanction = _mapper.Map<FinancialSanction>(request.FinancialSanctionDto);

                FinancialSanction = await _unitOfWork.Repository<FinancialSanction>().Add(FinancialSanction);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = FinancialSanction.FinancialSanctionId;
            }

            return response;
        }
    }
}
