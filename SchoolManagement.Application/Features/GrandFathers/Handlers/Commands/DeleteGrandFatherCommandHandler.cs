using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.GrandFathers.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GrandFathers.Handlers.Commands
{
    public class DeleteGrandFatherCommandHandler : IRequestHandler<DeleteGrandFatherCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteGrandFatherCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteGrandFatherCommand request, CancellationToken cancellationToken)
        {
            var GrandFather = await _unitOfWork.Repository<GrandFather>().Get(request.GrandFatherId);

            if (GrandFather == null)
                throw new NotFoundException(nameof(GrandFather), request.GrandFatherId);

            await _unitOfWork.Repository<GrandFather>().Delete(GrandFather);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
