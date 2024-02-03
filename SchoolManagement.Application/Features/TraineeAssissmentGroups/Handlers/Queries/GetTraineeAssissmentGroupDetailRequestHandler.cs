using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeAssissmentGroup;
using SchoolManagement.Application.Features.TraineeAssissmentGroups.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeAssissmentGroups.Handlers.Queries
{
    public class GetTraineeAssissmentGroupDetailRequestHandler : IRequestHandler<GetTraineeAssissmentGroupDetailRequest, TraineeAssissmentGroupDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeAssissmentGroup> _TraineeAssissmentGroupRepository;
        public GetTraineeAssissmentGroupDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeAssissmentGroup> TraineeAssissmentGroupRepository, IMapper mapper)
        {
            _TraineeAssissmentGroupRepository = TraineeAssissmentGroupRepository;
            _mapper = mapper;
        }
        public async Task<TraineeAssissmentGroupDto> Handle(GetTraineeAssissmentGroupDetailRequest request, CancellationToken cancellationToken)
        {
            var TraineeAssissmentGroup = await _TraineeAssissmentGroupRepository.Get(request.TraineeAssissmentGroupId);
            return _mapper.Map<TraineeAssissmentGroupDto>(TraineeAssissmentGroup);
        }
    }
}
