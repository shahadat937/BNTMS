using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.WithdrawnDocs.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.WithdrawnDocs.Handlers.Commands
{
    public class DeleteWithdrawnDocCommandHandler : IRequestHandler<DeleteWithdrawnDocCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public DeleteWithdrawnDocCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteWithdrawnDocCommand request, CancellationToken cancellationToken)
        {  
            var WithdrawnDoc = await _unitOfWork.Repository<WithdrawnDoc>().Get(request.Id);

            if (WithdrawnDoc == null)  
                throw new NotFoundException(nameof(WithdrawnDoc), request.Id);
             
            await _unitOfWork.Repository<WithdrawnDoc>().Delete(WithdrawnDoc); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}