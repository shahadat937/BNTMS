using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseInstructors.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseInstructors.Handlers.Queries
{

    public class GetDropdownSelectedCourseInstructorRequestHandler : IRequestHandler<GetDropdownSelectedCourseInstructorRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseInstructor> _BnaCourseInstructorRepository;
        private readonly ISchoolManagementRepository<TraineeBioDataGeneralInfo> _TraineeInformation;


        public GetDropdownSelectedCourseInstructorRequestHandler(ISchoolManagementRepository<CourseInstructor> BnaCourseInstructorRepository, ISchoolManagementRepository<TraineeBioDataGeneralInfo> traineeInformation)
        {
            _BnaCourseInstructorRepository = BnaCourseInstructorRepository;
            _TraineeInformation = traineeInformation;
        }

        public async Task<List<SelectedModel>> Handle(GetDropdownSelectedCourseInstructorRequest request, CancellationToken cancellationToken)
        {
            ICollection<CourseInstructor> courseInstructorsInfo = _BnaCourseInstructorRepository.Where(x => x.BnaSubjectNameId == request.BnaSubjectNameId && x.IsActive != false).ToList();

            var traineeIds = courseInstructorsInfo.Select(x => x.TraineeId).ToList();


            ICollection<TraineeBioDataGeneralInfo> traineeInformation = _TraineeInformation.Where(x => traineeIds.Contains(x.TraineeId)).ToList();

            List<SelectedModel> selectModels = traineeInformation.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.TraineeId
            }).ToList();

            return selectModels;
        }
    }
}
