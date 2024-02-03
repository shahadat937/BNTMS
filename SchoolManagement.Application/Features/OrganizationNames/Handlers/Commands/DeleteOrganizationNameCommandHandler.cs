using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.OrganizationNames.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OrganizationNames.Handlers.Commands
{
    public class DeleteOrganizationNameCommandHandler : IRequestHandler<DeleteOrganizationNameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteOrganizationNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOrganizationNameCommand request, CancellationToken cancellationToken)
        {
            var OrganizationName = await _unitOfWork.Repository<OrganizationName>().Get(request.OrganizationNameId);

            if (OrganizationName == null)
                throw new NotFoundException(nameof(OrganizationName), request.OrganizationNameId);

            await _unitOfWork.Repository<OrganizationName>().Delete(OrganizationName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
