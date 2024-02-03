using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.FamilyNominations.Requests.Commands;

namespace SchoolManagement.Application.Features.FamilyNominations.Handlers.Commands
{
    public class DeleteFamilyNominationCommandHandler : IRequestHandler<DeleteFamilyNominationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public DeleteFamilyNominationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteFamilyNominationCommand request, CancellationToken cancellationToken)
        {  
            var familyNominations = await _unitOfWork.Repository<FamilyNomination>().Get(request.Id);

            if (familyNominations == null)  
                throw new NotFoundException(nameof(familyNominations), request.Id);
             
            await _unitOfWork.Repository<FamilyNomination>().Delete(familyNominations); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}