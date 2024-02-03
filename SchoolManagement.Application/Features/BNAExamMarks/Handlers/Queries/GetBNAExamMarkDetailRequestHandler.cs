using AutoMapper;
using SchoolManagement.Application.DTOs.BnaExamMark;
using SchoolManagement.Application.Features.BnaExamMarks.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks; 

namespace SchoolManagement.Application.Features.BnaExamMarks.Handlers.Queries
{
    public class GetBnaExamMarkDetailRequestHandler : IRequestHandler<GetBnaExamMarkDetailRequest, BnaExamMarkDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BnaExamMark> _BnaExamMarkRepository;
        public GetBnaExamMarkDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BnaExamMark> BnaExamMarkRepository, IMapper mapper)
        {
            _BnaExamMarkRepository = BnaExamMarkRepository;
            _mapper = mapper;
        }
        public async Task<BnaExamMarkDto> Handle(GetBnaExamMarkDetailRequest request, CancellationToken cancellationToken)
        {
            var BnaExamMark = await _BnaExamMarkRepository.FindOneAsync(x => x.BnaExamMarkId == request.BnaExamMarkId);
            return _mapper.Map<BnaExamMarkDto>(BnaExamMark);
        }
    }
}
