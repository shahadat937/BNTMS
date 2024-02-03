using AutoMapper;
using SchoolManagement.Application.DTOs.ReadingMaterial;
using SchoolManagement.Application.Features.ReadingMaterials.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ReadingMaterials.Handlers.Queries
{
    public class GetReadingMaterialDetailRequestHandler : IRequestHandler<GetReadingMaterialDetailRequest, ReadingMaterialDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ReadingMaterial> _ReadingMaterialRepository;
        public GetReadingMaterialDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ReadingMaterial> ReadingMaterialRepository, IMapper mapper)
        {
            _ReadingMaterialRepository = ReadingMaterialRepository;
            _mapper = mapper;
        }
        public async Task<ReadingMaterialDto> Handle(GetReadingMaterialDetailRequest request, CancellationToken cancellationToken)
        {
            //var ReadingMaterial = await _ReadingMaterialRepository.FindOneAsync(x => x.ReadingMaterialId == request.ReadingMaterialId);
            var ReadingMaterial = _ReadingMaterialRepository.FinedOneInclude(x => x.ReadingMaterialId == request.ReadingMaterialId, "CourseName");
            return _mapper.Map<ReadingMaterialDto>(ReadingMaterial);
        }
    }
}
