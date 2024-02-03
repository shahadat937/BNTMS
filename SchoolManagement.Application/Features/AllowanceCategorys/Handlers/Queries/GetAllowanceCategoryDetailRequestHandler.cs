using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AllowanceCategory;
using SchoolManagement.Application.Features.AllowanceCategorys.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AllowanceCategorys.Handlers.Queries
{
    public class GetAllowanceCategoryDetailRequestHandler : IRequestHandler<GetAllowanceCategoryDetailRequest, AllowanceCategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<AllowanceCategory> _AllowanceCategoryRepository;
        public GetAllowanceCategoryDetailRequestHandler(ISchoolManagementRepository<AllowanceCategory> AllowanceCategoryRepository, IMapper mapper)
        {
            _AllowanceCategoryRepository = AllowanceCategoryRepository;
            _mapper = mapper;
        }
        public async Task<AllowanceCategoryDto> Handle(GetAllowanceCategoryDetailRequest request, CancellationToken cancellationToken)
        {
            var AllowanceCategory = await _AllowanceCategoryRepository.Get(request.AllowanceCategoryId);
            return _mapper.Map<AllowanceCategoryDto>(AllowanceCategory);
        }
    }
}
