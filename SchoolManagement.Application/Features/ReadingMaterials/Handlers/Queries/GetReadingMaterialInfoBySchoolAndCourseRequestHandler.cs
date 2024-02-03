using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ReadingMaterials.Requests.Queries;
using SchoolManagement.Application.DTOs.ReadingMaterial;

namespace SchoolManagement.Application.Features.ReadingMaterials.Handlers.Queries
{
    public class GetReadingMaterialInfoBySchoolAndCourseRequestHandler : IRequestHandler<GetReadingMaterialInfoBySchoolAndCourseRequest, List<ReadingMaterialDto>>
    {
        private readonly ISchoolManagementRepository<ReadingMaterial> _readingMaterialRepository;

        private readonly IMapper _mapper;
        public GetReadingMaterialInfoBySchoolAndCourseRequestHandler(ISchoolManagementRepository<ReadingMaterial> readingMaterialRepository, IMapper mapper)
        {
            _readingMaterialRepository = readingMaterialRepository;
            _mapper = mapper;
        }

        public async Task<List<ReadingMaterialDto>> Handle(GetReadingMaterialInfoBySchoolAndCourseRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ReadingMaterial> readingMaterials = _readingMaterialRepository.FilterWithInclude(x => (x.BaseSchoolNameId == request.BaseSchoolNameId || x.ShowRightId == request.BaseSchoolNameId) && x.CourseNameId == request.CourseNameId && x.ReadingMaterialTitleId == 1, "BaseSchoolName", "CourseName", "DocumentType", "DownloadRight", "ReadingMaterialTitle");

            var readingMaterialDtos = _mapper.Map<List<ReadingMaterialDto>>(readingMaterials);

            return readingMaterialDtos;
        }

    }
}
