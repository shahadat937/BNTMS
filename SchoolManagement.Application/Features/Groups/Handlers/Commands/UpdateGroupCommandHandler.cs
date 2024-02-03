using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Groups.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Groups.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Groups.Handlers.Commands
{
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateGroupDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.GroupDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 
             
            var Group = await _unitOfWork.Repository<Group>().Get(request.GroupDto.GroupId); 

            if (Group is null)  
                throw new NotFoundException(nameof(Group), request.GroupDto.GroupId); 

            _mapper.Map(request.GroupDto, Group);  

            await _unitOfWork.Repository<Group>().Update(Group); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}