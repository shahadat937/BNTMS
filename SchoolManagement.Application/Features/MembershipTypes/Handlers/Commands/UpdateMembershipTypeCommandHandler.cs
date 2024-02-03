using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MembershipTypes.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MembershipTypes.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MembershipTypes.Handlers.Commands
{
    public class UpdateMembershipTypeCommandHandler : IRequestHandler<UpdateMembershipTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateMembershipTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateMembershipTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMembershipTypeDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.MembershipTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 
             
            var membershipType = await _unitOfWork.Repository<MemberShipType>().Get(request.MembershipTypeDto.MembershipTypeId); 

            if (membershipType is null)  
                throw new NotFoundException(nameof(membershipType), request.MembershipTypeDto.MembershipTypeId); 

            _mapper.Map(request.MembershipTypeDto, membershipType);  

            await _unitOfWork.Repository<MemberShipType>().Update(membershipType);  
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}