using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaClassSectionSelection;
using SchoolManagement.Application.Features.BnaClassSections.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassSections.Handler.Queries
{
    public class GetBnaClassSectionDetailRequestHandler : IRequestHandler<GetBnaClassSectionDetailRequest, BnaClassSectionSelectionDto>
    {
        private readonly IMapper _mapper; 
        private readonly ISchoolManagementRepository<BnaClassSectionSelection> _bnaClassSectionRepository; 
        public GetBnaClassSectionDetailRequestHandler(ISchoolManagementRepository<BnaClassSectionSelection> bnaClassSectionRepository, IMapper mapper)
        {
            _bnaClassSectionRepository = bnaClassSectionRepository; 
            _mapper = mapper;
        } 
        public async Task<BnaClassSectionSelectionDto> Handle(GetBnaClassSectionDetailRequest request, CancellationToken cancellationToken)
        {
            var BnaClassSection = await _bnaClassSectionRepository.Get(request.Id);
            return _mapper.Map<BnaClassSectionSelectionDto>(BnaClassSection);
        }
    }
}
