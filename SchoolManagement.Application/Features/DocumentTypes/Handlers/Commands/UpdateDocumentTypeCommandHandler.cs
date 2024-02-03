using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DocumentTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.DTOs.DocumentTypes.Validators;

namespace SchoolManagement.Application.Features.DocumentTypes.Handlers.Commands
{
    public class UpdateDocumentTypeCommandHandler : IRequestHandler<UpdateDocumentTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDocumentTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDocumentTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.DocumentTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var DocumentType = await _unitOfWork.Repository<DocumentType>().Get(request.DocumentTypeDto.DocumentTypeId);

            if (DocumentType is null)
                throw new NotFoundException(nameof(DocumentType), request.DocumentTypeDto.DocumentTypeId);

            _mapper.Map(request.DocumentTypeDto, DocumentType);

            await _unitOfWork.Repository<DocumentType>().Update(DocumentType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
