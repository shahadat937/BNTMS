using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CurrencyNames.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CurrencyNames.Handlers.Commands
{
    public class DeleteCurrencyNameCommandHandler : IRequestHandler<DeleteCurrencyNameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCurrencyNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCurrencyNameCommand request, CancellationToken cancellationToken)
        {
            var CurrencyName = await _unitOfWork.Repository<CurrencyName>().Get(request.CurrencyNameId);

            if (CurrencyName == null)
                throw new NotFoundException(nameof(CurrencyName), request.CurrencyNameId);

            await _unitOfWork.Repository<CurrencyName>().Delete(CurrencyName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
