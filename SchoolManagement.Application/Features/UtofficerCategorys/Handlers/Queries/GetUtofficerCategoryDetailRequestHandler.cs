using AutoMapper;
using SchoolManagement.Application.DTOs.UtofficerCategory;
using SchoolManagement.Application.Features.UtofficerCategorys.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.UtofficerCategorys.Handlers.Queries
{
    public class GetUtofficerCategoryDetailRequestHandler : IRequestHandler<GetUtofficerCategoryDetailRequest, UtofficerCategoryDto>
    {
       // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.UtofficerCategory> _UtofficerCategoryRepository;
        public GetUtofficerCategoryDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.UtofficerCategory> UtofficerCategoryRepository, IMapper mapper)
        {
            _UtofficerCategoryRepository = UtofficerCategoryRepository;
            _mapper = mapper;
        }
        public async Task<UtofficerCategoryDto> Handle(GetUtofficerCategoryDetailRequest request, CancellationToken cancellationToken)
        {
            var UtofficerCategory = await _UtofficerCategoryRepository.Get(request.UtofficerCategoryId);
            return _mapper.Map<UtofficerCategoryDto>(UtofficerCategory);
        }
    }
}
