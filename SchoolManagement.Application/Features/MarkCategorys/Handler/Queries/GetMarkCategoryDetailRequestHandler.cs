using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MarkCategory;
using SchoolManagement.Application.Features.MarkCategorys.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MarkCategorys.Handler.Queries
{
    public class GetMarkCategoryDetailRequestHandler : IRequestHandler<GetMarkCategoryDetailRequest, MarkCategoryDto>
    {
        private readonly IMapper _mapper; 
        private readonly ISchoolManagementRepository<MarkCategory> _MarkCategoryRepository; 
        public GetMarkCategoryDetailRequestHandler(ISchoolManagementRepository<MarkCategory> MarkCategoryRepository, IMapper mapper)
        {
            _MarkCategoryRepository = MarkCategoryRepository; 
            _mapper = mapper;
        }
        public async Task<MarkCategoryDto> Handle(GetMarkCategoryDetailRequest request, CancellationToken cancellationToken)
        {
            var MarkCategory = await _MarkCategoryRepository.Get(request.Id);
            return _mapper.Map<MarkCategoryDto>(MarkCategory);
        }
    }
}
