using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ForceTypes.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForceTypes.Handlers.Commands
{
    public class DeleteForceTypeCommandHandler : IRequestHandler<DeleteForceTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteForceTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteForceTypeCommand request, CancellationToken cancellationToken)
        {
            var ForceType = await _unitOfWork.Repository<ForceType>().Get(request.ForceTypeId);

            if (ForceType == null)
                throw new NotFoundException(nameof(ForceType), request.ForceTypeId);

            await _unitOfWork.Repository<ForceType>().Delete(ForceType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
