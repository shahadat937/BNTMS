using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaAttendanceRemark.Requests.Queries;
using SchoolManagement.Application.DTOs.BnaAttendanceRemarks;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaAttendanceRemark.Handlers.Queries
{
    public class GetBnaAttendanceRemarkListRequestHandler : IRequestHandler<GetBnaAttendanceRemarkListRequest, PagedResult<BnaAttendanceRemarkDto>>
    {
         
        private readonly ISchoolManagementRepository<BnaAttendanceRemarks> _BnaAttendanceRemarkRepository;

        private readonly IMapper _mapper;

        public GetBnaAttendanceRemarkListRequestHandler(ISchoolManagementRepository<BnaAttendanceRemarks> BnaAttendanceRemarkRepository, IMapper mapper)
        {
            _BnaAttendanceRemarkRepository = BnaAttendanceRemarkRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BnaAttendanceRemarkDto>> Handle(GetBnaAttendanceRemarkListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 

            IQueryable<BnaAttendanceRemarks> BnaAttendanceRemarks = _BnaAttendanceRemarkRepository.FilterWithInclude(x => (x.AttendanceRemarksCause.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = BnaAttendanceRemarks.Count();
            BnaAttendanceRemarks = BnaAttendanceRemarks.OrderByDescending(x => x.BnaAttendanceRemarksId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BnaAttendanceRemarkDtos = _mapper.Map<List<BnaAttendanceRemarkDto>>(BnaAttendanceRemarks);
            var result = new PagedResult<BnaAttendanceRemarkDto>(BnaAttendanceRemarkDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
