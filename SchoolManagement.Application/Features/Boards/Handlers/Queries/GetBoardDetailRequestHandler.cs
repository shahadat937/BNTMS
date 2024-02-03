using AutoMapper;
using SchoolManagement.Application.DTOs.Board;
using SchoolManagement.Application.Features.Boards.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Boards.Handlers.Queries
{
    public class GetBoardDetailRequestHandler : IRequestHandler<GetBoardDetailRequest, BoardDto>
    {
       // private readonly IBoardRepository _BoardRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Board> _BoardRepository;
        public GetBoardDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Board>  BoardRepository, IMapper mapper)
        {
            _BoardRepository = BoardRepository;
            _mapper = mapper;
        }
        public async Task<BoardDto> Handle(GetBoardDetailRequest request, CancellationToken cancellationToken)
        {
            var Board = await _BoardRepository.Get(request.BoardId);
            return _mapper.Map<BoardDto>(Board);
        }
    }
}
