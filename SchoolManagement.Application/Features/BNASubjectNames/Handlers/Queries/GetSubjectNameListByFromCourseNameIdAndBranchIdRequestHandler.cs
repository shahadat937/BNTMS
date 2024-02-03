using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Handlers.Queries
{
    public class GetSubjectNameListByFromCourseNameIdAndBranchIdRequestHandler : IRequestHandler<GetSubjectNameListByFromCourseNameIdAndBranchIdRequest, List<BnaSubjectNameDto>>
    {
        private readonly ISchoolManagementRepository<BnaSubjectName> _BnaSubjectNameRepository;
        private readonly IMapper _mapper;

        public GetSubjectNameListByFromCourseNameIdAndBranchIdRequestHandler(ISchoolManagementRepository<BnaSubjectName> BnaSubjectNameRepository, IMapper mapper)
        {
            _BnaSubjectNameRepository = BnaSubjectNameRepository;
            _mapper = mapper;
        }
         
        public async Task<List<BnaSubjectNameDto>> Handle(GetSubjectNameListByFromCourseNameIdAndBranchIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<BnaSubjectName> bnaSubjectNames = _BnaSubjectNameRepository.FilterWithInclude(x=>x.CourseNameId == request.CourseNameId && x.BranchId == request.BranchId).ToList();
            //List<SelectedModel> selectModels = courseModules.Select(x => new SelectedModel
            //{
            //    Text = x.ModuleName,
            //    Value = x.CourseModuleId 
            //}).ToList();
            var BnaSubjectNameDtos = _mapper.Map<List<BnaSubjectNameDto>>(bnaSubjectNames);
            return BnaSubjectNameDtos; 
        }
    }
}
