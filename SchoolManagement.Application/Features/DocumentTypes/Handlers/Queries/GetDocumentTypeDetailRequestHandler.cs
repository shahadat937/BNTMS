using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DocumentTypes;
using SchoolManagement.Application.Features.DocumentTypes.Requests.Queries;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.DocumentTypes.Handlers.Queries
{
    public class GetDocumentTypeDetailRequestHandler : IRequestHandler<GetDocumentTypeDetailRequest, DocumentTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<DocumentType> _DocumentTypeRepository;
        public GetDocumentTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DocumentType> DocumentTypeRepository, IMapper mapper)
        {
            _DocumentTypeRepository = DocumentTypeRepository;
            _mapper = mapper;
        }
        public async Task<DocumentTypeDto> Handle(GetDocumentTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var DocumentType = await _DocumentTypeRepository.Get(request.DocumentTypeId);
            return _mapper.Map<DocumentTypeDto>(DocumentType);
        }
    }
}
