using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ClassPeriod;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassPeriods.Handlers.Queries
{
    public class GetClassPeriodDetailRequestHandler : IRequestHandler<GetClassPeriodDetailRequest, ClassPeriodDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<ClassPeriod> _ClassPeriodRepository;
        public GetClassPeriodDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ClassPeriod> ClassPeriodRepository, IMapper mapper)
        {
            _ClassPeriodRepository = ClassPeriodRepository;
            _mapper = mapper;
        }
        public async Task<ClassPeriodDto> Handle(GetClassPeriodDetailRequest request, CancellationToken cancellationToken)
        {
            //var ClassPeriod = await _ClassPeriodRepository.Get(request.ClassPeriodId);
            var ClassPeriod = _ClassPeriodRepository.FinedOneInclude(x => x.ClassPeriodId == request.ClassPeriodId, "CourseName");
            return _mapper.Map<ClassPeriodDto>(ClassPeriod);
        }
    }
}
