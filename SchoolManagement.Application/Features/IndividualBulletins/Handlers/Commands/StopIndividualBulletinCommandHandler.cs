using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.IndividualBulletins.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.IndividualBulletins.Handlers.Commands
{
    public class StopIndividualBulletinCommandHandler : IRequestHandler<StopIndividualBulletinCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StopIndividualBulletinCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(StopIndividualBulletinCommand request, CancellationToken cancellationToken)
        {
            var IndividualBulletin = await _unitOfWork.Repository<IndividualBulletin>().Get(request.IndividualBulletinId);
            IndividualBulletin.Status = 1;

            if (IndividualBulletin == null)
                throw new NotFoundException(nameof(IndividualBulletin), request.IndividualBulletinId);

            await _unitOfWork.Repository<IndividualBulletin>().Update(IndividualBulletin);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
