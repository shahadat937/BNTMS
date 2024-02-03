using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ForeignCourseOtherDoc;
using SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignCourseOtherDocs.Handlers.Queries
{
    public class GetForeignCourseOtherDocDetailRequestHandler : IRequestHandler<GetForeignCourseOtherDocDetailRequest, ForeignCourseOtherDocDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ForeignCourseOtherDoc> _ForeignCourseOtherDocRepository;
        public GetForeignCourseOtherDocDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ForeignCourseOtherDoc> ForeignCourseOtherDocRepository, IMapper mapper)
        {
            _ForeignCourseOtherDocRepository = ForeignCourseOtherDocRepository;
            _mapper = mapper;
        }
        public async Task<ForeignCourseOtherDocDto> Handle(GetForeignCourseOtherDocDetailRequest request, CancellationToken cancellationToken)
        {
            var ForeignCourseOtherDoc = await _ForeignCourseOtherDocRepository.Get(request.ForeignCourseOtherDocId);
            return _mapper.Map<ForeignCourseOtherDocDto>(ForeignCourseOtherDoc);
        }
    }
}
