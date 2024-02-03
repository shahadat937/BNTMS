using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ClassTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassTypes.Handlers.Queries
{
    public class GetSelectedClassTypeRequestHandler : IRequestHandler<GetSelectedClassTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ClassType> _ClassTypeRepository;


        public GetSelectedClassTypeRequestHandler(ISchoolManagementRepository<ClassType> ClassTypeRepository)
        {
            _ClassTypeRepository = ClassTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedClassTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<ClassType> codeValues = await _ClassTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ClassTypeName,
                Value = x.ClassTypeId
            }).ToList();
            return selectModels;
        }
    }
}
