using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseGradingEntrys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseGradingEntrys.Handlers.Queries
{
    public class GetSelectedCourseGradingEntryRequestHandler : IRequestHandler<GetSelectedCourseGradingEntryRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseGradingEntry> _CourseGradingEntryRepository;


        public GetSelectedCourseGradingEntryRequestHandler(ISchoolManagementRepository<CourseGradingEntry> CourseGradingEntryRepository)
        {
            _CourseGradingEntryRepository = CourseGradingEntryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCourseGradingEntryRequest request, CancellationToken cancellationToken)
        {
            ICollection<CourseGradingEntry> codeValues = await _CourseGradingEntryRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.MarkObtained,
                Value = x.CourseGradingEntryId
            }).ToList();
            return selectModels;
        }
    }
}
