using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System.Data;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetCourseDurationListForBnaByCourseTypeIdFilterRequestHandler : IRequestHandler<GetCourseDurationListForBnaByCourseTypeIdFilterRequest, object>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;

        private readonly IMapper _mapper;
        public GetCourseDurationListForBnaByCourseTypeIdFilterRequestHandler(ISchoolManagementRepository<CourseDuration> CourseDurationRepository, IMapper mapper)
        {
            _CourseDurationRepository = CourseDurationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetCourseDurationListForBnaByCourseTypeIdFilterRequest request, CancellationToken cancellationToken)
        {
            var spQuery = String.Format("exec [spGetRunningCourseDurationListForBna] '{0}',{1},{2}", DateTime.Now, request.ViewStatus,request.CourseTypeId);

            DataTable dataTable = _CourseDurationRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
        }
    }        
}
