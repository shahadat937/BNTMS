using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.AssignmentMarkEntrys.Requests.Commands;
using SchoolManagement.Application.DTOs.AssignmentMarkEntry.Validators;

namespace SchoolManagement.Application.Features.AssignmentMarkEntrys.Handlers.Commands
{
    public class UpdateAssignmentMarkEntryCommandHandler : IRequestHandler<UpdateAssignmentMarkEntryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAssignmentMarkEntryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAssignmentMarkEntryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAssignmentMarkEntryDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.AssignmentMarkEntryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var AssignmentMarkEntry = await _unitOfWork.Repository<AssignmentMarkEntry>().Get(request.AssignmentMarkEntryDto.AssignmentMarkEntryId);

            if (AssignmentMarkEntry is null)
                throw new NotFoundException(nameof(AssignmentMarkEntry), request.AssignmentMarkEntryDto.AssignmentMarkEntryId);

            _mapper.Map(request.AssignmentMarkEntryDto, AssignmentMarkEntry);

            await _unitOfWork.Repository<AssignmentMarkEntry>().Update(AssignmentMarkEntry);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
