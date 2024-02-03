using AutoMapper;
using SchoolManagement.Application.Features.FamilyNominations.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.FamilyNominations.Handlers.Commands
{
    public class CreateFamilyNominationListCommandHandler : IRequestHandler<CreateFamilyNominationListCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFamilyNominationListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateFamilyNominationListCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var FamilyNominations = request.FamilyNominationListDto;
            
            var familyNominationList = FamilyNominations.traineeListForm.Select(x => new FamilyNomination()
            {
                CourseDurationId = x.CourseDurationId,
                FamilyInfoId = x.FamilyInfoId,
                RelationTypeId = x.RelationTypeId,
                TraineeNominationId = x.TraineeNominationId,
                IsActive = FamilyNominations.IsActive,
                TraineeId = x.TraineeId,
                Status=x.Status,
            });

            await _unitOfWork.Repository<FamilyNomination>().AddRangeAsync(familyNominationList);
            await _unitOfWork.Save();


            response.Success = true;
            response.Message = "Creation Successful";

            return response;
        }
    }
}
