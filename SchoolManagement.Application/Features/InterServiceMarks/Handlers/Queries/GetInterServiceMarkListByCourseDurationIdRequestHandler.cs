using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.InterServiceMark;
using SchoolManagement.Application.Features.InterServiceMarks.Requests.Queries;
using SchoolManagement.Domain;
using System.Data;

namespace SchoolManagement.Application.Features.InterServiceMarks.Handlers.Queries
{
    public class GetInterServiceMarkListByCourseDurationIdRequestHandler : IRequestHandler<GetInterServiceMarkListByCourseDurationIdRequest, object>
    {
        private readonly ISchoolManagementRepository<InterServiceMark> _InterServiceMarkRepository;
        private readonly IMapper _mapper;

        public GetInterServiceMarkListByCourseDurationIdRequestHandler(ISchoolManagementRepository<InterServiceMark> InterServiceMarkRepository, IMapper mapper)
        {
            _InterServiceMarkRepository = InterServiceMarkRepository;
            _mapper = mapper;
        }
         
        public async Task<object> Handle(GetInterServiceMarkListByCourseDurationIdRequest request, CancellationToken cancellationToken)
        {
            var spQuery = String.Format("exec [spGetMarkListByCourseDurationId] {0}", request.CourseDurationId);

            DataTable dataTable = _InterServiceMarkRepository.ExecWithSqlQuery(spQuery);

            return dataTable; 
        }
    }
}
