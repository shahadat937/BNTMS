using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.WithdrawnTypes.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.WithdrawnTypes.Handlers.Commands
{
    public class DeleteWithdrawnTypeCommandHandler : IRequestHandler<DeleteWithdrawnTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteWithdrawnTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteWithdrawnTypeCommand request, CancellationToken cancellationToken)
        {
            var WithdrawnType = await _unitOfWork.Repository<WithdrawnType>().Get(request.WithdrawnTypeId);

            if (WithdrawnType == null)
                throw new NotFoundException(nameof(WithdrawnType), request.WithdrawnTypeId);

            await _unitOfWork.Repository<WithdrawnType>().Delete(WithdrawnType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
