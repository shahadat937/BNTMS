using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Boards.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Boards.Handlers.Queries
{
    public class GetSelectedBoardRequestHandler : IRequestHandler<GetSelectedBoardRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Board> _BoardRepository;


        public GetSelectedBoardRequestHandler(ISchoolManagementRepository<Board> BoardRepository)
        {
            _BoardRepository = BoardRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBoardRequest request, CancellationToken cancellationToken)
        {
            ICollection<Board> codeValues = await _BoardRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.BoardName,
                Value = x.BoardId
            }).ToList();
            return selectModels;
        }
    }
}
