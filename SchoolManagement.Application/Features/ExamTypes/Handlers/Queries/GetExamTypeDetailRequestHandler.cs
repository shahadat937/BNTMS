using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ExamType;
using SchoolManagement.Application.Features.ExamTypes.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamTypes.Handlers.Queries
{
    public class GetExamTypeDetailRequestHandler : IRequestHandler<GetExamTypeDetailRequest, ExamTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ExamType> _ExamTypeRepository;
        public GetExamTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ExamType> ExamTypeRepository, IMapper mapper)
        {
            _ExamTypeRepository = ExamTypeRepository;
            _mapper = mapper;
        }
        public async Task<ExamTypeDto> Handle(GetExamTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var ExamType = await _ExamTypeRepository.Get(request.ExamTypeId);
            return _mapper.Map<ExamTypeDto>(ExamType);
        }
    }
}
