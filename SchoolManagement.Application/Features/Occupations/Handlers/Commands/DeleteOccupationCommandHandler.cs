using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Occupations.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Occupations.Handlers.Commands
{
    public class DeleteOccupationCommandHandler : IRequestHandler<DeleteOccupationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteOccupationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOccupationCommand request, CancellationToken cancellationToken)
        {
            var Occupation = await _unitOfWork.Repository<Occupation>().Get(request.OccupationId);

            if (Occupation == null)
                throw new NotFoundException(nameof(Occupation), request.OccupationId);

            await _unitOfWork.Repository<Occupation>().Delete(Occupation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
