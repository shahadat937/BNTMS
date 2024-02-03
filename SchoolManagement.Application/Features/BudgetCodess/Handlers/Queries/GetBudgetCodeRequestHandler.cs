using AutoMapper;
using SchoolManagement.Application.DTOs.BudgetCode;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.SubjectMarks.Requests.Queries;

namespace SchoolManagement.Application.Features.BudgetCodes.Handlers.Queries   
{
    public class GetBudgetCodeRequestHandler : IRequestHandler<GetBudgetCodeRequest, List<BudgetCodeDto>>
    {
        private readonly ISchoolManagementRepository<BudgetCode> _BudgetCodeRepository;

        private readonly IMapper _mapper;

        public GetBudgetCodeRequestHandler(ISchoolManagementRepository<BudgetCode> BudgetCodeRepository, IMapper mapper)
        {
            _BudgetCodeRepository = BudgetCodeRepository; 
            _mapper = mapper;
        }

        public async Task<List<BudgetCodeDto>> Handle(GetBudgetCodeRequest request, CancellationToken cancellationToken)
        {
            IQueryable<BudgetCode> BudgetCodes = _BudgetCodeRepository.FilterWithInclude(x => x.IsActive);
            //var BudgetCodes = _BudgetCodeRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.BudgetCodeId);

            var BudgetCodeDtos = _mapper.Map<List<BudgetCodeDto>>(BudgetCodes);

            return BudgetCodeDtos;
        }
    }
}
