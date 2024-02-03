using AutoMapper;
using MediatR;
using SchoolManagement.Domain;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.FamilyNomination.Validators;
using SchoolManagement.Application.Features.FamilyNominations.Requests.Commands;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.FamilyNominations.Handlers.Commands
{
    public class CreateFamilyNominationCommandHandler : IRequestHandler<CreateFamilyNominationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public CreateFamilyNominationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateFamilyNominationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateFamilyNominationDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.FamilyNominationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var familyNominations = _mapper.Map<FamilyNomination>(request.FamilyNominationDto); 

                familyNominations = await _unitOfWork.Repository<FamilyNomination>().Add(familyNominations);
                await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Creation Successful"; 
                response.Id = familyNominations.FamilyNominationId;
            }

            return response;
        }
    }
}
