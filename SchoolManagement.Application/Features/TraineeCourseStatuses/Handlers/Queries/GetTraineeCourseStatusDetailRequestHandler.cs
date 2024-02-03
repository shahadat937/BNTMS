using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TraineeCourseStatus;
using SchoolManagement.Application.Features.TraineeCourseStatuses.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeCourseStatuses.Handlers.Queries
{
    public class GetTraineeCourseStatusesDetailRequestHandler : IRequestHandler<GetTraineeCourseStatusesDetailRequest, TraineeCourseStatusDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<TraineeCourseStatus> _TraineeCourseStatusRepository;       
        public GetTraineeCourseStatusesDetailRequestHandler(ISchoolManagementRepository<TraineeCourseStatus> TraineeCourseStatusRepository, IMapper mapper)
        {
            _TraineeCourseStatusRepository = TraineeCourseStatusRepository;    
            _mapper = mapper; 
        } 
        public async Task<TraineeCourseStatusDto> Handle(GetTraineeCourseStatusesDetailRequest request, CancellationToken cancellationToken)
        {
            var TraineeCourseStatus = await _TraineeCourseStatusRepository.Get(request.Id);    
            return _mapper.Map<TraineeCourseStatusDto>(TraineeCourseStatus);    
        }
    }
}
