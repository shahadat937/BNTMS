using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AssignmentMarkEntry.Validators;
using SchoolManagement.Application.Features.AssignmentMarkEntrys.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.AssignmentMarkEntrys.Handlers.Commands
{
    public class CreateAssignmentMarkEntryCommandHandler : IRequestHandler<CreateAssignmentMarkEntryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAssignmentMarkEntryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateAssignmentMarkEntryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateAssignmentMarkEntryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AssignmentMarkEntryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var AssignmentMarkEntry = _mapper.Map<AssignmentMarkEntry>(request.AssignmentMarkEntryDto);

                AssignmentMarkEntry = await _unitOfWork.Repository<AssignmentMarkEntry>().Add(AssignmentMarkEntry);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = AssignmentMarkEntry.AssignmentMarkEntryId;
            }

            return response;
        }
    }
}
