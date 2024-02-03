using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.FamilyNomination.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.FamilyNominations.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.FamilyNominations.Handlers.Commands
{
    public class UpdateFamilyNominationCommandHandler : IRequestHandler<UpdateFamilyNominationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateFamilyNominationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateFamilyNominationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFamilyNominationDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.FamilyNominationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 
             
            var familyNominations = await _unitOfWork.Repository<FamilyNomination>().Get(request.FamilyNominationDto.FamilyNominationId); 

            if (familyNominations is null)  
                throw new NotFoundException(nameof(familyNominations), request.FamilyNominationDto.FamilyNominationId); 

            _mapper.Map(request.FamilyNominationDto, familyNominations);  

            await _unitOfWork.Repository<FamilyNomination>().Update(familyNominations); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}