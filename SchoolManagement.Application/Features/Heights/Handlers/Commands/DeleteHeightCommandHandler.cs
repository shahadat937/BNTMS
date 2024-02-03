using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Heights.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Heights.Handler.Commands
{
    public class DeleteHeightCommandHandler : IRequestHandler<DeleteHeightsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public DeleteHeightCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork; 
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteHeightsCommand request, CancellationToken cancellationToken)
        {
            var height = await _unitOfWork.Repository<Height>().Get(request.Id);
             
            if (height == null)
                throw new NotFoundException(nameof(Height), request.Id);

            await _unitOfWork.Repository<Height>().Delete(height); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}