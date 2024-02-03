using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.OrganizationName.Validators;
using SchoolManagement.Application.Features.OrganizationNames.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OrganizationNames.Handlers.Commands
{
    public class CreateOrganizationNameCommandHandler : IRequestHandler<CreateOrganizationNameCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrganizationNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateOrganizationNameCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateOrganizationNameDtoValidator();
            var validationResult = await validator.ValidateAsync(request.OrganizationNameDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var OrganizationName = _mapper.Map<OrganizationName>(request.OrganizationNameDto);

                OrganizationName = await _unitOfWork.Repository<OrganizationName>().Add(OrganizationName);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = OrganizationName.OrganizationNameId;
            }

            return response;
        }
    }
}
