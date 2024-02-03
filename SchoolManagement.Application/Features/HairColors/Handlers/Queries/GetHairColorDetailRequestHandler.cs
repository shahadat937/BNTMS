using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.HairColor;
using SchoolManagement.Application.Features.HairColors.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.HairColors.Handlers.Queries
{
    public class GetHairColorDetailRequestHandler : IRequestHandler<GetHairColorDetailRequest, HairColorDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.HairColor> _HairColorRepository;
        public GetHairColorDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.HairColor> HairColorRepository, IMapper mapper)
        {
            _HairColorRepository = HairColorRepository;
            _mapper = mapper;
        }
        public async Task<HairColorDto> Handle(GetHairColorDetailRequest request, CancellationToken cancellationToken)
        {
            var HairColor = await _HairColorRepository.Get(request.HairColorId);
            return _mapper.Map<HairColorDto>(HairColor);
        }
    }
}
