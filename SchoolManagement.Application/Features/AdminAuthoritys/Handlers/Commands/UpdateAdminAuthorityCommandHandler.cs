using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.AdminAuthority.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.AdminAuthoritys.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.AdminAuthoritys.Handlers.Commands
{
    public class UpdateAdminAuthorityCommandHandler : IRequestHandler<UpdateAdminAuthorityCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAdminAuthorityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAdminAuthorityCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAdminAuthorityDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.AdminAuthorityDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var AdminAuthority = await _unitOfWork.Repository<AdminAuthority>().Get(request.AdminAuthorityDto.AdminAuthorityId);

            if (AdminAuthority is null)
                throw new NotFoundException(nameof(AdminAuthority), request.AdminAuthorityDto.AdminAuthorityId);

            _mapper.Map(request.AdminAuthorityDto, AdminAuthority);

            await _unitOfWork.Repository<AdminAuthority>().Update(AdminAuthority);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
