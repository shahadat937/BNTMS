using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaExamSchedules.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.DTOs.BnaExamSchedule.Validators;

namespace SchoolManagement.Application.Features.BnaExamSchedules.Handlers.Commands
{
    public class UpdateBnaExamScheduleCommandHandler : IRequestHandler<UpdateBnaExamScheduleCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBnaExamScheduleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBnaExamScheduleCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBnaExamScheduleDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaExamScheduleDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BnaExamSchedule = await _unitOfWork.Repository<BnaExamSchedule>().Get(request.BnaExamScheduleDto.BnaExamScheduleId);

            if (BnaExamSchedule is null)
                throw new NotFoundException(nameof(BnaExamSchedule), request.BnaExamScheduleDto.BnaExamScheduleId);

            _mapper.Map(request.BnaExamScheduleDto, BnaExamSchedule);

            await _unitOfWork.Repository<BnaExamSchedule>().Update(BnaExamSchedule);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
