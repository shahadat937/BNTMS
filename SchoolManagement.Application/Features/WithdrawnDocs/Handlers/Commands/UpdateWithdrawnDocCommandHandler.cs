using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.WithdrawnDoc.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.WithdrawnDocs.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.WithdrawnDocs.Handlers.Commands
{
    public class UpdateWithdrawnDocCommandHandler : IRequestHandler<UpdateWithdrawnDocCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateWithdrawnDocCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateWithdrawnDocCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateWithdrawnDocDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.WithdrawnDocDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 
             
            var WithdrawnDoc = await _unitOfWork.Repository<WithdrawnDoc>().Get(request.WithdrawnDocDto.WithdrawnDocId); 

            if (WithdrawnDoc is null)  
                throw new NotFoundException(nameof(WithdrawnDoc), request.WithdrawnDocDto.WithdrawnDocId); 

            _mapper.Map(request.WithdrawnDocDto, WithdrawnDoc);  

            await _unitOfWork.Repository<WithdrawnDoc>().Update(WithdrawnDoc); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}