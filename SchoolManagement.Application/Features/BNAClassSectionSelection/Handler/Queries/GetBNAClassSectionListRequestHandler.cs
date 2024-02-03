using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaClassSectionSelection;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Features.BnaClassSections.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassSections.Handler.Queries
{
    public class GetBnaClassSectionListRequestHandler : IRequestHandler<GetBnaClassSectionListRequest, PagedResult<BnaClassSectionSelectionDto>>
    { 

        private readonly ISchoolManagementRepository<BnaClassSectionSelection> _bnaClassSectionRepository; 

        private readonly IMapper _mapper;

        public GetBnaClassSectionListRequestHandler(ISchoolManagementRepository<BnaClassSectionSelection> bnaClassSectionRepository, IMapper mapper)
        {
            _bnaClassSectionRepository = bnaClassSectionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BnaClassSectionSelectionDto>> Handle(GetBnaClassSectionListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString());

            IQueryable<BnaClassSectionSelection> bnaClassSectiones = _bnaClassSectionRepository.FilterWithInclude(x => (x.SectionName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = bnaClassSectiones.Count();
            bnaClassSectiones = bnaClassSectiones.OrderByDescending(x => x.BnaClassSectionSelectionId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BnaClassSectionesDtos = _mapper.Map<List<BnaClassSectionSelectionDto>>(bnaClassSectiones);
            var result = new PagedResult<BnaClassSectionSelectionDto>(BnaClassSectionesDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
