using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BaseNames.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BaseNames.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BaseNames.Handlers.Commands
{  
    public class UpdateBaseNameCommandHandler : IRequestHandler<UpdateBaseNameCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateBaseNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateBaseNameCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBaseNameDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.BaseNameDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 
             
            var BaseName = await _unitOfWork.Repository<BaseName>().Get(request.BaseNameDto.BaseNameId); 

            if (BaseName is null)  
                throw new NotFoundException(nameof(BaseName), request.BaseNameDto.BaseNameId); 

            _mapper.Map(request.BaseNameDto, BaseName);  

            await _unitOfWork.Repository<BaseName>().Update(BaseName); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}