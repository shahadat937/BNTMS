using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaClassTest;
using SchoolManagement.Application.Features.BnaClassTests.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaClassTests.Handlers.Queries
{
    public class GetBnaClassTestDetailRequestHandler: IRequestHandler<GetBnaClassTestDetailRequest, BnaClassTestDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<BnaClassTest> _BnaClassTestRepository;
        public GetBnaClassTestDetailRequestHandler(ISchoolManagementRepository<BnaClassTest> BnaClassTestRepository, IMapper mapper)
        {
            _BnaClassTestRepository = BnaClassTestRepository;
            _mapper = mapper;
        }
        public async Task<BnaClassTestDto> Handle(GetBnaClassTestDetailRequest request, CancellationToken cancellationToken)
        {
            var BnaClassTest = await _BnaClassTestRepository.Get(request.BnaClassTestId);
            return _mapper.Map<BnaClassTestDto>(BnaClassTest);
        }
    }
}
