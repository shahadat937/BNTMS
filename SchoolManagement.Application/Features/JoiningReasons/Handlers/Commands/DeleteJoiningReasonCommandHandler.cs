using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.JoiningReasons.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.JoiningReasons.Handlers.Commands
{
    public class DeleteJoiningReasonCommandHandler : IRequestHandler<DeleteJoiningReasonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public DeleteJoiningReasonCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteJoiningReasonCommand request, CancellationToken cancellationToken)
        {  
            var JoiningReason = await _unitOfWork.Repository<JoiningReason>().Get(request.Id);

            if (JoiningReason == null)  
                throw new NotFoundException(nameof(JoiningReason), request.Id);
             
            await _unitOfWork.Repository<JoiningReason>().Delete(JoiningReason); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}