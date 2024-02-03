using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseDurations.Requests.Commands;
using SchoolManagement.Application.Features.CoursePlans.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CoursePlans.Handlers.Commands
{
    public class DeActivateCourseDurationCommandHandler : IRequestHandler<DeActivateCourseDurationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<TraineeNomination> _TraineeNominationRepository;

        public DeActivateCourseDurationCommandHandler(ISchoolManagementRepository<TraineeNomination> TraineeNominationRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _TraineeNominationRepository = TraineeNominationRepository;
        }
        public async Task<Unit> Handle(DeActivateCourseDurationCommand request, CancellationToken cancellationToken)
        {
            var CourseDuration = await _unitOfWork.Repository<CourseDuration>().Get(request.CourseDurationId);
            CourseDuration.IsCompletedStatus = 1;

            

            if (CourseDuration == null)
                throw new NotFoundException(nameof(CourseDuration), request.CourseDurationId);

            var nominations =  _TraineeNominationRepository.FilterWithInclude(x => x.CourseDurationId == request.CourseDurationId).ToList();

            foreach (var item in nominations)
            {
                var traineeBiodata = await _unitOfWork.Repository<TraineeBioDataGeneralInfo>().Get(item.TraineeId ?? 0);
                traineeBiodata.LocalNominationStatus = 0;
                //_mapper.Map(request.AllowanceDto, Allowance);

                await _unitOfWork.Repository<TraineeBioDataGeneralInfo>().Update(traineeBiodata);
                await _unitOfWork.Save();
            }

            await _unitOfWork.Repository<CourseDuration>().Update(CourseDuration);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
