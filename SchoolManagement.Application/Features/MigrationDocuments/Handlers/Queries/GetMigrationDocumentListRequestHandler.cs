using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.MigrationDocument;
using SchoolManagement.Application.Features.MigrationDocuments.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Application.Features.MigrationDocuments.Handlers.Queries
{
    public class GetMigrationDocumentListRequestHandler : IRequestHandler<GetMigrationDocumentListRequest, PagedResult<MigrationDocumentDto>>
    { 

        private readonly ISchoolManagementRepository<MigrationDocument> _MigrationDocumentRepository;    

        private readonly IMapper _mapper;  
         
        public GetMigrationDocumentListRequestHandler(ISchoolManagementRepository<MigrationDocument> MigrationDocumentRepository, IMapper mapper)
        {
            _MigrationDocumentRepository = MigrationDocumentRepository; 
            _mapper = mapper;  
        }

        public async Task<PagedResult<MigrationDocumentDto>> Handle(GetMigrationDocumentListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<MigrationDocument> MigrationDocuments = _MigrationDocumentRepository.FilterWithInclude(x =>  String.IsNullOrEmpty(request.QueryParams.SearchText), "RelationType");
            var totalCount = MigrationDocuments.Count();
            MigrationDocuments = MigrationDocuments.OrderByDescending(x => x.MigrationDocumentId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
              
            var MigrationDocumentsDtos = _mapper.Map<List<MigrationDocumentDto>>(MigrationDocuments); 
            var result = new PagedResult<MigrationDocumentDto>(MigrationDocumentsDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
