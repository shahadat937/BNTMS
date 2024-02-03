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
    public class UpdateCourseDurationCommandHandler : IRequestHandler<UpdateCourseDurationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCourseDurationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCourseDurationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCourseDurationDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.CourseDurationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var CourseDuration = await _unitOfWork.Repository<CourseDuration>().Get(request.CourseDurationDto.CourseDurationId);

            if (CourseDuration is null)
                throw new NotFoundException(nameof(CourseDuration), request.CourseDurationDto.CourseDurationId);

            _mapper.Map(request.CourseDurationDto, CourseDuration);

            await _unitOfWork.Repository<CourseDuration>().Update(CourseDuration);
            CourseDuration.DurationFrom = CourseDuration.DurationFrom.Value.AddDays(1.0);
            CourseDuration.DurationTo = CourseDuration.DurationTo.Value.AddDays(1.0);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
