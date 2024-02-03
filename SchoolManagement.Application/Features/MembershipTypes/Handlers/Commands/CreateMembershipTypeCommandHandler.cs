using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MembershipTypes.Validators;
using SchoolManagement.Application.Features.MembershipTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MembershipTypes.Handlers.Commands
{
    public class CreateMembershipTypeCommandHandler : IRequestHandler<CreateMembershipTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public CreateMembershipTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateMembershipTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateMembershipTypeDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.MembershipTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var membershipType = _mapper.Map<MemberShipType>(request.MembershipTypeDto);

                membershipType = await _unitOfWork.Repository<MemberShipType>().Add(membershipType);
                await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Creation Successful"; 
                response.Id = membershipType.MembershipTypeId;
            } 

            return response;
        }
    }
}
