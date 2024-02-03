using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Allowances.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Allowances.Handlers.Commands
{
    public class DeleteAllowanceCommandHandler : IRequestHandler<DeleteAllowanceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAllowanceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAllowanceCommand request, CancellationToken cancellationToken)
        {
            var Allowance = await _unitOfWork.Repository<Allowance>().Get(request.AllowanceId);

            if (Allowance == null)
                throw new NotFoundException(nameof(Allowance), request.AllowanceId);

            await _unitOfWork.Repository<Allowance>().Delete(Allowance);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
