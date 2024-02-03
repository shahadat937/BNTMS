using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaSemesterDurations.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaSemesterDurations.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaSemesterDurations.Handlers.Commands
{  
    public class UpdateBnaSemesterDurationCommandHandler : IRequestHandler<UpdateBnaSemesterDurationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateBnaSemesterDurationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateBnaSemesterDurationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBnaSemesterDurationDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.BnaSemesterDurationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 
             
            var BnaSemesterDuration = await _unitOfWork.Repository<BnaSemesterDuration>().Get(request.BnaSemesterDurationDto.BnaSemesterDurationId); 

            if (BnaSemesterDuration is null)  
                throw new NotFoundException(nameof(BnaSemesterDuration), request.BnaSemesterDurationDto.BnaSemesterDurationId); 

            _mapper.Map(request.BnaSemesterDurationDto, BnaSemesterDuration);  

            await _unitOfWork.Repository<BnaSemesterDuration>().Update(BnaSemesterDuration); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}