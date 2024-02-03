using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ForeignCourseDocType;
using SchoolManagement.Application.Features.ForeignCourseDocTypes.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignCourseDocTypes.Handlers.Queries
{
    public class GetForeignCourseDocTypeDetailRequestHandler : IRequestHandler<GetForeignCourseDocTypeDetailRequest, ForeignCourseDocTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ForeignCourseDocType> _ForeignCourseDocTypeRepository;
        public GetForeignCourseDocTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ForeignCourseDocType> ForeignCourseDocTypeRepository, IMapper mapper)
        {
            _ForeignCourseDocTypeRepository = ForeignCourseDocTypeRepository;
            _mapper = mapper;
        }
        public async Task<ForeignCourseDocTypeDto> Handle(GetForeignCourseDocTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var ForeignCourseDocType = await _ForeignCourseDocTypeRepository.Get(request.ForeignCourseDocTypeId);
            return _mapper.Map<ForeignCourseDocTypeDto>(ForeignCourseDocType);
        }
    }
}
