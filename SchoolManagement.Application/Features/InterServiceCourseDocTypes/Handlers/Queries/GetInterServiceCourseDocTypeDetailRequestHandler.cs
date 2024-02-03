using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.InterServiceCourseDocType;
using SchoolManagement.Application.Features.InterServiceCourseDocTypes.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InterServiceCourseDocTypes.Handlers.Queries
{
    public class GetInterServiceCourseDocTypeDetailRequestHandler : IRequestHandler<GetInterServiceCourseDocTypeDetailRequest, InterServiceCourseDocTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.InterServiceCourseDocType> _InterServiceCourseDocTypeRepository;
        public GetInterServiceCourseDocTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.InterServiceCourseDocType> InterServiceCourseDocTypeRepository, IMapper mapper)
        {
            _InterServiceCourseDocTypeRepository = InterServiceCourseDocTypeRepository;
            _mapper = mapper;
        }
        public async Task<InterServiceCourseDocTypeDto> Handle(GetInterServiceCourseDocTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var InterServiceCourseDocType = await _InterServiceCourseDocTypeRepository.Get(request.InterServiceCourseDocTypeId);
            return _mapper.Map<InterServiceCourseDocTypeDto>(InterServiceCourseDocType);
        }
    }
}
