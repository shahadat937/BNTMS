using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeBioDataOthers.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeBioDataOthers.Handlers.Commands
{
    public class DeleteTraineeBioDataOtherCommandHandler : IRequestHandler<DeleteTraineeBioDataOtherCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTraineeBioDataOtherCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTraineeBioDataOtherCommand request, CancellationToken cancellationToken)
        {
            var TraineeBioDataOther = await _unitOfWork.Repository<TraineeBioDataOther>().Get(request.TraineeBioDataOtherId);

            if (TraineeBioDataOther == null)
                throw new NotFoundException(nameof(TraineeBioDataOther), request.TraineeBioDataOtherId);

            await _unitOfWork.Repository<TraineeBioDataOther>().Delete(TraineeBioDataOther);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
