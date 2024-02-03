using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.DTOs.CourseDurations.Validators;
using SchoolManagement.Application.Features.CourseDurations.Requests.Commands;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Commands
{
    public class UpdateNbcdCourseDurationCommandHandler : IRequestHandler<UpdateNbcdCourseDurationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateNbcdCourseDurationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateNbcdCourseDurationCommand request, CancellationToken cancellationToken)
        { 

            var CourseDuration = await _unitOfWork.Repository<CourseDuration>().Get(request.CourseDurationDto.CourseDurationId);

            if (CourseDuration is null)
                throw new NotFoundException(nameof(CourseDuration), request.CourseDurationDto.CourseDurationId);

           // CourseDuration.NbcdSchoolId = request.CourseDurationDto.NbcdSchoolId;
            CourseDuration.NbcdDurationFrom = request.CourseDurationDto.NbcdDurationFrom;
            CourseDuration.NbcdDurationTo = request.CourseDurationDto.NbcdDurationTo;
            CourseDuration.NbcdStatus = request.CourseDurationDto.NbcdStatus;

            CourseDuration.DurationFrom = CourseDuration.DurationFrom.Value.AddDays(1.0);
            CourseDuration.DurationTo = CourseDuration.DurationTo.Value.AddDays(1.0);

            await _unitOfWork.Repository<CourseDuration>().Update(CourseDuration);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
