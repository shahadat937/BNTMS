using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BaseNames.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BaseNames.Handlers.Commands  
{ 
    public class DeleteBaseNameCommandHandler : IRequestHandler<DeleteBaseNameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public DeleteBaseNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteBaseNameCommand request, CancellationToken cancellationToken)
        {  
            var BaseName = await _unitOfWork.Repository<BaseName>().Get(request.Id);

            if (BaseName == null)  
                throw new NotFoundException(nameof(BaseName), request.Id);
             
            await _unitOfWork.Repository<BaseName>().Delete(BaseName); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}