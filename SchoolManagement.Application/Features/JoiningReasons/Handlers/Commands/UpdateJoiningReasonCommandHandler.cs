using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.JoiningReasons.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.JoiningReasons.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.JoiningReasons.Handlers.Commands
{
    public class UpdateJoiningReasonCommandHandler : IRequestHandler<UpdateJoiningReasonCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateJoiningReasonCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateJoiningReasonCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateJoiningReasonDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.JoiningReasonDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 
             
            var JoiningReason = await _unitOfWork.Repository<JoiningReason>().Get(request.JoiningReasonDto.JoiningReasonId); 

            if (JoiningReason is null)  
                throw new NotFoundException(nameof(JoiningReason), request.JoiningReasonDto.JoiningReasonId); 

            _mapper.Map(request.JoiningReasonDto, JoiningReason);  

            await _unitOfWork.Repository<JoiningReason>().Update(JoiningReason); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}