using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.GrandFatherTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GrandFatherTypes.Handlers.Commands
{
    public class DeleteGrandFatherTypeCommandHandler : IRequestHandler<DeleteGrandFatherTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteGrandFatherTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteGrandFatherTypeCommand request, CancellationToken cancellationToken)
        {
            var GrandFatherType = await _unitOfWork.Repository<GrandFatherType>().Get(request.GrandfatherTypeId);

            if (GrandFatherType == null)
                throw new NotFoundException(nameof(GrandFatherType), request.GrandfatherTypeId);

            await _unitOfWork.Repository<GrandFatherType>().Delete(GrandFatherType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
