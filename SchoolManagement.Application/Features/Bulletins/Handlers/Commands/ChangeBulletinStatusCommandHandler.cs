using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Bulletins.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Bulletins.Handlers.Commands
{
    public class ChangeBulletinStatusCommandHandler : IRequestHandler<ChangeBulletinStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public ChangeBulletinStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ChangeBulletinStatusCommand request, CancellationToken cancellationToken)
        {
            var Bulletin = await _unitOfWork.Repository<Bulletin>().Get(request.BulletinId);
            Bulletin.Status = request.Status;

            if (Bulletin == null)
                throw new NotFoundException(nameof(Bulletin), request.BulletinId);

            await _unitOfWork.Repository<Bulletin>().Update(Bulletin);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
