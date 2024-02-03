using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MigrationDocument;
using SchoolManagement.Application.Features.MigrationDocuments.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MigrationDocuments.Handlers.Queries
{
    public class GetMigrationDocumentDetailRequestHandler : IRequestHandler<GetMigrationDocumentDetailRequest, MigrationDocumentDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<MigrationDocument> _MigrationDocumentRepository;       
        public GetMigrationDocumentDetailRequestHandler(ISchoolManagementRepository<MigrationDocument> MigrationDocumentRepository, IMapper mapper)
        {
            _MigrationDocumentRepository = MigrationDocumentRepository;    
            _mapper = mapper; 
        } 
        public async Task<MigrationDocumentDto> Handle(GetMigrationDocumentDetailRequest request, CancellationToken cancellationToken)
        {
            var MigrationDocument = await _MigrationDocumentRepository.Get(request.Id);    
            return _mapper.Map<MigrationDocumentDto>(MigrationDocument);    
        }
    }
}
