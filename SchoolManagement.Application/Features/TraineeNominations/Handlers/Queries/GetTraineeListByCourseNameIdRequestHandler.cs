using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries
{
    public class GetTraineeListByCourseNameIdRequestHandler : IRequestHandler<GetTraineeListByCourseNameIdRequest, object>
    {
        private readonly ISchoolManagementRepository<TraineeNomination> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;
        public GetTraineeListByCourseNameIdRequestHandler(ISchoolManagementRepository<TraineeNomination> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }
        public async Task<object> Handle(GetTraineeListByCourseNameIdRequest request, CancellationToken cancellationToken)
        {
            var spQuery = String.Format("exec [spGetTraineeNominationListByCourseNameId] {0}", request.CourseNameId);

            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);

            return dataTable;
        }
    }
}
