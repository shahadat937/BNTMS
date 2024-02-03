using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AssignmentMarkEntry;
using SchoolManagement.Application.Features.AssignmentMarkEntrys.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.AssignmentMarkEntrys.Handlers.Queries
{
    public class GetAssignmentMarkEntryDetailRequestHandler : IRequestHandler<GetAssignmentMarkEntryDetailRequest, AssignmentMarkEntryDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<AssignmentMarkEntry> _AssignmentMarkEntryRepository;
        public GetAssignmentMarkEntryDetailRequestHandler(ISchoolManagementRepository<AssignmentMarkEntry> AssignmentMarkEntryRepository, IMapper mapper)
        {
            _AssignmentMarkEntryRepository = AssignmentMarkEntryRepository;
            _mapper = mapper;
        }
        public async Task<AssignmentMarkEntryDto> Handle(GetAssignmentMarkEntryDetailRequest request, CancellationToken cancellationToken)
        {
            var AssignmentMarkEntry = await _AssignmentMarkEntryRepository.Get(request.AssignmentMarkEntryId);
            return _mapper.Map<AssignmentMarkEntryDto>(AssignmentMarkEntry);
        }
    }
}
