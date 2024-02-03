using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MembershipTypes.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MembershipTypes.Handlers.Commands
{
    public class DeleteMembershipTypeCommandHandler : IRequestHandler<DeleteMembershipTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public DeleteMembershipTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteMembershipTypeCommand request, CancellationToken cancellationToken)
        {  
            var membershipType = await _unitOfWork.Repository<MemberShipType>().Get(request.Id);

            if (membershipType == null)  
                throw new NotFoundException(nameof(membershipType), request.Id);
             
            await _unitOfWork.Repository<MemberShipType>().Delete(membershipType); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}