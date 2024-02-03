using AutoMapper;
using SchoolManagement.Application.DTOs.RecordOfService;
using SchoolManagement.Application.Features.RecordOfServices.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.CodeValues;

namespace SchoolManagement.Application.Features.RecordOfServices.Handlers.Queries
{

    public class GetRecordOfServiceListByTraineeRequestHandler : IRequestHandler<GetRecordOfServiceListByTraineeRequest, List<RecordOfServiceDto>>
    {
        private readonly IMapper _mapper; 
        private readonly ISchoolManagementRepository<RecordOfService> _RecordOfServiceRepository;
        public GetRecordOfServiceListByTraineeRequestHandler(ISchoolManagementRepository<RecordOfService> RecordOfServiceRepository, IMapper mapper)
        {
            _RecordOfServiceRepository = RecordOfServiceRepository;
            _mapper = mapper;
        }
        public async Task<List<RecordOfServiceDto>> Handle(GetRecordOfServiceListByTraineeRequest request, CancellationToken cancellationToken)
        {
            var RecordOfService = _RecordOfServiceRepository.FilterWithInclude(x =>x.TraineeId == request.Traineeid);
            return _mapper.Map<List<RecordOfServiceDto>>(RecordOfService);
        }
    }
}
