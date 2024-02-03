using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.AdminAuthoritys.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AdminAuthoritys.Handlers.Commands
{
    public class DeleteAdminAuthorityCommandHandler : IRequestHandler<DeleteAdminAuthorityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAdminAuthorityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAdminAuthorityCommand request, CancellationToken cancellationToken)
        {
            var AdminAuthority = await _unitOfWork.Repository<AdminAuthority>().Get(request.AdminAuthorityId);

            if (AdminAuthority == null)
                throw new NotFoundException(nameof(AdminAuthority), request.AdminAuthorityId);

            await _unitOfWork.Repository<AdminAuthority>().Delete(AdminAuthority);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
