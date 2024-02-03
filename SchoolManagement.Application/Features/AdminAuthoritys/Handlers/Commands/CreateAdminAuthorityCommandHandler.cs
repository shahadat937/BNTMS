using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AdminAuthority.Validators;
using SchoolManagement.Application.Features.AdminAuthoritys.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AdminAuthoritys.Handlers.Commands
{
    public class CreateAdminAuthorityCommandHandler : IRequestHandler<CreateAdminAuthorityCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAdminAuthorityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateAdminAuthorityCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateAdminAuthorityDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AdminAuthorityDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var AdminAuthority = _mapper.Map<AdminAuthority>(request.AdminAuthorityDto);

                AdminAuthority = await _unitOfWork.Repository<AdminAuthority>().Add(AdminAuthority);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = AdminAuthority.AdminAuthorityId;
            }

            return response;
        }
    }
}
