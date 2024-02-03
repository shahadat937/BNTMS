using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ExamMarkRemarks;
using SchoolManagement.Application.Features.ExamMarkRemark.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamMarkRemark.Handlers.Queries
{
    public class GetExamMarkRemarkDetailRequestHandler : IRequestHandler<GetExamMarkRemarkDetailRequest, ExamMarkRemarkDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ExamMarkRemarks> _ExamMarkRemarkRepository;
        public GetExamMarkRemarkDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ExamMarkRemarks> ExamMarkRemarkRepository, IMapper mapper)
        {
            _ExamMarkRemarkRepository = ExamMarkRemarkRepository;
            _mapper = mapper;
        }
        public async Task<ExamMarkRemarkDto> Handle(GetExamMarkRemarkDetailRequest request, CancellationToken cancellationToken)
        {
            var ExamMarkRemark = await _ExamMarkRemarkRepository.Get(request.ExamMarkRemarksId);
            return _mapper.Map<ExamMarkRemarkDto>(ExamMarkRemark);
        }
    }
}
