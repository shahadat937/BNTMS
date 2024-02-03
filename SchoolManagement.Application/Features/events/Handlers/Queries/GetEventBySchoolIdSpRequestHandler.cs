using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Events.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.Events.Handlers.Queries
{
    public class GetEventBySchoolIdSpRequestHandler : IRequestHandler<GetEventBySchoolIdSpRequest, object>
    {

        private readonly ISchoolManagementRepository<Event> _EventRepository;

        private readonly IMapper _mapper;

        public GetEventBySchoolIdSpRequestHandler(ISchoolManagementRepository<Event> EventRepository, IMapper mapper)
        {
            _EventRepository = EventRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetEventBySchoolIdSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetEvents] '{0}',{1}", request.CurrentDate, request.BaseSchoolNameId);
            
            DataTable dataTable = _EventRepository.ExecWithSqlQuery(spQuery);
            var countv = dataTable.Rows.Count;
            return dataTable;
         
        }
    }
}
