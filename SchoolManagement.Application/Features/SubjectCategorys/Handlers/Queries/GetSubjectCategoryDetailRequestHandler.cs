using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SubjectCategorys;
using SchoolManagement.Application.Features.SubjectCategorys.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SubjectCategorys.Handlers.Queries
{
    public class GetSubjectCategoryDetailRequestHandler : IRequestHandler<GetSubjectCategoryDetailRequest, SubjectCategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SubjectCategory> _SubjectCategoryRepository;
        public GetSubjectCategoryDetailRequestHandler(ISchoolManagementRepository<SubjectCategory> SubjectCategoryRepository, IMapper mapper)
        {
            _SubjectCategoryRepository = SubjectCategoryRepository; 
            _mapper = mapper;
        }
        public async Task<SubjectCategoryDto> Handle(GetSubjectCategoryDetailRequest request, CancellationToken cancellationToken)
        {
            var SubjectCategory = await _SubjectCategoryRepository.Get(request.SubjectCategoryId);
            return _mapper.Map<SubjectCategoryDto>(SubjectCategory);
        }
    }
}
