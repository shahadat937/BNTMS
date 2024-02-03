using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.InterServiceMarks.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InterServiceMarks.Handlers.Commands
{
    public class DeleteInterServiceMarkCommandHandler : IRequestHandler<DeleteInterServiceMarkCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteInterServiceMarkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteInterServiceMarkCommand request, CancellationToken cancellationToken)
        {
            var InterServiceMark = await _unitOfWork.Repository<InterServiceMark>().Get(request.InterServiceMarkId);

            if (InterServiceMark == null)
                throw new NotFoundException(nameof(InterServiceMark), request.InterServiceMarkId);

            await _unitOfWork.Repository<InterServiceMark>().Delete(InterServiceMark);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
