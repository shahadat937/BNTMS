using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.WeekName;
using SchoolManagement.Application.Features.WeekNames.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.WeekNames.Handlers.Queries
{
    public class GetWeekNameDetailRequestHandler : IRequestHandler<GetWeekNameDetailRequest, WeekNameDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.WeekName> _WeekNameRepository;
        public GetWeekNameDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.WeekName> WeekNameRepository, IMapper mapper)
        {
            _WeekNameRepository = WeekNameRepository;
            _mapper = mapper;
        }
        public async Task<WeekNameDto> Handle(GetWeekNameDetailRequest request, CancellationToken cancellationToken)
        {
            var WeekName = await _WeekNameRepository.Get(request.WeekNameId);
            return _mapper.Map<WeekNameDto>(WeekName);
        }
    }
}
