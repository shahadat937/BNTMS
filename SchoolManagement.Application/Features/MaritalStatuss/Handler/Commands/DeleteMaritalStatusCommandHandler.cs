using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MaritalStatuss.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MaritalStatuss.Handler.Queries
{
    public class DeleteMaritalStatusCommandHandler : IRequestHandler<DeleteMaritalStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMaritalStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteMaritalStatusCommand request, CancellationToken cancellationToken)
        {
            var MaritalStatus = await _unitOfWork.Repository<MaritalStatus>().Get(request.Id);

            if (MaritalStatus == null)
                throw new NotFoundException(nameof(MaritalStatus), request.Id);

            await _unitOfWork.Repository<MaritalStatus>().Delete(MaritalStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}