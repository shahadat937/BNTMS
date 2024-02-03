using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ForeignCourseGOInfo;
using SchoolManagement.Application.Features.ForeignCourseGOInfos.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignCourseGOInfos.Handlers.Queries
{
    public class GetForeignCourseGOInfoDetailRequestHandler : IRequestHandler<GetForeignCourseGOInfoDetailRequest, ForeignCourseGOInfoDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ForeignCourseGOInfo> _ForeignCourseGOInfoRepository;
        public GetForeignCourseGOInfoDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ForeignCourseGOInfo> ForeignCourseGOInfoRepository, IMapper mapper)
        {
            _ForeignCourseGOInfoRepository = ForeignCourseGOInfoRepository;
            _mapper = mapper;
        }
        public async Task<ForeignCourseGOInfoDto> Handle(GetForeignCourseGOInfoDetailRequest request, CancellationToken cancellationToken)
        {
            var ForeignCourseGOInfo = await _ForeignCourseGOInfoRepository.Get(request.ForeignCourseGOInfoId);
            return _mapper.Map<ForeignCourseGOInfoDto>(ForeignCourseGOInfo);
        }
    }
}
