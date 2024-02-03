using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.OrganizationName.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.OrganizationNames.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OrganizationNames.Handlers.Commands
{
    public class UpdateOrganizationNameCommandHandler : IRequestHandler<UpdateOrganizationNameCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOrganizationNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOrganizationNameCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOrganizationNameDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.OrganizationNameDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var OrganizationName = await _unitOfWork.Repository<OrganizationName>().Get(request.OrganizationNameDto.OrganizationNameId);

            if (OrganizationName is null)
                throw new NotFoundException(nameof(OrganizationName), request.OrganizationNameDto.OrganizationNameId);

            _mapper.Map(request.OrganizationNameDto, OrganizationName);

            await _unitOfWork.Repository<OrganizationName>().Update(OrganizationName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
