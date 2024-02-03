using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseGradingEntry;
using SchoolManagement.Application.Features.CourseGradingEntrys.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseGradingEntrys.Handlers.Queries
{
    public class GetCourseGradingEntryDetailRequestHandler : IRequestHandler<GetCourseGradingEntryDetailRequest, CourseGradingEntryDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CourseGradingEntry> _CourseGradingEntryRepository;
        public GetCourseGradingEntryDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CourseGradingEntry> CourseGradingEntryRepository, IMapper mapper)
        {
            _CourseGradingEntryRepository = CourseGradingEntryRepository;
            _mapper = mapper;
        }
        public async Task<CourseGradingEntryDto> Handle(GetCourseGradingEntryDetailRequest request, CancellationToken cancellationToken)
        {
            var CourseGradingEntry = await _CourseGradingEntryRepository.Get(request.CourseGradingEntryId);
            return _mapper.Map<CourseGradingEntryDto>(CourseGradingEntry);
        }
    }
}
