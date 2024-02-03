using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Features.IndividualBulletins.Requests.Commands;

namespace SchoolManagement.Application.Features.IndividualBulletins.Handlers.Commands
{
    public class DeleteIndividualBulletinCommandHandler : IRequestHandler<DeleteIndividualBulletinCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteIndividualBulletinCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
         
        public async Task<Unit> Handle(DeleteIndividualBulletinCommand request, CancellationToken cancellationToken)
        {
            var IndividualBulletin = await _unitOfWork.Repository<IndividualBulletin>().Get(request.IndividualBulletinId);

            if (IndividualBulletin == null)
                throw new NotFoundException(nameof(IndividualBulletin), request.IndividualBulletinId);

            await _unitOfWork.Repository<IndividualBulletin>().Delete(IndividualBulletin);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
