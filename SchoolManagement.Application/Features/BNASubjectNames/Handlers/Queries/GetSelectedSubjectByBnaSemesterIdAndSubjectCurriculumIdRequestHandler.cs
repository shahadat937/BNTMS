using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Handlers.Queries
{
    public class GetSelectedSubjectByBnaSemesterIdAndSubjectCurriculumIdRequestHandler : IRequestHandler<GetSelectedSubjectByBnaSemesterIdAndSubjectCurriculumIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BnaSubjectName> _BnaSubjectNameRepository;


        public GetSelectedSubjectByBnaSemesterIdAndSubjectCurriculumIdRequestHandler(ISchoolManagementRepository<BnaSubjectName> BnaSubjectNameRepository)
        {
            _BnaSubjectNameRepository = BnaSubjectNameRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSubjectByBnaSemesterIdAndSubjectCurriculumIdRequest request, CancellationToken cancellationToken)
        {
            //ICollection<BnaSubjectName> codeValues = await _BnaSubjectNameRepository.FilterAsync(x => x.IsActive);
            //List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            //{
            //    Text = x.SubjectName,
            //    Value = x.BnaSubjectNameId
            //}).ToList();
            //return selectModels;
            ICollection<BnaSubjectName> BnaSubjectNames = _BnaSubjectNameRepository.Where(x => x.BnaSemesterId == request.BnaSemesterId && x.BnaSubjectCurriculumId == request.BnaSubjectCurriculumId && x.SubjectActiveStatus == 1).ToList();
            List<SelectedModel> selectModels = BnaSubjectNames.Select(x => new SelectedModel
            {
                Text = x.SubjectName,
                Value = x.BnaSubjectNameId
            }).ToList();
            return selectModels;
        }
    }
}
