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
    public class GetSelectedSubjectNamesBySchoolAndCourseRequestHandler : IRequestHandler<GetSelectedSubjectNamesBySchoolAndCourseRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BnaSubjectName> _BnaSubjectNameRepository;


        public GetSelectedSubjectNamesBySchoolAndCourseRequestHandler(ISchoolManagementRepository<BnaSubjectName> BnaSubjectNameRepository)
        {
            _BnaSubjectNameRepository = BnaSubjectNameRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSubjectNamesBySchoolAndCourseRequest request, CancellationToken cancellationToken)
        {
            ICollection<BnaSubjectName> BnaSubjectNames = _BnaSubjectNameRepository.Where(x=>x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.SubjectActiveStatus != 0 ).ToList();
            List<SelectedModel> selectModels = BnaSubjectNames.Select(x => new SelectedModel
            {
                Text = x.SubjectName,
                Value = x.BnaSubjectNameId
            }).ToList();
            return selectModels;
        }
    }
}
