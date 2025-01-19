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
        private readonly ISchoolManagementRepository<FamilyNomination> _familyNomination;

        public CreateFamilyNominationListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ISchoolManagementRepository<FamilyNomination> familyNomination)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _familyNomination = familyNomination;
        }

        public async Task<BaseCommandResponse> Handle(CreateFamilyNominationListCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var FamilyNominations = request.FamilyNominationListDto;
           
            foreach (var nominations in FamilyNominations.traineeListForm)
            {
                if(nominations.FamilyNominationId == null)
                {
                    var newNomination = new FamilyNomination
                    {
                        CourseDurationId = nominations.CourseDurationId,
                        FamilyInfoId = nominations.FamilyInfoId,
                        RelationTypeId = nominations.RelationTypeId,
                        TraineeNominationId = nominations.TraineeNominationId,
                        IsActive = FamilyNominations.IsActive,
                        TraineeId = nominations.TraineeId,
                        Status = nominations.Status
                    };
                    await _unitOfWork.Repository<FamilyNomination>().Add(newNomination);
                }
                else
                {
                    var exitingFamily = await _familyNomination.FindOneAsync(x => x.FamilyNominationId == nominations.FamilyNominationId);
                   
                    if (exitingFamily != null)
                    {

                        exitingFamily.Status = nominations.Status;
                        await _unitOfWork.Repository<FamilyNomination>().Update(exitingFamily);
                    }
                }
                await _unitOfWork.Save();
            }

            //await _unitOfWork.Repository<FamilyNomination>().AddRangeAsync(familyNominationList);
            //await _unitOfWork.Save();


            response.Success = true;
            response.Message = "Creation Successful";

            return response;
        }
    }
}
