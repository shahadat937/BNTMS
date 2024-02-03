using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ParentRelatives.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ParentRelatives.Handlers.Commands
{
    public class DeleteParentRelativeCommandHandler : IRequestHandler<DeleteParentRelativeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteParentRelativeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteParentRelativeCommand request, CancellationToken cancellationToken)
        {
            var ParentRelative = await _unitOfWork.Repository<ParentRelative>().Get(request.ParentRelativeId);

            if (ParentRelative == null)
                throw new NotFoundException(nameof(ParentRelative), request.ParentRelativeId);

            await _unitOfWork.Repository<ParentRelative>().Delete(ParentRelative);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
