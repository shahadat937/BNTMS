using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.BnaBatches.Requests.Commands;

namespace SchoolManagement.Application.Features.BnaBatches.Handlers.Commands
{
    public class DeleteBnaBatchCommandHandler : IRequestHandler<DeleteBnaBatchCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBnaBatchCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
         
        public async Task<Unit> Handle(DeleteBnaBatchCommand request, CancellationToken cancellationToken)
        {
            var BnaBatch = await _unitOfWork.Repository<BnaBatch>().Get(request.BnaBatchId);

            if (BnaBatch == null)
                throw new NotFoundException(nameof(BnaBatch), request.BnaBatchId);

            await _unitOfWork.Repository<BnaBatch>().Delete(BnaBatch);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
