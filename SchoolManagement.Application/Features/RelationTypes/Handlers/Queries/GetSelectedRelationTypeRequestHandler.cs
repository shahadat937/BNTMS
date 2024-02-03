using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.RelationTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.RelationTypes.Handlers.Queries
{
    public class GetSelectedRelationTypeRequestHandler : IRequestHandler<GetSelectedRelationTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<RelationType> _RelationTypeRepository;


        public GetSelectedRelationTypeRequestHandler(ISchoolManagementRepository<RelationType> RelationTypeRepository)
        {
            _RelationTypeRepository = RelationTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedRelationTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<RelationType> codeValues = await _RelationTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.RelationTypeName,
                Value = x.RelationTypeId
            }).ToList();
            return selectModels;
        }
    }
}
