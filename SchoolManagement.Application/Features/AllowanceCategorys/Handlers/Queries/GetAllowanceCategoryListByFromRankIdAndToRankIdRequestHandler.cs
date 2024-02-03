using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AllowanceCategory;
using SchoolManagement.Application.Features.AllowanceCategorys.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AllowanceCategorys.Handlers.Queries
{
    public class GetAllowanceCategoryListByFromRankIdAndToRankIdRequestHandler : IRequestHandler<GetAllowanceCategoryListByFromRankIdAndToRankIdRequest, List<AllowanceCategoryDto>>
    {
        private readonly ISchoolManagementRepository<AllowanceCategory> _AllowanceCategoryRepository;
        private readonly IMapper _mapper;

        public GetAllowanceCategoryListByFromRankIdAndToRankIdRequestHandler(ISchoolManagementRepository<AllowanceCategory> AllowanceCategoryRepository, IMapper mapper)
        {
            _AllowanceCategoryRepository = AllowanceCategoryRepository;
            _mapper = mapper;
        }
         
        public async Task<List<AllowanceCategoryDto>> Handle(GetAllowanceCategoryListByFromRankIdAndToRankIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<AllowanceCategory> allowanceCategorys = _AllowanceCategoryRepository.FilterWithInclude(x=>x.FromRankId == request.FromRankId && x.ToRankId == request.ToRankId, "CountryGroup", "Country", "CurrencyName", "AllowancePercentage").ToList();
            //List<SelectedModel> selectModels = courseModules.Select(x => new SelectedModel
            //{
            //    Text = x.ModuleName,
            //    Value = x.CourseModuleId 
            //}).ToList();
            var AllowanceCategoryDtos = _mapper.Map<List<AllowanceCategoryDto>>(allowanceCategorys);
            return AllowanceCategoryDtos; 
        }
    }
}
