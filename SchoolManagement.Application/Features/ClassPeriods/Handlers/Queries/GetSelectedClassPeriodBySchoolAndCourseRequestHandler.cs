using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassPeriods.Handlers.Queries
{
    public class GetSelectedClassPeriodBySchoolAndCourseRequestHandler : IRequestHandler<GetSelectedClassPeriodBySchoolAndCourseRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ClassPeriod> _ClassPeriodRepository;


        public GetSelectedClassPeriodBySchoolAndCourseRequestHandler(ISchoolManagementRepository<ClassPeriod> ClassPeriodRepository)
        {
            _ClassPeriodRepository = ClassPeriodRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedClassPeriodBySchoolAndCourseRequest request, CancellationToken cancellationToken)
        {
            ICollection<ClassPeriod> codeValues = await _ClassPeriodRepository.FilterAsync(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId); 
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.PeriodName,
                Value = x.ClassPeriodId
            }).ToList();
            return selectModels;
        }
    }
}
