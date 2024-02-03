using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeSectionSelection;
using SchoolManagement.Application.Features.TraineeSectionSelections.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeSectionSelections.Handlers.Queries
{
    public class GetTraineeSectionSelectionDetailRequestHandler : IRequestHandler<GetTraineeSectionSelectionDetailRequest, TraineeSectionSelectionDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeSectionSelection> _TraineeSectionSelectionRepository;
        public GetTraineeSectionSelectionDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeSectionSelection> TraineeSectionSelectionRepository, IMapper mapper)
        {
            _TraineeSectionSelectionRepository = TraineeSectionSelectionRepository;
            _mapper = mapper;
        }
        public async Task<TraineeSectionSelectionDto> Handle(GetTraineeSectionSelectionDetailRequest request, CancellationToken cancellationToken)
        {
            var TraineeSectionSelection = await _TraineeSectionSelectionRepository.FindOneAsync(x => x.TraineeSectionSelectionId == request.TraineeSectionSelectionId);
            return _mapper.Map<TraineeSectionSelectionDto>(TraineeSectionSelection);
        }
    }
}
