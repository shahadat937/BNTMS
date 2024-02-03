using SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ForeignCourseOthersDocument;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

using System.Text;


namespace SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Handlers.Queries
{
    public class GetForeignCourseOthersDocumentListRequestHandler : IRequestHandler<GetForeignCourseOthersDocumentListRequest, PagedResult<ForeignCourseOthersDocumentDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ForeignCourseOthersDocument> _ForeignCourseOthersDocumentRepository;

        private readonly IMapper _mapper;

        public GetForeignCourseOthersDocumentListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ForeignCourseOthersDocument> ForeignCourseOthersDocumentRepository, IMapper mapper)
        {
            _ForeignCourseOthersDocumentRepository = ForeignCourseOthersDocumentRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ForeignCourseOthersDocumentDto>> Handle(GetForeignCourseOthersDocumentListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ForeignCourseOthersDocument> ForeignCourseOthersDocuments = _ForeignCourseOthersDocumentRepository.FilterWithInclude(x => String.IsNullOrEmpty(request.QueryParams.SearchText), "ForeignCourseDocType").Where(x=>x.CourseDurationId==request.CourseDurationId && x.TraineeId==request.TraineeId);
            var totalCount = ForeignCourseOthersDocuments.Count();
            ForeignCourseOthersDocuments = ForeignCourseOthersDocuments.OrderByDescending(x => x.ForeignCourseOthersDocumentId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ForeignCourseOthersDocumentDtos = _mapper.Map<List<ForeignCourseOthersDocumentDto>>(ForeignCourseOthersDocuments);
            var result = new PagedResult<ForeignCourseOthersDocumentDto>(ForeignCourseOthersDocumentDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
