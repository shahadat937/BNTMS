using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TdecGroupResults.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TdecGroupResults.Handlers.Commands
{
    public class DeleteTdecGroupResultCommandHandler : IRequestHandler<DeleteTdecGroupResultCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTdecGroupResultCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTdecGroupResultCommand request, CancellationToken cancellationToken)
        {
            var TdecGroupResult = await _unitOfWork.Repository<TdecGroupResult>().Get(request.TdecGroupResultId);

            if (TdecGroupResult == null)
                throw new NotFoundException(nameof(TdecGroupResult), request.TdecGroupResultId);

            await _unitOfWork.Repository<TdecGroupResult>().Delete(TdecGroupResult);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
