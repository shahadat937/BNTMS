using AutoMapper;
using SchoolManagement.Application.DTOs.ReadingMaterialTitle;
using SchoolManagement.Application.Features.ReadingMaterialTitles.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.DTOs.ReadingMaterialTitles;

namespace SchoolManagement.Application.Features.ReadingMaterialTitles.Handlers.Queries
{
    public class GetReadingMaterialTitleDetailRequestHandler : IRequestHandler<GetReadingMaterialTitleDetailRequest, ReadingMaterialTitleDto>
    {
       // private readonly IReadingMaterialTitleRepository _ReadingMaterialTitleRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ReadingMaterialTitle> _ReadingMaterialTitleRepository;
        public GetReadingMaterialTitleDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ReadingMaterialTitle>  ReadingMaterialTitleRepository, IMapper mapper)
        {
            _ReadingMaterialTitleRepository = ReadingMaterialTitleRepository;
            _mapper = mapper;
        }
        public async Task<ReadingMaterialTitleDto> Handle(GetReadingMaterialTitleDetailRequest request, CancellationToken cancellationToken)
        {
            var ReadingMaterialTitle = await _ReadingMaterialTitleRepository.Get(request.ReadingMaterialTitleId);
            return _mapper.Map<ReadingMaterialTitleDto>(ReadingMaterialTitle);
        }
    }
}
 