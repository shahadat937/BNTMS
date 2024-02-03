using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseDurations.Validators;
using SchoolManagement.Application.Features.CourseDurations.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Commands
{
    public class CreateCourseDurationCommandHandler : IRequestHandler<CreateCourseDurationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCourseDurationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCourseDurationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCourseDurationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CourseDurationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var CourseDuration = _mapper.Map<CourseDuration>(request.CourseDurationDto);
                //CourseDuration.IsCompletedStatus = 0;

                CourseDuration = await _unitOfWork.Repository<CourseDuration>().Add(CourseDuration);
                CourseDuration.DurationFrom = CourseDuration.DurationFrom.Value.AddDays(1.0);
                CourseDuration.DurationTo = CourseDuration.DurationTo.Value.AddDays(1.0);
                //CourseDuration.NbcdStatus = 0;

                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CourseDuration.CourseDurationId;
            }

            return response;
        }
    }
}
