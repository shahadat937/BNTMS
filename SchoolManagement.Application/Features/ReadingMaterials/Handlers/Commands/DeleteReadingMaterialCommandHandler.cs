using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ReadingMaterials.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ReadingMaterials.Handlers.Commands
{
    public class DeleteReadingMaterialCommandHandler : IRequestHandler<DeleteReadingMaterialCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteReadingMaterialCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteReadingMaterialCommand request, CancellationToken cancellationToken)
        {
            var ReadingMaterials = await _unitOfWork.Repository<ReadingMaterial>().Get(request.ReadingMaterialId);

            if (ReadingMaterials == null)
                throw new NotFoundException(nameof(ReadingMaterial), request.ReadingMaterialId);

            await _unitOfWork.Repository<ReadingMaterial>().Delete(ReadingMaterials);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
