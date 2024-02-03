using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.ReadingMaterial;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;

namespace SchoolManagement.Application.Features.ReadingMaterials.Handlers.Queries
{
    public class GetReadingMaterialsByMaterialTitleIdBaseSchoolIdAndCourseNameIdRequestHandler : IRequestHandler<GetReadingMaterialsByMaterialTitleIdBaseSchoolIdAndCourseNameIdRequest, List<ReadingMaterialDto>>
    {
        private readonly ISchoolManagementRepository<ReadingMaterial> _readingMaterialRepository;

        private readonly IMapper _mapper;
        public GetReadingMaterialsByMaterialTitleIdBaseSchoolIdAndCourseNameIdRequestHandler(ISchoolManagementRepository<ReadingMaterial> readingMaterialRepository, IMapper mapper)
        {
            _readingMaterialRepository = readingMaterialRepository;
            _mapper = mapper;
        }

        public async Task<List<ReadingMaterialDto>> Handle(GetReadingMaterialsByMaterialTitleIdBaseSchoolIdAndCourseNameIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ReadingMaterial> readingMaterials = _readingMaterialRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.ReadingMaterialTitleId == request.ReadingMaterialTitleId, "BaseSchoolName", "CourseName", "DocumentType", "DownloadRight", "ReadingMaterialTitle");

            var readingMaterialDtos = _mapper.Map<List<ReadingMaterialDto>>(readingMaterials);

            return readingMaterialDtos; 
        }

    }
}
