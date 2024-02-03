using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MigrationDocuments.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MigrationDocuments.Handlers.Commands
{
    public class DeleteMigrationDocumentCommandHandler : IRequestHandler<DeleteMigrationDocumentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public DeleteMigrationDocumentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteMigrationDocumentCommand request, CancellationToken cancellationToken)
        {  
            var MigrationDocument = await _unitOfWork.Repository<MigrationDocument>().Get(request.Id);

            if (MigrationDocument == null)  
                throw new NotFoundException(nameof(MigrationDocument), request.Id);
             
            await _unitOfWork.Repository<MigrationDocument>().Delete(MigrationDocument); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}