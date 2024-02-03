using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.RoutineNote;
using SchoolManagement.Application.Features.RoutineNotes.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.RoutineNotes.Handlers.Queries
{
    public class GetRoutineNoteDetailRequestHandler : IRequestHandler<GetRoutineNoteDetailRequest, RoutineNoteDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<RoutineNote> _RoutineNoteRepository;
        public GetRoutineNoteDetailRequestHandler(ISchoolManagementRepository<RoutineNote> RoutineNoteRepository, IMapper mapper)
        {
            _RoutineNoteRepository = RoutineNoteRepository;
            _mapper = mapper;
        }
        public async Task<RoutineNoteDto> Handle(GetRoutineNoteDetailRequest request, CancellationToken cancellationToken)
        {
            var RoutineNote = await _RoutineNoteRepository.Get(request.RoutineNoteId);
            return _mapper.Map<RoutineNoteDto>(RoutineNote);
        }
    }
}
