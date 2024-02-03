using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DocumentTypes.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.DocumentTypes.Handlers.Commands
{
    public class DeleteDocumentTypeCommandHandler : IRequestHandler<DeleteDocumentTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDocumentTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            var DocumentType = await _unitOfWork.Repository<DocumentType>().Get(request.DocumentTypeId);

            if (DocumentType == null)
                throw new NotFoundException(nameof(DocumentType), request.DocumentTypeId);

            await _unitOfWork.Repository<DocumentType>().Delete(DocumentType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
