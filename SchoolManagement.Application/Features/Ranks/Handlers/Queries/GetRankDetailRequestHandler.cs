﻿using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Rank;
using SchoolManagement.Application.Features.Ranks.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Ranks.Handlers.Queries
{
    public class GetRankDetailRequestHandler : IRequestHandler<GetRankDetailRequest, RankDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Rank> _RankRepository;
        public GetRankDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Rank> RankRepository, IMapper mapper)
        {
            _RankRepository = RankRepository;
            _mapper = mapper;
        }
        public async Task<RankDto> Handle(GetRankDetailRequest request, CancellationToken cancellationToken)
        {
            var Rank = await _RankRepository.Get(request.RankId);
            return _mapper.Map<RankDto>(Rank);
        }
    }
}
