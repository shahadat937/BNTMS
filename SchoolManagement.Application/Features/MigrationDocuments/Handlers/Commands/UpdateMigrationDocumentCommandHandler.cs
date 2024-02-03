using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MigrationDocument.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MigrationDocuments.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MigrationDocuments.Handlers.Commands
{
    public class UpdateMigrationDocumentCommandHandler : IRequestHandler<UpdateMigrationDocumentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateMigrationDocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateMigrationDocumentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMigrationDocumentDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.MigrationDocumentDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 
             
            var MigrationDocument = await _unitOfWork.Repository<MigrationDocument>().Get(request.MigrationDocumentDto.MigrationDocumentId); 

            if (MigrationDocument is null)  
                throw new NotFoundException(nameof(MigrationDocument), request.MigrationDocumentDto.MigrationDocumentId); 

            _mapper.Map(request.MigrationDocumentDto, MigrationDocument);  

            await _unitOfWork.Repository<MigrationDocument>().Update(MigrationDocument);  
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}