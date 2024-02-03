using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.NewAtempts.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.NewAtempts.Handlers.Commands
{
    public class DeleteNewAtemptCommandHandler : IRequestHandler<DeleteNewAtemptCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteNewAtemptCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteNewAtemptCommand request, CancellationToken cancellationToken)
        {
            var NewAtempt = await _unitOfWork.Repository<NewAtempt>().Get(request.NewAtemptId);

            if (NewAtempt == null)
                throw new NotFoundException(nameof(NewAtempt), request.NewAtemptId);

            await _unitOfWork.Repository<NewAtempt>().Delete(NewAtempt);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
