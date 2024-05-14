using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaExamManagements.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaExamManagements.Handlers.Queries
{
    public class GetSelectedSectionBnaExamManagementRequestHandler : IRequestHandler<GetSelectedSectionBnaExamManagementRequest, List<SelectedModel>>
    {

        private readonly ISchoolManagementRepository<Domain.BnaClassRoutine> _BnaClassRoutineRepository;
        private readonly ISchoolManagementRepository<Domain.CourseSection> _CourseSectionRepository;

        public GetSelectedSectionBnaExamManagementRequestHandler(ISchoolManagementRepository<Domain.BnaClassRoutine> BnaClassRoutineRepository, ISchoolManagementRepository<Domain.CourseSection> CourseSectionRepository)
        {
            _BnaClassRoutineRepository = BnaClassRoutineRepository;
            _CourseSectionRepository = CourseSectionRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSectionBnaExamManagementRequest request, CancellationToken cancellationToken)
        {

            IQueryable<Domain.BnaClassRoutine> bnaClassRoutiness = _BnaClassRoutineRepository.Where(x => true);

            List<int> getCourseSectionId = new List<int>();

            List<SelectedModel> selectModels = new List<SelectedModel>();

            foreach (var item in bnaClassRoutiness)
            {
                string[] courseNameIdsString = item.CourseNameId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                int[] courseNameIds = courseNameIdsString.Select(int.Parse).ToArray();
                foreach (var courseNameId in courseNameIds)
                {
                    if (courseNameId == request.CourseNameId && item.BaseSchoolNameId == request.BaseSchoolNameId)
                    {
                        string[] courseSectionIdsString = item.CourseSectionId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        int[] courseSectionIds = courseSectionIdsString.Select(int.Parse).ToArray();

                        foreach (var courseSectionId in courseSectionIds)
                        {
                            if (!getCourseSectionId.Contains(courseSectionId))
                            {
                                getCourseSectionId.Add(courseSectionId);
                            }
                        }
                    }
                }
            }

            foreach (var item in getCourseSectionId)
            {
                var courseSections = _CourseSectionRepository.Where(x => x.CourseSectionId==item).FirstOrDefault();
                SelectedModel selectedModel = new SelectedModel
                {
                    Value = courseSections.CourseSectionId,
                    Text = courseSections.SectionName
                };
                selectModels.Add(selectedModel);
            }
            return selectModels;
        }
    }
}
