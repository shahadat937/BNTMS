using AutoMapper;
using SchoolManagement.Application.Features.TraineeAssissmentGroups.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.TraineeAssissmentGroups.Handlers.Commands
{
    public class CreateTraineeAssissmentGroupListCommandHandler : IRequestHandler<CreateTraineeAssissmentGroupListCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTraineeAssissmentGroupListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTraineeAssissmentGroupListCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            //var TraineeAssissmentGroups = _mapper.Map<List<TraineeAssissmentGroup>>(request.TraineeAssissmentGroupListDto);
            var TraineeAssissmentGroups = request.TraineeAssissmentGroupListDto;

            var TraineeAssissmentGroupList = TraineeAssissmentGroups.assessmentTraineeGroupListForm.Where(x=>x.selectedStatus == true).Select(x => new TraineeAssissmentGroup()
            {
                CourseDurationId = TraineeAssissmentGroups.CourseDurationId,
                TraineeAssissmentCreateId = TraineeAssissmentGroups.TraineeAssissmentCreateId,
                AssissmentGroupName = TraineeAssissmentGroups.AssissmentGroupName,
                Status = TraineeAssissmentGroups.Status,
                MenuPosition = TraineeAssissmentGroups.MenuPosition,
                IsActive = TraineeAssissmentGroups.IsActive,
                TraineeNominationId = x.TraineeNominationId,
                TraineeId = x.TraineeId,
                Remarks = TraineeAssissmentGroups.Remarks,
            });
            await _unitOfWork.Repository<TraineeAssissmentGroup>().AddRangeAsync(TraineeAssissmentGroupList);
            await _unitOfWork.Save();
        
            response.Success = true;
            response.Message = "Creation Successful";

            return response;
        }
    }
}
