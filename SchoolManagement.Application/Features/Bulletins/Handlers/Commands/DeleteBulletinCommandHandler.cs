using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Features.Bulletins.Requests.Commands;

namespace SchoolManagement.Application.Features.Bulletins.Handlers.Commands
{
    public class DeleteBulletinCommandHandler : IRequestHandler<DeleteBulletinCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBulletinCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
         
        public async Task<Unit> Handle(DeleteBulletinCommand request, CancellationToken cancellationToken)
        {
            var Bulletin = await _unitOfWork.Repository<Bulletin>().Get(request.BulletinId);

            if (Bulletin == null)
                throw new NotFoundException(nameof(Bulletin), request.BulletinId);

            await _unitOfWork.Repository<Bulletin>().Delete(Bulletin);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
