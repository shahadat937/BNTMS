using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Groups.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Groups.Handlers.Commands
{
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public DeleteGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {  
            var Group = await _unitOfWork.Repository<Group>().Get(request.Id);

            if (Group == null)  
                throw new NotFoundException(nameof(Group), request.Id);
             
            await _unitOfWork.Repository<Group>().Delete(Group); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}