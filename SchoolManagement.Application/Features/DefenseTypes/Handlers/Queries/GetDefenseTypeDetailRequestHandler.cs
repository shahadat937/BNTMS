using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DefenseType;
using SchoolManagement.Application.Features.DefenseTypes.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.DefenseTypes.Handlers.Queries
{
    public class GetDefenseTypeDetailRequestHandler : IRequestHandler<GetDefenseTypeDetailRequest, DefenseTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DefenseType> _DefenseTypeRepository;
        public GetDefenseTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DefenseType> DefenseTypeRepository, IMapper mapper)
        {
            _DefenseTypeRepository = DefenseTypeRepository;
            _mapper = mapper;
        }
        public async Task<DefenseTypeDto> Handle(GetDefenseTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var DefenseType = await _DefenseTypeRepository.Get(request.DefenseTypeId);
            return _mapper.Map<DefenseTypeDto>(DefenseType);
        }
    }
}
