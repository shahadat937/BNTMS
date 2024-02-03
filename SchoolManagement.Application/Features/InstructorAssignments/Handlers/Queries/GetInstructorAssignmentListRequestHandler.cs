using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.InstructorAssignments.Requests.Queries;
using SchoolManagement.Application.DTOs.InstructorAssignments;

namespace SchoolManagement.Application.Features.InstructorAssignments.Handlers.Queries
{
    public class GetInstructorAssignmentListRequestHandler : IRequestHandler<GetInstructorAssignmentListRequest, PagedResult<InstructorAssignmentDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.InstructorAssignment> _InstructorAssignmentRepository;

        private readonly IMapper _mapper;

        public GetInstructorAssignmentListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.InstructorAssignment> InstructorAssignmentRepository, IMapper mapper)
        {
            _InstructorAssignmentRepository = InstructorAssignmentRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<InstructorAssignmentDto>> Handle(GetInstructorAssignmentListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.InstructorAssignment> InstructorAssignments = _InstructorAssignmentRepository.FilterWithInclude(x => (x.AssignmentTopic.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = InstructorAssignments.Count();
            InstructorAssignments = InstructorAssignments.OrderByDescending(x => x.InstructorAssignmentId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var InstructorAssignmentDtos = _mapper.Map<List<InstructorAssignmentDto>>(InstructorAssignments);
            var result = new PagedResult<InstructorAssignmentDto>(InstructorAssignmentDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
