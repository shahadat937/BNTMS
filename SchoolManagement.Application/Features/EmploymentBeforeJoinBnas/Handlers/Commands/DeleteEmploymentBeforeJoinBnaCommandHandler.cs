using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.EmploymentBeforeJoinBnas.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.EmploymentBeforeJoinBnas.Handlers.Commands
{
    public class DeleteEmploymentBeforeJoinBnaCommandHandler : IRequestHandler<DeleteEmploymentBeforeJoinBnaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteEmploymentBeforeJoinBnaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEmploymentBeforeJoinBnaCommand request, CancellationToken cancellationToken)
        {
            var EmploymentBeforeJoinBnas = await _unitOfWork.Repository<EmploymentBeforeJoinBna>().Get(request.EmploymentBeforeJoinBnaId);

            if (EmploymentBeforeJoinBnas == null)
                throw new NotFoundException(nameof(EmploymentBeforeJoinBna), request.EmploymentBeforeJoinBnaId);

            await _unitOfWork.Repository<EmploymentBeforeJoinBna>().Delete(EmploymentBeforeJoinBnas);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
