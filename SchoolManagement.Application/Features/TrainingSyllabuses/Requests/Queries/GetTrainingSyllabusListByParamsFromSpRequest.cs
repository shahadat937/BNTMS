using MediatR;

namespace SchoolManagement.Application.Features.TrainingSyllabuss.Requests.Queries
{
    public class GetTrainingSyllabusListByParamsFromSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
        public int BnaSubjectNameId { get; set; }
    }
}
